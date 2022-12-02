using System;
using System.Linq;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using eazdevirt.Reflection;
using eazdevirt.Util;

namespace eazdevirt.Detection.V1.Ext
{
    public static partial class Extensions
    {
        [Detect(Code.Switch)]
        public static Boolean Is_Switch_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineSwitch) return false;
            return true;
        }
        [Detect(Code.Ceq)]
        public static Boolean Is_Ceq_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Brtrue_S, Code.Ldc_I4_0, Code.Br_S, Code.Ldc_I4_1, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[3].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_S, Code.Ldloc_S, Code.Switch, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Stloc_3, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Bne_Un_S, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Ceq, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_6, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_6, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_6, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldc_I8, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_6, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_6, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Stloc_1, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldloc_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_1, Code.Callvirt, Code.Ldnull, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Brfalse, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldloc_S, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloca_S, Code.Ldloc_2, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldloc_S, Code.Callvirt, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Blt_Un_S)]
        public static Boolean Is_Blt_Un_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineBrTarget) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Ldloc_0, Code.Call, Code.Brfalse_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Sub, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Blt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Bgt_S)]
        public static Boolean Is_Bgt_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineBrTarget) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Ldloc_0, Code.Call, Code.Brfalse_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Sub, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Ldloc_3, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Cgt)]
        public static Boolean Is_Cgt_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Brtrue_S, Code.Ldc_I4_0, Code.Br_S, Code.Ldc_I4_1, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[3].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Sub, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Ldloc_3, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ble_Un_S)]
        public static Boolean Is_Ble_Un_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineBrTarget) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_2, Code.Br_S, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_2, Code.Ldloc_2, Code.Brfalse_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_0, Code.Ldloc_3, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[3].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Sub, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Ldloc_3, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Bge_Un_S)]
        public static Boolean Is_Bge_Un_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineBrTarget) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Ldloc_0, Code.Call, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Sub, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Blt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Clt_Un)]
        public static Boolean Is_Clt_Un_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Brtrue_S, Code.Ldc_I4_0, Code.Br_S, Code.Ldc_I4_1, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[3].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Sub, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Blt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldelema)]
        public static Boolean Is_Ldelema_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineType) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Stloc_2, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_3, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_3, Code.Callvirt, Code.Dup, Code.Ldloc_1, Code.Callvirt, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Initobj)]
        public static Boolean Is_Initobj_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineType) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_0, Code.Ldloc_S, Code.Ldc_I4_1, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Castclass, Code.Stloc_2, Code.Ldloc_0, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Callvirt, Code.Stloc_S, Code.Ldloc_0, Code.Call, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Callvirt, Code.Call, Code.Ret, Code.Ldloc_0, Code.Ldc_I4_S, Code.Callvirt, Code.Stloc_3, Code.Ldc_I4_0, Code.Stloc_1, Code.Br_S, Code.Ldloc_3, Code.Ldloc_1, Code.Ldelem, Code.Stloc_S, Code.Ldloc_S, Code.Ldloc_S, Code.Ldloc_S, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldloc_1, Code.Ldc_I4_1, Code.Add, Code.Stloc_1, Code.Ldloc_1, Code.Ldloc_3, Code.Ldlen, Code.Conv_I4, Code.Blt_S, Code.Ret, Code.Ldarg_0, Code.Ldloc_2, Code.Newobj, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stelem)]
        public static Boolean Is_Stelem_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineType) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_2, Code.Ldarg_0, Code.Ldarg_1, Code.Ldloc_0, Code.Ldloc_1, Code.Ldloc_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldelem)]
        public static Boolean Is_Ldelem_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineType) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldobj)]
        public static Boolean Is_Ldobj_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineType) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
    }
}
