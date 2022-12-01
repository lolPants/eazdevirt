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

        public OpCodeResolver(ModuleDefMD referenceModule)
        {
            this.ReferenceModule = referenceModule;
            this.IdentifiedCodes = new List<VirtualOpCode>();
        }

        private MethodDef FindReference(MethodStub stub)
        {
            foreach (TypeDef type in ReferenceModule.Types)
            {
                if(stub.Method.DeclaringType.AssemblyQualifiedName == type.AssemblyQualifiedName)
                {
                    foreach (MethodDef method in type.Methods)
                    {
                        if (method.FullName == stub.Method.FullName)
                        {
                            List<string> methodParams = method.Parameters.Select(p => p.Type.AssemblyQualifiedName).ToList();
                            List<string> stubParams = stub.Method.Parameters.Select(p => p.Type.AssemblyQualifiedName).ToList();
                            if (methodParams.Equals(stubParams))
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

        public string GenerateCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(@"using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using eazdevirt.Reflection;
using eazdevirt.Util;

namespace eazdevirt.Detection.V1.Ext
{
	public static partial class Extensions
	{");
            foreach (VirtualOpCode virtualInstruction in this.IdentifiedCodes)
            {
                string code = virtualInstruction.OpCode.ToString();
                string indent = "        ";
                string mindent = "            ";
                builder.AppendLine(indent + $"[Detect(Code.{code})]");
                builder.AppendLine(indent + $"public static Boolean Is_{code}_Generated(this VirtualOpCode ins)");
                builder.AppendLine(indent + "{");
                builder.AppendLine(mindent + $"if (!ins.DelegateMethod.MatchesEntire({ConvertMethodBody(virtualInstruction.DelegateMethod)})) return false;");
                for(int i = 0; i < virtualInstruction.DelegateMethod.Calls().Count(); ++i)
                {
                    MethodDef called = virtualInstruction.DelegateMethod.Calls().ToList()[i].ResolveMethodDef();
                    builder.AppendLine(mindent + $"if (!ins.DelegateMethod.Calls().ToList()[{i}].ResolveMethodDef().MatchesEntire({ConvertMethodBody(called)})) return false;");
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
