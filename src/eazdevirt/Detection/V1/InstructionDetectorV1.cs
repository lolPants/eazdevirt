using System;
using System.Collections.Generic;
using System.Reflection;
using dnlib.DotNet.Emit;
using eazdevirt.Reflection;

namespace eazdevirt.Detection.V1
{
	/// <summary>
	/// Instruction detector for assemblies protected with "V1" virtualization
	/// (v3.4 - v4.9).
	/// </summary>
	public sealed class InstructionDetectorV1 : InstructionDetectorBase
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		public static InstructionDetectorV1 Instance { get { return _instance; } }
		private static InstructionDetectorV1 _instance = new InstructionDetectorV1();

		/// <summary>
		/// Delegate for detector methods.
		/// </summary>
		/// <param name="instruction">Virtual instruction</param>
		/// <returns>true if detected, false if not</returns>
		private delegate Boolean Detector(VirtualOpCode instruction);

		/// <summary>
		/// Dictionary mapping CIL opcodes to their respective detector methods.
		/// </summary>
		private Dictionary<Code, List<Detector>> _detectors = new Dictionary<Code, List<Detector>>();

		/// <summary>
		/// Dictionary mapping special opcodes to their respective detector methods.
		/// </summary>
		private Dictionary<SpecialCode, List<Detector>> _specialDetectors = new Dictionary<SpecialCode, List<Detector>>();

		/// <summary>
		/// Construct an InstructionDetectorV1.
		/// </summary>
		private InstructionDetectorV1()
		{
			this.Initialize();
		}

		/// <summary>
		/// Build the detector dictionary via reflection.
		/// </summary>
		private void Initialize()
		{
			var extensions = typeof(eazdevirt.Detection.V1.Ext.Extensions);
			var methods = extensions.GetMethods();
			foreach (var method in methods)
			{
				var attrs = method.GetCustomAttributes<DetectAttribute>();
				foreach (var attr in attrs)
				{
					Detector detector = (Detector)Delegate.CreateDelegate(typeof(Detector), method);
					if (attr != null && detector != null)
					{
						this.AddDetector(attr, detector);
					}
				}
			}
		}

		/// <summary>
		/// Add a detector to the dictionary, printing a warning if one already exists for
		/// a CIL opcode.
		/// </summary>
		/// <param name="attr">Attribute</param>
		/// <param name="callback">Detector delegate</param>
		private void AddDetector(DetectAttribute attr, Detector callback)
		{
			if (attr.IsSpecial)
			{
				if (!_specialDetectors.ContainsKey(attr.SpecialOpCode))
					_specialDetectors.Add(attr.SpecialOpCode, new List<Detector>() { callback });
				else
				{
					//Console.WriteLine ("[WARNING] More than one detector method found for special opcode {0}", attr.SpecialOpCode);
					_specialDetectors[attr.SpecialOpCode].Add(callback);
				}
			}
			else
			{
				if (!_detectors.ContainsKey(attr.OpCode))
					_detectors.Add(attr.OpCode, new List<Detector>() { callback });
				else
				{
					//Console.WriteLine ("[WARNING] More than one detector method found for CIL opcode {0}", attr.OpCode);
					_detectors[attr.OpCode].Add(callback);
				}
			}
		}

		/// <inheritdoc/>
		public override Code Identify(VirtualOpCode instruction)
		{
			foreach (var kvp in _detectors)
			{
				foreach (var det in kvp.Value) { 
					if (det(instruction))
						return kvp.Key;
                }
            }

			throw new OriginalOpcodeUnknownException(instruction);
		}

		/// <inheritdoc/>
		public override DetectAttribute IdentifyFull(VirtualOpCode instruction)
		{
			foreach (var kvp in _detectors)
            {
				foreach (var det in kvp.Value)
				{
					if (det(instruction))
						return (DetectAttribute)det.Method.GetCustomAttribute(typeof(DetectAttribute));
				}
			}

			foreach (var kvp in _specialDetectors)
            {
				foreach (var det in kvp.Value)
				{
					if (det(instruction))
						return (DetectAttribute)det.Method.GetCustomAttribute(typeof(DetectAttribute));
				}
			}

			throw new OriginalOpcodeUnknownException(instruction);
		}
	}
}
