using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using eazdevirt.Reflection;
using eazdevirt.Util;
using System.Linq;

namespace eazdevirt.Detection.V1.Ext
{
	public static partial class Extensions
	{
		[Detect(Code.And)]
		public static Boolean Is_And(this VirtualOpCode ins)
		{
			return ins.DelegateMethod.Calls().Count() == 4 &&
				ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef().Matches(Code.Ldloc_S, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret);
		}

		[Detect(Code.Xor)]
		public static Boolean Is_Xor(this VirtualOpCode ins)
		{
            return ins.DelegateMethod.Calls().Count() == 4 &&
                ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef().Matches(Code.Ldloc_S, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret);
        }

		[Detect(Code.Shl)]
		public static Boolean Is_Shl(this VirtualOpCode ins)
		{
            return ins.DelegateMethod.Calls().Count() == 4 &&
                ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef().Matches(Code.Ldloc_1, Code.Ldc_I4_S, Code.And, Code.Shl, Code.Stloc_2);
        }

		/// <summary>
		/// OpCode pattern seen in the Shr_* helper method.
		/// </summary>
		private static readonly Code[] Pattern_Shr = new Code[] {
			Code.Ldc_I4_S, Code.And, Code.Shr, Code.Callvirt, Code.Ldloc_0, Code.Ret
		};

		[Detect(Code.Shr)]
		public static Boolean Is_Shr(this VirtualOpCode ins)
        {
            return ins.DelegateMethod.Calls().Count() == 4 &&
                ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef().Matches(Code.Ldloc_2, Code.Ldc_I4_S, Code.And, Code.Shr, Code.Callvirt) &&
				ins.DelegateMethod.Body.Instructions[10].OpCode.Code == Code.Ldc_I4_0;
        }

		[Detect(Code.Shr_Un)]
		public static Boolean Is_Shr_Un(this VirtualOpCode ins)
		{
			//return ins.MatchesIndirectWithBoolean(false, Pattern_Shr);
			
            return ins.DelegateMethod.Calls().Count() == 4 &&
                ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef().Matches(Code.Ldloc_2, Code.Ldc_I4_S, Code.And, Code.Shr, Code.Callvirt) &&
				ins.DelegateMethod.Body.Instructions[10].OpCode.Code == Code.Ldc_I4_1;
		}

		[Detect(Code.Or)]
		public static Boolean Is_Or(this VirtualOpCode ins)
		{
			/*return ins.MatchesIndirect(new Code[] {
				Code.Ldloc_S, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ldloc_0, Code.Ret
			});*/
            return ins.DelegateMethod.Calls().Count() == 4 &&
                ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef().Matches(Code.Ldloc_S, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret);
        }

		[Detect(Code.Not)]
		public static Boolean Is_Not(this VirtualOpCode ins)
		{
            /*return ins.DelegateMethod.MatchesIndirect(new Code[] {
				Code.Ldloc_1, Code.Ldloc_S, Code.Not, Code.Callvirt, Code.Ldloc_1, Code.Ret
			});*/

            return ins.DelegateMethod.Calls().Count() == 4 &&
                ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef().Matches(Code.Ldloc_S, Code.Ldloc_S, Code.Not, Code.Callvirt, Code.Ret);
        }
	}
}
