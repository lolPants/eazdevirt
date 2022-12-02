using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using eazdevirt.Reflection;
using eazdevirt.Util;

namespace eazdevirt.Detection.V1.Ext
{
    public static partial class Extensions
    {
        [Detect(Code.Call)]
        public static Boolean Is_Call_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Ldc_I4_0, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Callvirt)]
        public static Boolean Is_Callvirt_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldarg_0, Code.Ldloc_S, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Ldfld, Code.Brfalse_S, Code.Ldloc_0, Code.Callvirt, Code.Dup, Code.Ldlen, Code.Conv_I4, Code.Newarr, Code.Stloc_2, Code.Ldc_I4_0, Code.Stloc_3, Code.Stloc_S, Code.Ldc_I4_0, Code.Stloc_1, Code.Br_S, Code.Ldloc_S, Code.Ldloc_1, Code.Ldelem, Code.Stloc_S, Code.Ldloc_2, Code.Ldloc_3, Code.Dup, Code.Ldc_I4_1, Code.Add, Code.Stloc_3, Code.Ldloc_S, Code.Callvirt, Code.Stelem_Ref, Code.Ldloc_1, Code.Ldc_I4_1, Code.Add, Code.Stloc_1, Code.Ldloc_1, Code.Ldloc_S, Code.Ldlen, Code.Conv_I4, Code.Blt_S, Code.Ldarg_0, Code.Ldfld, Code.Ldloc_0, Code.Callvirt, Code.Ldc_I4, Code.Ldnull, Code.Ldloc_2, Code.Ldnull, Code.Callvirt, Code.Stloc_S, Code.Ldloc_S, Code.Brfalse_S, Code.Ldloc_S, Code.Stloc_0, Code.Ldarg_0, Code.Ldnull, Code.Stfld, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Newobj)]
        public static Boolean Is_Newobj_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_0, Code.Ldloc_S, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Callvirt, Code.Stloc_S, Code.Ldloc_2, Code.Callvirt, Code.Stloc_S, Code.Ldloc_S, Code.Ldlen, Code.Conv_I4, Code.Dup, Code.Newarr, Code.Stloc_3, Code.Newobj, Code.Stloc_S, Code.Ldc_I4_1, Code.Sub, Code.Stloc_1, Code.Br_S, Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Brfalse_S, Code.Ldloc_S, Code.Ldloc_1, Code.Ldloc_0, Code.Callvirt, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Brfalse_S, Code.Ldnull, Code.Ldloc_0, Code.Callvirt, Code.Call, Code.Ldloc_0, Code.Callvirt, Code.Stloc_0, Code.Ldnull, Code.Ldloc_S, Code.Ldloc_1, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ldloc_0, Code.Callvirt, Code.Stloc_S, Code.Ldloc_3, Code.Ldloc_1, Code.Ldloc_S, Code.Callvirt, Code.Stelem_Ref, Code.Ldloc_1, Code.Ldc_I4_1, Code.Sub, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_0, Code.Bge_S, Code.Ldarg_0, Code.Ldloc_2, Code.Ldnull, Code.Ldloc_3, Code.Ldc_I4_0, Code.Call, Code.Stloc_S, Code.Leave_S, Code.Stloc_S, Code.Ldloc_S, Code.Callvirt, Code.Dup, Code.Brtrue_S, Code.Pop, Code.Ldloc_S, Code.Stloc_S, Code.Ldarg_0, Code.Ldloc_S, Code.Call, Code.Leave_S, Code.Ldloc_S, Code.Callvirt, Code.Stloc_S, Code.Nop, Code.Br_S, Code.Ldloca_S, Code.Call, Code.Stloc_S, Code.Ldarg_0, Code.Ldloca_S, Code.Call, Code.Ldloc_3, Code.Ldloca_S, Code.Call, Code.Ldelem_Ref, Code.Ldnull, Code.Call, Code.Call, Code.Ldloca_S, Code.Call, Code.Brtrue_S, Code.Leave_S, Code.Ldloca_S, Code.Constrained, Code.Callvirt, Code.Endfinally, Code.Ldarg_0, Code.Ldloc_S, Code.Ldloc_S, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stloc_0)]
        public static Boolean Is_Stloc_0_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Isinst, Code.Brfalse_S, Code.Ldarg_0, Code.Ldfld, Code.Ldarg_1, Code.Ldloc_0, Code.Stelem, Code.Ret, Code.Ldarg_0, Code.Ldfld, Code.Ldarg_1, Code.Ldelem, Code.Ldloc_0, Code.Callvirt, Code.Pop, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stloc_1)]
        public static Boolean Is_Stloc_1_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_1, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Isinst, Code.Brfalse_S, Code.Ldarg_0, Code.Ldfld, Code.Ldarg_1, Code.Ldloc_0, Code.Stelem, Code.Ret, Code.Ldarg_0, Code.Ldfld, Code.Ldarg_1, Code.Ldelem, Code.Ldloc_0, Code.Callvirt, Code.Pop, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldloc_0)]
        public static Boolean Is_Ldloc_0_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldc_I4_0, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[2].Operand).MDToken != ins.VType.LocalsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Stloc_2)]
        public static Boolean Is_Stloc_2_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldloc_1)]
        public static Boolean Is_Ldloc_1_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldc_I4_1, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[2].Operand).MDToken != ins.VType.LocalsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Ldloc_2)]
        public static Boolean Is_Ldloc_2_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldc_I4_2, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[2].Operand).MDToken != ins.VType.LocalsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4)]
        public static Boolean Is_Ldc_I4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineI) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_1, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldsfld)]
        public static Boolean Is_Ldsfld_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Ldnull, Code.Callvirt, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stloc_3)]
        public static Boolean Is_Stloc_3_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_3, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Leave_S)]
        public static Boolean Is_Leave_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineBrTarget) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldnull, Code.Ldloc_0, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Brfalse_S)]
        public static Boolean Is_Brfalse_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineBrTarget) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldc_I4_0, Code.Stloc_1, Code.Ldloc_0, Code.Callvirt, Code.Stloc_2, Code.Ldloc_2, Code.Ldc_I4_S, Code.Bgt_S, Code.Ldloc_2, Code.Ldc_I4_5, Code.Sub, Code.Switch, Code.Ldloc_2, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldnull, Code.Ceq, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldc_I8, Code.Ceq, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_1, Code.Br_S, Code.Ldloc_2, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_2, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_0, Code.Callvirt, Code.Ldnull, Code.Ceq, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Brfalse_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_0, Code.Ldloc_3, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Endfinally)]
        public static Boolean Is_Endfinally_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldfld, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Ldfld, Code.Brfalse_S, Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Call, Code.Ret, Code.Ldarg_0, Code.Ldfld, Code.Callvirt, Code.Stloc_0, Code.Ldloca_S, Code.Call, Code.Brfalse_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloca_S, Code.Call, Code.Callvirt, Code.Call, Code.Br_S, Code.Ldarg_0, Code.Ldfld, Code.Callvirt, Code.Ldarg_0, Code.Ldloca_S, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldloc_3)]
        public static Boolean Is_Ldloc_3_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldc_I4_3, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[2].Operand).MDToken != ins.VType.LocalsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Ret)]
        public static Boolean Is_Ret_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_1, Code.Stfld, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldarg_0)]
        public static Boolean Is_Ldarg_0_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldc_I4_0, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[2].Operand).MDToken != ins.VType.ArgumentsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Ldarg_1)]
        public static Boolean Is_Ldarg_1_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldc_I4_1, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[2].Operand).MDToken != ins.VType.ArgumentsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Ldarg_2)]
        public static Boolean Is_Ldarg_2_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldc_I4_2, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[2].Operand).MDToken != ins.VType.ArgumentsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Ldarg_3)]
        public static Boolean Is_Ldarg_3_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldc_I4_3, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[2].Operand).MDToken != ins.VType.ArgumentsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Ldarg_S)]
        public static Boolean Is_Ldarg_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineVar) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldloc_0, Code.Callvirt, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[5].Operand).MDToken != ins.VType.ArgumentsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Pop)]
        public static Boolean Is_Pop_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Pop, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_0)]
        public static Boolean Is_Ldc_I4_0_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_0, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Dup)]
        public static Boolean Is_Dup_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Ldarg_0, Code.Ldloc_1, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stfld)]
        public static Boolean Is_Stfld_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Ldarg_0, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Callvirt, Code.Stloc_3, Code.Br_S, Code.Ldloc_2, Code.Callvirt, Code.Stloc_3, Code.Ldloc_3, Code.Brtrue_S, Code.Newobj, Code.Throw, Code.Callvirt, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_1, Code.Ldloc_3, Code.Ldloc_S, Code.Callvirt, Code.Callvirt, Code.Ldloc_2, Code.Callvirt, Code.Brfalse_S, Code.Ldloc_3, Code.Brfalse_S, Code.Ldloc_3, Code.Callvirt, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Ldloc_3, Code.Ldnull, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldnull)]
        public static Boolean Is_Ldnull_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_8)]
        public static Boolean Is_Ldc_I4_8_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_8, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stsfld)]
        public static Boolean Is_Stsfld_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Stloc_2, Code.Ldloc_1, Code.Ldnull, Code.Ldloc_2, Code.Callvirt, Code.Callvirt, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_1)]
        public static Boolean Is_Ldc_I4_1_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_1, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Brtrue_S)]
        public static Boolean Is_Brtrue_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineBrTarget) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldc_I4_0, Code.Stloc_1, Code.Ldloc_0, Code.Callvirt, Code.Stloc_2, Code.Ldloc_2, Code.Ldc_I4_S, Code.Bgt_S, Code.Ldloc_2, Code.Ldc_I4_5, Code.Sub, Code.Switch, Code.Ldloc_2, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldnull, Code.Cgt_Un, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldc_I8, Code.Cgt_Un, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldc_I4_0, Code.Cgt_Un, Code.Stloc_1, Code.Br_S, Code.Ldloc_2, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_2, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_0, Code.Callvirt, Code.Ldnull, Code.Cgt_Un, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Brfalse_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_0, Code.Ldloc_3, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_R4)]
        public static Boolean Is_Ldc_R4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineR) return false;
            return true;
        }
        [Detect(Code.Beq_S)]
        public static Boolean Is_Beq_S_Generated(this VirtualOpCode ins)
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_S, Code.Ldloc_S, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Stloc_3, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Bne_Un_S, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Ceq, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldc_I8, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldloc_S, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloca_S, Code.Ldloc_2, Code.Call, Code.Stloc_0, Code.Br, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldloc_S, Code.Callvirt, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Stloc_1, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_1, Code.Callvirt, Code.Ldnull, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Brfalse_S, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldfld)]
        public static Boolean Is_Ldfld_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Callvirt, Code.Stloc_3, Code.Ldloc_3, Code.Brtrue_S, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldloca_S)]
        public static Boolean Is_Ldloca_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineVar) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Callvirt, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Initobj)]
        public static Boolean Is_Initobj_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_0, Code.Ldloc_S, Code.Ldc_I4_1, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_2, Code.Ldloc_0, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Callvirt, Code.Stloc_S, Code.Ldloc_0, Code.Call, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Callvirt, Code.Call, Code.Ret, Code.Ldloc_0, Code.Ldc_I4_S, Code.Callvirt, Code.Stloc_3, Code.Ldc_I4_0, Code.Stloc_1, Code.Br_S, Code.Ldloc_3, Code.Ldloc_1, Code.Ldelem, Code.Stloc_S, Code.Ldloc_S, Code.Ldloc_S, Code.Ldloc_S, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldloc_1, Code.Ldc_I4_1, Code.Add, Code.Stloc_1, Code.Ldloc_1, Code.Ldloc_3, Code.Ldlen, Code.Conv_I4, Code.Blt_S, Code.Ret, Code.Ldarg_0, Code.Ldloc_2, Code.Newobj, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Add)]
        public static Boolean Is_Add_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Ldc_I4_0, Code.Ldc_I4_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_S, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldarg_3, Code.Brfalse_S, Code.Ldloc_0, Code.Ldloc_1, Code.Add_Ovf, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Ldloc_1, Code.Add, Code.Stloc_2, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_3, Code.Brfalse_S, Code.Ldloc_3, Code.Ldloc_S, Code.Add_Ovf_Un, Code.Stloc_S, Code.Br_S, Code.Ldloc_3, Code.Ldloc_S, Code.Add, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Add, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Br_S)]
        public static Boolean Is_Br_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineBrTarget) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Bge_S)]
        public static Boolean Is_Bge_S_Generated(this VirtualOpCode ins)
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldsflda)]
        public static Boolean Is_Ldsflda_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[1].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldsfld, Code.Stloc_1, Code.Ldloc_1, Code.Call, Code.Ldc_I4_1, Code.Stloc_2, Code.Ldsfld, Code.Ldarg_1, Code.Ldloca_S, Code.Callvirt, Code.Brfalse_S, Code.Ldloc_S, Code.Castclass, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Ldarg_1, Code.Call, Code.Stloc_3, Code.Ldarg_0, Code.Ldarg_1, Code.Ldloc_3, Code.Ldloca_S, Code.Call, Code.Stloc_0, Code.Ldloc_2, Code.Brfalse_S, Code.Ldsfld, Code.Ldarg_1, Code.Ldloc_0, Code.Callvirt, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Ldloc_0, Code.Stloc_S, Code.Leave_S, Code.Ldloc_1, Code.Call, Code.Endfinally, Code.Ldloc_S, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldftn)]
        public static Boolean Is_Ldftn_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Castclass)]
        public static Boolean Is_Castclass_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Stloc_2, Code.Ldarg_0, Code.Ldloc_2, Code.Ldloc_1, Code.Call, Code.Brtrue_S, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stloc_S)]
        public static Boolean Is_Stloc_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineVar) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Constrained)]
        public static Boolean Is_Constrained_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stfld, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldloc_S)]
        public static Boolean Is_Ldloc_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineVar) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Ldarg_0, Code.Ldfld, Code.Ldloc_0, Code.Callvirt, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[5].Operand).MDToken != ins.VType.LocalsField.MDToken) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_S)]
        public static Boolean Is_Ldc_I4_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineI) return false;
            return true;
        }
        [Detect(Code.Unbox_Any)]
        public static Boolean Is_Unbox_Any_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Ldloc_1, Code.Call, Code.Stloc_2, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Isinst)]
        public static Boolean Is_Isinst_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Stloc_2, Code.Ldarg_0, Code.Ldloc_2, Code.Ldloc_1, Code.Call, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Ret, Code.Ldarg_0, Code.Newobj, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldlen)]
        public static Boolean Is_Ldlen_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Callvirt, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Conv_I4)]
        public static Boolean Is_Conv_I4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt_S, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Br, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_I4, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_I4, Code.Stloc_2, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_Ovf_I4_Un, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_I4, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_I4, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_I4, Code.Stloc_2, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Newarr)]
        public static Boolean Is_Newarr_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_0, Code.Ldloc_S, Code.Ldc_I4_1, Code.Call, Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Isinst, Code.Stloc_2, Code.Ldloc_2, Code.Brfalse_S, Code.Ldloc_2, Code.Callvirt, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Isinst, Code.Stloc_3, Code.Ldloc_3, Code.Brfalse_S, Code.Ldloc_3, Code.Callvirt, Code.Stloc_S, Code.Ldloca_S, Code.Call, Code.Stloc_1, Code.Br_S, Code.Ldloc_0, Code.Isinst, Code.Stloc_S, Code.Ldloc_S, Code.Brfalse_S, Code.Ldloc_S, Code.Callvirt, Code.Stloc_S, Code.Ldloca_S, Code.Call, Code.Stloc_1, Code.Br_S, Code.Newobj, Code.Throw, Code.Ldloc_1, Code.Call, Code.Stloc_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldelem_Ref)]
        public static Boolean Is_Ldelem_Ref_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldsfld, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[1].Operand).MDToken == ins.VType.GetTypeField("System.IntPtr").MDToken) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stelem_Ref)]
        public static Boolean Is_Stelem_Ref_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldsfld, Code.Call, Code.Ret)) return false;
                if (((FieldDef)method.Body.Instructions[1].Operand).MDToken == ins.VType.GetTypeField("System.IntPtr").MDToken) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_2, Code.Ldarg_0, Code.Ldarg_1, Code.Ldloc_0, Code.Ldloc_1, Code.Ldloc_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Blt_S)]
        public static Boolean Is_Blt_S_Generated(this VirtualOpCode ins)
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldtoken)]
        public static Boolean Is_Ldtoken_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Callvirt, Code.Ldc_I4_1, Code.Bne_Un_S, Code.Ldarg_0, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Stloc_2, Code.Br_S, Code.Ldloc_1, Code.Callvirt, Code.Callvirt, Code.Stloc_3, Code.Ldloc_3, Code.Ldc_I4_1, Code.Sub, Code.Switch, Code.Br_S, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Callvirt, Code.Box, Code.Stloc_2, Code.Br_S, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Callvirt, Code.Box, Code.Stloc_2, Code.Br_S, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Callvirt, Code.Box, Code.Stloc_2, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stelem_I2)]
        public static Boolean Is_Stelem_I2_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_2, Code.Ldloc_2, Code.Callvirt, Code.Callvirt, Code.Stloc_3, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Call, Code.Stloc_S, Code.Ldloc_2, Code.Castclass, Code.Ldloc_1, Code.Conv_Ovf_I, Code.Ldloc_S, Code.Callvirt, Code.Unbox_Any, Code.Stelem_I2, Code.Ret, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Call, Code.Stloc_S, Code.Ldloc_2, Code.Castclass, Code.Ldloc_1, Code.Conv_Ovf_I, Code.Ldloc_S, Code.Callvirt, Code.Unbox_Any, Code.Stelem_I2, Code.Ret, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Call, Code.Stloc_S, Code.Ldloc_2, Code.Castclass, Code.Ldloc_1, Code.Conv_Ovf_I, Code.Ldloc_S, Code.Callvirt, Code.Unbox_Any, Code.Stelem_I2, Code.Ret, Code.Ldloc_3, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_3, Code.Ldloc_0, Code.Ldloc_1, Code.Ldloc_2, Code.Call, Code.Ret, Code.Ldarg_0, Code.Ldtoken, Code.Call, Code.Ldloc_0, Code.Ldloc_1, Code.Ldloc_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_7)]
        public static Boolean Is_Ldc_I4_7_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_7, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Bne_Un_S)]
        public static Boolean Is_Bne_Un_S_Generated(this VirtualOpCode ins)
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_S, Code.Ldloc_S, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Stloc_3, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Bne_Un_S, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Ceq, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldc_I8, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldloc_S, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloca_S, Code.Ldloc_2, Code.Call, Code.Stloc_0, Code.Br, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldloc_S, Code.Callvirt, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Stloc_1, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_1, Code.Callvirt, Code.Ldnull, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Brfalse_S, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_6)]
        public static Boolean Is_Ldc_I4_6_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_6, Code.Callvirt, Code.Call, Code.Ret)) return false;
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Ldloc_3, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_2)]
        public static Boolean Is_Ldc_I4_2_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_3)]
        public static Boolean Is_Ldc_I4_3_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_3, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_4)]
        public static Boolean Is_Ldc_I4_4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_4, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_5)]
        public static Boolean Is_Ldc_I4_5_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_5, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Box)]
        public static Boolean Is_Box_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Ldloc_1, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Ldloc_1, Code.Callvirt, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Switch)]
        public static Boolean Is_Switch_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineSwitch) return false;
            return true;
        }
        [Detect(Code.Ldelem_U1)]
        public static Boolean Is_Ldelem_U1_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldtoken, Code.Call, Code.Call, Code.Ret)) return false;
                if (((ITypeDefOrRef)method.Body.Instructions[1].Operand).FullName != "System.Byte") return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[1].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_I4_M1)]
        public static Boolean Is_Ldc_I4_M1_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldc_I4_M1, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ble_S)]
        public static Boolean Is_Ble_S_Generated(this VirtualOpCode ins)
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Bgt, Code.Ldloc_1, Code.Brfalse, Code.Ldloc_1, Code.Ldc_I4_5, Code.Sub, Code.Switch, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Bgt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Stloc_S, Code.Br_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldc_R8)]
        public static Boolean Is_Ldc_R8_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineR) return false;
            return true;
        }
        [Detect(Code.Ble_Un)]
        public static Boolean Is_Ble_Un_Generated(this VirtualOpCode ins)
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Ldloc_3, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stind_I, ExpectsMultiple = true)]
        public static Boolean Is_Stind_I_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Nop, ExpectsMultiple = true)]
        public static Boolean Is_Nop_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldarga_S)]
        public static Boolean Is_Ldarga_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineVar) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Ldfld, Code.Ldloc_0, Code.Callvirt, Code.Ldelem, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Rem)]
        public static Boolean Is_Rem_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Ldc_I4_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_3, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_3, Code.Ldloc_S, Code.Rem, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Rem_Un, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Rem, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_2, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Sub)]
        public static Boolean Is_Sub_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Ldc_I4_0, Code.Ldc_I4_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_S, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldarg_3, Code.Brfalse_S, Code.Ldloc_0, Code.Ldloc_1, Code.Sub_Ovf, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Ldloc_1, Code.Sub, Code.Stloc_2, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_3, Code.Brfalse_S, Code.Ldloc_3, Code.Ldloc_S, Code.Sub_Ovf_Un, Code.Stloc_S, Code.Br_S, Code.Ldloc_3, Code.Ldloc_S, Code.Sub, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Sub, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.And)]
        public static Boolean Is_And_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Conv_I8, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Conv_I8, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_3, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_2, Code.And, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_2, Code.Conv_I8, Code.And, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.And, Code.Callvirt, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Mul)]
        public static Boolean Is_Mul_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Ldc_I4_0, Code.Ldc_I4_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_S, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldarg_3, Code.Brfalse_S, Code.Ldloc_0, Code.Ldloc_1, Code.Mul_Ovf, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Ldloc_1, Code.Mul, Code.Stloc_2, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_3, Code.Brfalse_S, Code.Ldloc_3, Code.Ldloc_S, Code.Mul_Ovf_Un, Code.Stloc_S, Code.Br_S, Code.Ldloc_3, Code.Ldloc_S, Code.Mul, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Mul, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Ldarg_S, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Shr)]
        public static Boolean Is_Shr_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Ldc_I4_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_3, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Newobj, Code.Dup, Code.Ldloc_1, Code.Ldloc_2, Code.Ldc_I4_S, Code.And, Code.Shr, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_3, Code.Ldloc_S, Code.Ldc_I4_S, Code.And, Code.Shr_Un, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_3, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Ldc_I4_S, Code.And, Code.Shr, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Ldc_I4_S, Code.And, Code.Shr_Un, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Shl)]
        public static Boolean Is_Shl_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.And, Code.Shl, Code.Stloc_2, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_3, Code.Ldc_I4_S, Code.And, Code.Shl, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Conv_U1)]
        public static Boolean Is_Conv_U1_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt_S, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U4, Code.Conv_Ovf_U1_Un, Code.Stloc_2, Code.Br, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U1, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U8, Code.Conv_Ovf_U1_Un, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U1, Code.Stloc_2, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_Ovf_U1_Un, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_U1, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U1, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U1, Code.Stloc_2, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Xor)]
        public static Boolean Is_Xor_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Conv_I8, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Conv_I8, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_3, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_2, Code.Xor, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_2, Code.Conv_I8, Code.Xor, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Xor, Code.Callvirt, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stelem_I1)]
        public static Boolean Is_Stelem_I1_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_2, Code.Ldloc_2, Code.Callvirt, Code.Callvirt, Code.Stloc_3, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Call, Code.Stloc_S, Code.Ldloc_2, Code.Castclass, Code.Ldloc_1, Code.Conv_Ovf_I, Code.Ldloc_S, Code.Callvirt, Code.Unbox_Any, Code.Stelem_I1, Code.Ret, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Call, Code.Stloc_S, Code.Ldloc_2, Code.Castclass, Code.Ldloc_1, Code.Conv_Ovf_I, Code.Ldloc_S, Code.Callvirt, Code.Unbox_Any, Code.Stelem_I1, Code.Ret, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Call, Code.Stloc_S, Code.Ldloc_2, Code.Castclass, Code.Ldloc_1, Code.Conv_Ovf_I, Code.Ldloc_S, Code.Callvirt, Code.Unbox_Any, Code.Stelem_I1, Code.Ret, Code.Ldloc_3, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_3, Code.Ldloc_0, Code.Ldloc_1, Code.Ldloc_2, Code.Call, Code.Ret, Code.Ldarg_0, Code.Ldtoken, Code.Call, Code.Ldloc_0, Code.Ldloc_1, Code.Ldloc_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Bgt_Un_S)]
        public static Boolean Is_Bgt_Un_S_Generated(this VirtualOpCode ins)
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Bgt, Code.Ldloc_1, Code.Brfalse, Code.Ldloc_1, Code.Ldc_I4_5, Code.Sub, Code.Switch, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Bgt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Stloc_S, Code.Br_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Conv_I8)]
        public static Boolean Is_Conv_I8_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt_S, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Stloc_2, Code.Br, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_Ovf_I8_Un, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_I8, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Stloc_2, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Conv_U8)]
        public static Boolean Is_Conv_U8_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt_S, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U4, Code.Conv_U8, Code.Stloc_2, Code.Br, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U8, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U8, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U8, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U8, Code.Stloc_2, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_S, Code.Ldloc_S, Code.Switch, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Stloc_3, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Bne_Un_S, Code.Ldloc_3, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Ceq, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldc_I8, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldloc_S, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloca_S, Code.Ldloc_2, Code.Call, Code.Stloc_0, Code.Br, Code.Ldc_I4_0, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Callvirt, Code.Ldloc_S, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Ldarg_1, Code.Castclass, Code.Stloc_S, Code.Ldloc_S, Code.Callvirt, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Newobj, Code.Call, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Stloc_1, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_1, Code.Callvirt, Code.Ldnull, Code.Ceq, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Brfalse_S, Code.Ldloc_1, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Ceq, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Blt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Shr_Un)]
        public static Boolean Is_Shr_Un_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_3, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_1, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Newobj, Code.Dup, Code.Ldloc_1, Code.Ldloc_2, Code.Ldc_I4_S, Code.And, Code.Shr, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_3, Code.Ldloc_S, Code.Ldc_I4_S, Code.And, Code.Shr_Un, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_3, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Ldc_I4_S, Code.And, Code.Shr, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Ldc_I4_S, Code.And, Code.Shr_Un, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Stelem_I4)]
        public static Boolean Is_Stelem_I4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_2, Code.Ldloc_2, Code.Callvirt, Code.Callvirt, Code.Stloc_3, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Call, Code.Stloc_S, Code.Ldloc_2, Code.Castclass, Code.Ldloc_1, Code.Conv_Ovf_I, Code.Ldloc_S, Code.Callvirt, Code.Unbox_Any, Code.Stelem_I4, Code.Ret, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Call, Code.Stloc_S, Code.Ldloc_2, Code.Castclass, Code.Ldloc_1, Code.Conv_Ovf_I, Code.Ldloc_S, Code.Callvirt, Code.Unbox_Any, Code.Stelem_I4, Code.Ret, Code.Ldloc_3, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_3, Code.Ldloc_0, Code.Ldloc_1, Code.Ldloc_2, Code.Call, Code.Ret, Code.Ldarg_0, Code.Ldtoken, Code.Call, Code.Ldloc_0, Code.Ldloc_1, Code.Ldloc_2, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldelem_U4)]
        public static Boolean Is_Ldelem_U4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldtoken, Code.Call, Code.Call, Code.Ret)) return false;
                if (((ITypeDefOrRef)method.Body.Instructions[1].Operand).FullName != "System.UInt32") return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[1].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Throw)]
        public static Boolean Is_Throw_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Callvirt, Code.Call, Code.Ret)) return false;
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Brtrue_S, Code.Ldloc_2, Code.Ldloc_3, Code.Cgt, Code.Stloc_0, Code.Br_S, Code.Ldc_I4_0, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Div_Un)]
        public static Boolean Is_Div_Un_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_3, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_3, Code.Ldloc_S, Code.Div, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Div_Un, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Div, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_2, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Or)]
        public static Boolean Is_Or_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_0, Code.Conv_I8, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Conv_I8, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_3, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_3, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_2, Code.Or, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_2, Code.Conv_I8, Code.Or, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_S, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Or, Code.Callvirt, Code.Ret)) return false;
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Blt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Starg_S)]
        public static Boolean Is_Starg_S_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.ShortInlineVar) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Stloc_0, Code.Ldarg_0, Code.Ldfld, Code.Ldloc_0, Code.Callvirt, Code.Ldelem, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Pop, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Conv_Ovf_I)]
        public static Boolean Is_Conv_Ovf_I_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_1, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt_S, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Br, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Br, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Br, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_Ovf_I8_Un, Code.Call, Code.Br_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Call, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_I8, Code.Call, Code.Br_S, Code.Ldloca_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Call, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Conv_U4)]
        public static Boolean Is_Conv_U4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt_S, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U4, Code.Stloc_2, Code.Br, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U2, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U4, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U4, Code.Stloc_2, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_Ovf_U4_Un, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_U4, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U4, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U4, Code.Stloc_2, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldelema)]
        public static Boolean Is_Ldelema_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Ldc_I4_1, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Stloc_2, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_3, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_3, Code.Callvirt, Code.Dup, Code.Ldloc_1, Code.Callvirt, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldflda)]
        public static Boolean Is_Ldflda_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Callvirt, Code.Brfalse_S, Code.Ldarg_0, Code.Ldloc_2, Code.Call, Code.Callvirt, Code.Stloc_3, Code.Br_S, Code.Ldloc_2, Code.Callvirt, Code.Stloc_3, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_1, Code.Callvirt, Code.Dup, Code.Ldloc_3, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Div)]
        public static Boolean Is_Div_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Stloc_1, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Ldc_I4_0, Code.Call, Code.Call, Code.Ret)) return false;
            }
            {
            }
            {
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[2].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_3, Code.Brtrue_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_3, Code.Ldloc_S, Code.Div, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Stloc_S, Code.Newobj, Code.Dup, Code.Ldloc_S, Code.Ldloc_S, Code.Div_Un, Code.Callvirt, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_0, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_7, Code.Bne_Un_S, Code.Ldarg_1, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_1, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_1, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Newobj, Code.Dup, Code.Ldarg_2, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_3, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_2, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ldarg_2, Code.Castclass, Code.Callvirt, Code.Div, Code.Callvirt, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Callvirt, Code.Call, Code.Stloc_2, Code.Ldloc_2, Code.Ldtoken, Code.Call, Code.Beq_S, Code.Ldloc_2, Code.Ldtoken, Code.Call, Code.Bne_Un_S, Code.Br_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret, Code.Newobj, Code.Throw, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_2, Code.Ldarg_3, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldind_U4)]
        public static Boolean Is_Ldind_U4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldtoken, Code.Call, Code.Call, Code.Ret)) return false;
                if (((ITypeDefOrRef)method.Body.Instructions[1].Operand).FullName != "System.UInt32") return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[1].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Call, Code.Ret)) return false;
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_S, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Callvirt, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Clt_Un, Code.Stloc_0, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br_S, Code.Newobj, Code.Dup, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Ret, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Blt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldelem)]
        public static Boolean Is_Ldelem_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
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
        [Detect(Code.Ldelem_I4)]
        public static Boolean Is_Ldelem_I4_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldtoken, Code.Call, Code.Call, Code.Ret)) return false;
                if (((ITypeDefOrRef)method.Body.Instructions[1].Operand).FullName != "System.Int32") return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[1].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Call, Code.Callvirt, Code.Castclass, Code.Stloc_1, Code.Ldarg_0, Code.Ldloc_1, Code.Ldloc_0, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Conv_U2)]
        public static Boolean Is_Conv_U2_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineNone) return false;
            {
                var method = ins.DelegateMethod;
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Ldc_I4_0, Code.Call, Code.Ret)) return false;
            }
            {
                var method = ins.DelegateMethod.Calls().ToList()[0].ResolveMethodDef();
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_8, Code.Bgt_S, Code.Ldloc_1, Code.Ldc_I4_7, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_8, Code.Beq_S, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U4, Code.Conv_Ovf_U2_Un, Code.Stloc_2, Code.Br, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U2, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U8, Code.Conv_Ovf_U2_Un, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U2, Code.Stloc_2, Code.Br_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Newobj, Code.Throw, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_Ovf_U2_Un, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Conv_U2, Code.Stloc_2, Code.Br_S, Code.Ldarg_1, Code.Brfalse_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_Ovf_U2, Code.Stloc_2, Code.Br_S, Code.Ldloc_0, Code.Castclass, Code.Callvirt, Code.Conv_U2, Code.Stloc_2, Code.Ldarg_0, Code.Newobj, Code.Dup, Code.Ldloc_2, Code.Callvirt, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Ldobj)]
        public static Boolean Is_Ldobj_Generated(this VirtualOpCode ins)
        {
            OperandType operandType;
            if (!ins.TryGetOperandType(out operandType)) return false;
            if (operandType != OperandType.InlineMethod) return false;
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
                if (!method.MatchesEntire(Code.Ldarg_0, Code.Call, Code.Stloc_0, Code.Ldarg_0, Code.Ldarg_0, Code.Ldloc_0, Code.Call, Code.Callvirt, Code.Ldarg_1, Code.Call, Code.Call, Code.Ret)) return false;
            }
            return true;
        }
        [Detect(Code.Cgt_Un)]
        public static Boolean Is_Cgt_Un_Generated(this VirtualOpCode ins)
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
                if (!method.MatchesEntire(Code.Ldc_I4_0, Code.Stloc_0, Code.Ldarg_0, Code.Callvirt, Code.Stloc_1, Code.Ldloc_1, Code.Ldc_I4_S, Code.Bgt, Code.Ldloc_1, Code.Brfalse, Code.Ldloc_1, Code.Ldc_I4_5, Code.Sub, Code.Switch, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Stloc_2, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Stloc_3, Code.Ldloc_2, Code.Ldloc_3, Code.Bgt_S, Code.Ldloc_2, Code.Call, Code.Brtrue_S, Code.Ldloc_3, Code.Call, Code.Br_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Cgt_Un, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldc_I4_1, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldloc_1, Code.Ldc_I4_S, Code.Beq_S, Code.Ldarg_0, Code.Callvirt, Code.Ldarg_1, Code.Callvirt, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Call, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_8, Code.Bne_Un_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Conv_I8, Code.Stloc_S, Code.Br_S, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_S, Code.Ldloc_S, Code.Ceq, Code.Ldc_I4_0, Code.Ceq, Code.Stloc_0, Code.Br, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_1, Code.Callvirt, Code.Ldc_I4_5, Code.Bne_Un_S, Code.Ldarg_1, Code.Callvirt, Code.Brtrue_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldsfld, Code.Call, Code.Stloc_0, Code.Br_S, Code.Ldarg_0, Code.Castclass, Code.Callvirt, Code.Ldarg_1, Code.Castclass, Code.Callvirt, Code.Call, Code.Stloc_0, Code.Ldloc_0, Code.Ret)) return false;
            }
            return true;
        }
    }
}
