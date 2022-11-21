using System;
using System.IO;

namespace eazdevirt.Core
{
    internal class EazBinaryReader : BinaryReader
    {
        public EazBinaryReader(Stream input) : base(input)
        {
        }
        public override Int32 ReadInt32()
        {
            var bytes = this.ReadBytes(4);
            return (Int32)bytes[0] << 24 | (Int32)bytes[1] << 16 | (Int32)bytes[2] | (Int32)bytes[3] << 8;
        }
        public override uint ReadUInt32()
        {
            var bytes = this.ReadBytes(4);
            return (uint)((int)bytes[3] << 8 | (int)bytes[1] << 24 | (int)bytes[0] | (int)bytes[2] << 16);
        }
        public override short ReadInt16()
        {
            var bytes = this.ReadBytes(2);
            return (short)((int)bytes[0] << 8 | (int)bytes[1]);
        }
        public override ushort ReadUInt16()
        {
            var bytes = this.ReadBytes(2);
            return (ushort)((int)bytes[0] | (int)bytes[1] << 8);
        }
    }
}
