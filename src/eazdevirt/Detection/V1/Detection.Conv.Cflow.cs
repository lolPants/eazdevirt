using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using eazdevirt.Reflection;
using eazdevirt.Util;

namespace eazdevirt.Detection.V1.Ext
{
	public static partial class Extensions
	{
		/// <summary>
		/// OpCode pattern seen at the end of Conv_* helper methods.
		/// Also seen in Conv_*_Un delegate methods.
		/// </summary>
		private static readonly Code[] Pattern_Conv_Helper_Tail_Codeflow = new Code[] {
			Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2,
			Code.Callvirt, Code.Call, Code.Ret
		};

		private static Code[] Conv_Helper_Pattern_Codeflow(params Code[] opcodes)
		{
			var list = new List<Code>(opcodes);
			list.AddRange(Pattern_Conv_Helper_Tail_Codeflow);
			return list.ToArray();
		}

		private static Boolean _Is_Conv_I_Codeflow(VirtualOpCode ins, Boolean ovf, IList<Code> helperPattern)
		{
			Code[] delegatePattern = (ovf ?
				new Code[] { Code.Ldarg_0, Code.Ldc_I4_1, Code.Call, Code.Ret } :
				new Code[] { Code.Ldarg_0, Code.Ldc_I4_0, Code.Call, Code.Ret });

			return ins.DelegateMethod.MatchesEntire(delegatePattern)
				&& ins.DelegateMethod.MatchesIndirect(helperPattern);
		}

		/// <summary>
		/// OpCode pattern seen in Conv_I, Conv_Ovf_I helper methods.
		/// </summary>
		private static readonly Code[] Pattern_Conv_I_Codeflow = Conv_Helper_Pattern_Codeflow(Code.Conv_I8, Code.Call, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Br_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call);

		[Detect(Code.Conv_I)]
		public static Boolean Is_Conv_I_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, false, Pattern_Conv_I_Codeflow);
		}

		[Detect(Code.Conv_Ovf_I)]
		public static Boolean Is_Conv_Ovf_I_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Pattern_Conv_I_Codeflow);
		}

		/// <summary>
		/// OpCode pattern seen in Conv_I1, Conv_Ovf_I1 helper methods.
		/// </summary>
		private static readonly Code[] Pattern_Conv_I1_Codeflow = Conv_Helper_Pattern_Codeflow(Code.Conv_I1, Code.Stloc_2);

		[Detect(Code.Conv_I1)]
		public static Boolean Is_Conv_I1_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, false, Pattern_Conv_I1_Codeflow);
		}

		[Detect(Code.Conv_Ovf_I1)]
		public static Boolean Is_Conv_Ovf_I1_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Pattern_Conv_I1_Codeflow);
		}

		/// <summary>
		/// OpCode pattern seen in Conv_I2, Conv_Ovf_I2 helper methods.
		/// </summary>
		private static readonly Code[] Pattern_Conv_I2_Codeflow = Conv_Helper_Pattern_Codeflow(Code.Conv_I2, Code.Stloc_2);

		[Detect(Code.Conv_I2)]
		public static Boolean Is_Conv_I2_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, false, Pattern_Conv_I2_Codeflow);
		}

		[Detect(Code.Conv_Ovf_I2)]
		public static Boolean Is_Conv_Ovf_I2_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Pattern_Conv_I2_Codeflow);
		}

		/// <summary>
		/// OpCode pattern seen in Conv_I8, Conv_Ovf_I8 helper methods.
		/// </summary>
		private static readonly Code[] Pattern_Conv_I8_Codeflow = Conv_Helper_Pattern_Codeflow(Code.Conv_I8, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2);

		[Detect(Code.Conv_I8)]
		public static Boolean Is_Conv_I8_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, false, Pattern_Conv_I8_Codeflow);
		}

		[Detect(Code.Conv_Ovf_I8)]
		public static Boolean Is_Conv_Ovf_I8_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Pattern_Conv_I8_Codeflow);
		}

		[Detect(Code.Conv_Ovf_I_Un)]
		public static Boolean Is_Conv_Ovf_I_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Conv_Ovf_I8_Un, Code.Call));
		}

		[Detect(Code.Conv_Ovf_I1_Un)]
		public static Boolean Is_Conv_Ovf_I1_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Conv_Ovf_I1_Un, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_I2_Un)]
		public static Boolean Is_Conv_Ovf_I2_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Conv_Ovf_I2_Un, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_I4_Un)]
		public static Boolean Is_Conv_Ovf_I4_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Conv_Ovf_I4_Un, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_I8_Un)]
		public static Boolean Is_Conv_Ovf_I8_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Conv_Ovf_I8_Un, Code.Stloc_2));
		}

		/// <summary>
		/// OpCode pattern seen in Conv_Ovf_U helper method and Conv_Ovf_U_Un delegate method.
		/// </summary>
		private static readonly Code[] Pattern_Conv_Ovf_U_Codeflow = Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Call, Code.Br_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call);
        

        [Detect(Code.Conv_U)]
		public static Boolean Is_Conv_U_Codeflow(this VirtualOpCode ins)
        {
            return _Is_Conv_I_Codeflow(ins, false, Pattern_Conv_Ovf_U_Codeflow);
		}

		[Detect(Code.Conv_Ovf_U)]
		public static Boolean Is_Conv_Ovf_U_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Pattern_Conv_Ovf_U_Codeflow);
		}

		[Detect(Code.Conv_Ovf_U_Un)]
		public static Boolean Is_Conv_Ovf_U_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_U8, Code.Call, Code.Br_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call));
		}

		[Detect(Code.Conv_U1)]
		public static Boolean Is_Conv_U1_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, false, Conv_Helper_Pattern_Codeflow(Code.Conv_U1, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_U1)]
		public static Boolean Is_Conv_Ovf_U1_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Conv_Helper_Pattern_Codeflow(Code.Conv_U1, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_U1_Un)]
		public static Boolean Is_Conv_Ovf_U1_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Conv_Ovf_U1_Un, Code.Stloc_2));
		}

		[Detect(Code.Conv_U2)]
		public static Boolean Is_Conv_U2_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, false, Conv_Helper_Pattern_Codeflow(Code.Conv_U2, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_U2)]
		public static Boolean Is_Conv_Ovf_U2_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Conv_Helper_Pattern_Codeflow(Code.Conv_U2, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_U2_Un)]
		public static Boolean Is_Conv_Ovf_U2_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Conv_Ovf_U2_Un, Code.Stloc_2));
		}

		[Detect(Code.Conv_U4)]
		public static Boolean Is_Conv_Ovf_U4_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, false, Conv_Helper_Pattern_Codeflow(Code.Conv_U4, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_U4)]
		public static Boolean Is_Conv_U4_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Conv_Helper_Pattern_Codeflow(Code.Conv_U4, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_U4_Un)]
		public static Boolean Is_Conv_Ovf_U4_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Conv_Ovf_U4_Un, Code.Stloc_2));
		}

		[Detect(Code.Conv_U8)]
		public static Boolean Is_Conv_U8_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, false, Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_U8)]
		public static Boolean Is_Conv_Ovf_U8_Codeflow(this VirtualOpCode ins)
		{
			return _Is_Conv_I_Codeflow(ins, true, Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2));
		}

		[Detect(Code.Conv_Ovf_U8_Un)]
		public static Boolean Is_Conv_Ovf_U8_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_Ovf_U8, Code.Stloc_2));
		}

		[Detect(Code.Conv_R_Un)]
		public static Boolean Is_Conv_R_Un_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_R_Un, Code.Conv_R8, Code.Stloc_2));
		}

		[Detect(Code.Conv_R8)]
		public static Boolean Is_Conv_R8_Codeflow(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Matches(Conv_Helper_Pattern_Codeflow(Code.Conv_R8, Code.Stloc_2));
		}
	}
}
