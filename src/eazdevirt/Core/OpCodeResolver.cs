using dnlib.DotNet;
using dnlib.DotNet.Emit;
using eazdevirt.Reflection;
using eazdevirt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eazdevirt.Core
{
    public class OpCodeResolver
    {
        public ModuleDefMD ReferenceModule { get; private set; }

        public List<VirtualOpCode> IdentifiedCodes { get; private set; }

        public EazModule Parent { get; private set; }

        public OpCodeResolver(ModuleDefMD referenceModule, EazModule parent)
        {
            this.ReferenceModule = referenceModule;
            this.IdentifiedCodes = new List<VirtualOpCode>();
            this.Parent = parent;
        }

        private MethodDef FindReference(MethodStub stub)
        {
            foreach (TypeDef type in ReferenceModule.GetTypes())
            {
                if (stub.Method.DeclaringType.AssemblyQualifiedName == type.AssemblyQualifiedName)
                {
                    foreach (MethodDef method in type.Methods)
                    {
                        if (method.FullName == stub.Method.FullName)
                        {
                            List<string> methodParams = method.Parameters.Select(p => p.Type.AssemblyQualifiedName).ToList();
                            List<string> stubParams = stub.Method.Parameters.Select(p => p.Type.AssemblyQualifiedName).ToList();
                            if (methodParams.SequenceEqual(stubParams))
                            {
                                return method;
                            }
                        }
                    }
                }
            }

            return null;
        }

        public bool ForceIdentify(MethodStub stub, int index, VirtualOpCode virtualInstruction)
        {
            MethodDef originalMethod = FindReference(stub);
            if (originalMethod == null) return false;
            if (index >= originalMethod.Body.Instructions.Count) return false;

            virtualInstruction.ForceIdentify(originalMethod.Body.Instructions[index].OpCode.Code);

            IdentifiedCodes.Add(virtualInstruction);

            return true;
        }

        private string ConvertMethodBody(MethodDef method)
        {
            return string.Join(", ", method.Body.Instructions.Select(p => "Code." + p.OpCode.Code.ToString()));
        }

        private delegate MethodDef ResolveMethod(VirtualOpCode virtualOpCode);

        private void AddMethodCode(string methodName, MethodDef method, StringBuilder builder, VirtualOpCode virtualInstruction, ref IEnumerable<VirtualOpCode> stillMatches, ResolveMethod resolve)
        {
            string mindent = "            ";
            string mmindent = "                ";
            int cnt = stillMatches.Count();
            builder.AppendLine(mindent + "{");
            stillMatches = stillMatches.Where(x => resolve(x).MatchesEntire(method.Body.Instructions.Select(y => y.OpCode.Code).ToList())).ToList();
            if (stillMatches.Count() != cnt)
            {
                builder.AppendLine(mmindent + $"var method = {methodName};");
                builder.AppendLine(mmindent + $"if (!method.MatchesEntire({ConvertMethodBody(method)})) return false;");
                cnt = stillMatches.Count();
            }
            for (int i = 0; i < method.Body.Instructions.Count && stillMatches.Count() > 0; i++)
            {
                var instruction = method.Body.Instructions[i];
                var typeDef = instruction.Operand as ITypeDefOrRef;
                if (typeDef != null && typeDef.FullName.StartsWith("System."))
                {
                    stillMatches = stillMatches.Where(x => ((ITypeDefOrRef)resolve(x).Body.Instructions[i].Operand).FullName == typeDef.FullName).ToList();
                    if (stillMatches.Count() != cnt)
                    {
                        cnt = stillMatches.Count();
                        builder.AppendLine(mmindent + $"if (((ITypeDefOrRef)method.Body.Instructions[{i}].Operand).FullName != \"{typeDef.FullName}\") return false;");
                    }
                }
                if (typeDef != null && !typeDef.FullName.StartsWith("System."))
                {
                    stillMatches = stillMatches.Where(x => !((ITypeDefOrRef)resolve(x).Body.Instructions[i].Operand).FullName.StartsWith("System.")).ToList();
                    if (stillMatches.Count() != cnt)
                    {
                        cnt = stillMatches.Count();
                        builder.AppendLine(mmindent + $"if (((ITypeDefOrRef)method.Body.Instructions[{i}].Operand).FullName.StartsWith(\"System.\")) return false;");
                    }
                }

                var methodDef = instruction.Operand as IMethodDefOrRef;
                if (methodDef != null && methodDef.DeclaringType.FullName.StartsWith("System."))
                {
                    stillMatches = stillMatches.Where(x => ((IMethodDefOrRef)resolve(x).Body.Instructions[i].Operand).FullName == methodDef.FullName).ToList();
                    if (stillMatches.Count() != cnt)
                    {
                        cnt = stillMatches.Count();
                        builder.AppendLine(mmindent + $"if (((IMethodDefOrRef)method.Body.Instructions[{i}].Operand).FullName != \"{methodDef.FullName}\") return false;");
                    }
                }
                if (methodDef != null && !methodDef.DeclaringType.FullName.StartsWith("System."))
                {
                    stillMatches = stillMatches.Where(x => !((IMethodDefOrRef)resolve(x).Body.Instructions[i].Operand).DeclaringType.FullName.StartsWith("System.")).ToList();
                    if (stillMatches.Count() != cnt)
                    {
                        cnt = stillMatches.Count();
                        builder.AppendLine(mmindent + $"if (((IMethodDefOrRef)method.Body.Instructions[{i}].Operand).DeclaringType.FullName.StartsWith(\"System.\")) return false;");
                    }
                }

                var fieldDef = instruction.Operand as FieldDef;
                if (fieldDef != null && fieldDef.DeclaringType.FullName.StartsWith("System."))
                {
                    stillMatches = stillMatches.Where(x => ((FieldDef)resolve(x).Body.Instructions[i].Operand).FullName == fieldDef.FullName).ToList();
                    if (stillMatches.Count() != cnt)
                    {
                        cnt = stillMatches.Count();
                        builder.AppendLine(mmindent + $"if (((FieldDef)method.Body.Instructions[{i}].Operand).FullName != \"{fieldDef.FullName}\") return false;");
                    }
                }
                if (fieldDef != null && fieldDef.MDToken == virtualInstruction.VType.ArgumentsField.MDToken)
                {
                    stillMatches = stillMatches.Where(x => ((FieldDef)resolve(x).Body.Instructions[i].Operand).MDToken == virtualInstruction.VType.ArgumentsField.MDToken).ToList();
                    if (stillMatches.Count() != cnt)
                    {
                        cnt = stillMatches.Count();
                        builder.AppendLine(mmindent + $"if (((FieldDef)method.Body.Instructions[{i}].Operand).MDToken != ins.VType.ArgumentsField.MDToken) return false;");
                    }
                }
                if (fieldDef != null && fieldDef.MDToken == virtualInstruction.VType.LocalsField.MDToken)
                {
                    stillMatches = stillMatches.Where(x => ((FieldDef)resolve(x).Body.Instructions[i].Operand).MDToken == virtualInstruction.VType.LocalsField.MDToken).ToList();
                    if (stillMatches.Count() != cnt)
                    {
                        cnt = stillMatches.Count();
                        builder.AppendLine(mmindent + $"if (((FieldDef)method.Body.Instructions[{i}].Operand).MDToken != ins.VType.LocalsField.MDToken) return false;");
                    }
                }
                List<string> maybeRelevantTypes = new List<string>() { "System.IntPtr" };
                foreach (string maybeType in maybeRelevantTypes)
                {
                    if (fieldDef != null && fieldDef.MDToken == virtualInstruction.VType.GetTypeField(maybeType).MDToken)
                    {
                        stillMatches = stillMatches.Where(x => ((FieldDef)resolve(x).Body.Instructions[i].Operand).MDToken == virtualInstruction.VType.GetTypeField(maybeType).MDToken).ToList();
                        if (stillMatches.Count() != cnt)
                        {
                            cnt = stillMatches.Count();
                            builder.AppendLine(mmindent + $"if (((FieldDef)method.Body.Instructions[{i}].Operand).MDToken != ins.VType.GetTypeField(\"{maybeType}\").MDToken) return false;");
                        }
                    }
                    if (fieldDef != null && fieldDef.MDToken != virtualInstruction.VType.GetTypeField(maybeType).MDToken)
                    {
                        stillMatches = stillMatches.Where(x => ((FieldDef)resolve(x).Body.Instructions[i].Operand).MDToken != virtualInstruction.VType.GetTypeField(maybeType).MDToken).ToList();
                        if (stillMatches.Count() != cnt)
                        {
                            cnt = stillMatches.Count();
                            builder.AppendLine(mmindent + $"if (((FieldDef)method.Body.Instructions[{i}].Operand).MDToken == ins.VType.GetTypeField(\"{maybeType}\").MDToken) return false;");
                        }
                    }
                }
            }
            builder.AppendLine(mindent + "}");
        }

        public string GenerateCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(@"using System;
using System.Linq;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using eazdevirt.Reflection;
using eazdevirt.Util;

namespace eazdevirt.Detection.V1.Ext
{
	public static partial class Extensions
	{");
            bool hasOutputNop = false;
            bool hasOutputStind = false;

            foreach (VirtualOpCode virtualInstruction in this.IdentifiedCodes)
            {
                bool isNop = virtualInstruction.OpCode == Code.Nop;
                bool isStind = false;
                switch (virtualInstruction.OpCode)
                {
                    case Code.Stind_I:
                    case Code.Stind_I1:
                    case Code.Stind_I2:
                    case Code.Stind_I4:
                    case Code.Stind_I8:
                    case Code.Stind_R4:
                    case Code.Stind_R8:
                    case Code.Stind_Ref:
                        isStind = true;
                        break;
                }

                if (isNop && hasOutputNop) continue;
                if (isNop) hasOutputNop = true;

                if (isStind && hasOutputStind) continue;
                if (isStind) hasOutputStind = true;

                string code = virtualInstruction.OpCode.ToString();
                if (isStind)
                    code = Code.Stind_I.ToString();
                string indent = "        ";
                string mindent = "            ";
                if (isStind || isNop)
                    builder.AppendLine(indent + $"[Detect(Code.{code}, ExpectsMultiple=true)]");
                else
                    builder.AppendLine(indent + $"[Detect(Code.{code})]");
                builder.AppendLine(indent + $"public static Boolean Is_{code}_Generated(this VirtualOpCode ins)");
                builder.AppendLine(indent + "{");

                IEnumerable<VirtualOpCode> stillMatches = this.Parent.AllOpCodes.Values.ToList();

                OperandType operandType = virtualInstruction.GetOperandType();
                //if(virtualInstruction.TryGetOperandType(out operandType))
                builder.AppendLine(mindent + "OperandType operandType;");
                builder.AppendLine(mindent + "if (!ins.TryGetOperandType(out operandType)) return false;");
                builder.AppendLine(mindent + $"if (operandType != OperandType.{operandType}) return false;");
                stillMatches = stillMatches.Where(x =>
                {
                    OperandType opT;
                    return x.TryGetOperandType(out opT) && opT == operandType;
                }).ToList();
                if (stillMatches.Count() > 1)
                    this.AddMethodCode("ins.DelegateMethod", virtualInstruction.DelegateMethod, builder, virtualInstruction, ref stillMatches, x => x.DelegateMethod);

                for (int i = 0; i < virtualInstruction.DelegateMethod.Calls().Count() && stillMatches.Count() > 1; ++i)
                {
                    MethodDef called = virtualInstruction.DelegateMethod.Calls().ToList()[i].ResolveMethodDef();
                    if (called != null && called.Body != null)
                    {
                        string methodName = $"ins.DelegateMethod.Calls().ToList()[{i}].ResolveMethodDef()";
                        this.AddMethodCode(methodName, called, builder, virtualInstruction, ref stillMatches, x => x.DelegateMethod.Calls().ToList()[i].ResolveMethodDef());
                    }
                }
                builder.AppendLine(mindent + $"return true;");
                builder.AppendLine(indent + "}");
            }
            builder.AppendLine(@"    }
}");
            return builder.ToString();
        }
    }
}