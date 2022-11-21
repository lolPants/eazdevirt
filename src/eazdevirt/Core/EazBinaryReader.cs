using dnlib.IO;
using System;
using System.IO;

namespace eazdevirt.Core
{
    internal class EazBinaryReader : BinaryReader
    {
        public EazBinaryReader(Stream input) : base(input)
        {
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

        public override Int32 ReadInt32()
        {
            var bytes = this.ReadBytes(4);
            return (Int32)bytes[0] << 24 | (Int32)bytes[1] << 16 | (Int32)bytes[2] | (Int32)bytes[3] << 8;
        }

        public override long ReadInt64()
        {
            var bytes = this.ReadBytes(8);
            return (long)((ulong)((int)bytes[0] << 24 | (int)bytes[6] | (int)bytes[4] << 16 | (int)bytes[5] << 8) | (ulong)((ulong)((long)((int)bytes[1] << 16 | (int)bytes[2] << 8 | (int)bytes[7] << 24 | (int)bytes[3])) << 32));
        }

        public override ulong ReadUInt64()
        {
            var bytes = this.ReadBytes(8);
            return (ulong)((int)bytes[5] << 24 | (int)bytes[4] << 16 | (int)bytes[3] << 8 | (int)bytes[2]) | (ulong)((ulong)((long)((int)bytes[0] | (int)bytes[1] << 8 | (int)bytes[7] << 24 | (int)bytes[6] << 16)) << 32);
        }

        public override uint ReadUInt32()
        {
            var bytes = this.ReadBytes(4);
            return (uint)((int)bytes[3] << 8 | (int)bytes[1] << 24 | (int)bytes[0] | (int)bytes[2] << 16);
        }

        public override float ReadSingle()
        {
            var bytes = this.ReadBytes(4);
            byte[] array = new byte[4];
            array[0] = bytes[3];
            array[2] = bytes[1];
            array[3] = bytes[0];
            array[1] = bytes[2];
            return ToBinaryReader(array).ReadSingle();
        }

        public override double ReadDouble()
        {
            var bytes = this.ReadBytes(8);
            byte[] array = new byte[8];
            array[6] = bytes[7];
            array[7] = bytes[3];
            array[5] = bytes[4];
            array[0] = bytes[2];
            array[1] = bytes[1];
            array[2] = bytes[0];
            array[4] = bytes[5];
            array[3] = bytes[6];
            return ToBinaryReader(array).ReadSingle();
        }

        public override decimal ReadDecimal()
        {
            throw new NotImplementedException();
        }

        private BinaryReader ToBinaryReader(byte[] input)
	{
            MemoryStream memoryStream = new MemoryStream(8);
            BinaryReader binaryReader = new BinaryReader(memoryStream);
			binaryReader.BaseStream.Position = 0L;
            memoryStream.Write(input, 0, input.Length);
            memoryStream.Position = 0L;
            return binaryReader;
	}
    }
}
