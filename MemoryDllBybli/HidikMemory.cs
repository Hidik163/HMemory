using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryDllBybli
{
    public class HidikMemory
    {
        public nint ProcessModuleBase;
        public nint Handle;
        public HidikMemory(string name_process)
        {
            Process hello = Process.GetProcessesByName(name_process)[0];
            if (hello != null)
            {
                Handle = hello.Handle;
                ProcessModuleBase = hello.MainModule.BaseAddress;
            }
            else
            {
                Handle = 0;
                ProcessModuleBase = 0;
            }
        }
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            byte[] Buffer,
            uint NumberOfBytesToRead,
            out uint NumberOfBytesReaded
        );

        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            byte[] Buffer,
            uint NumberOfBytesToWrite,
            out uint NumberOfBytesWritten
        );
        /////Read Fuction

        //ModuleBase Values
        public nint GetModuleBase(string name_process)
        {
            Process hello = Process.GetProcessesByName(name_process)[0];
            if (hello != null)
                return hello.MainModule.BaseAddress;
            else
                return 0;
        }
        //Handle Values
        public nint GetHandleProcess(string name_process)
        {
            Process hello = Process.GetProcessesByName(name_process)[0];
            if (hello != null)
                return hello.Handle;
            else
                return 0;
        }
        //Pointers Values
        public nint ReadPointer(nint address)
        {
            byte[] bytes = new byte[8];
            NtReadVirtualMemory(Handle, address, bytes, 8, out _);
            return (nint)BitConverter.ToInt64(bytes);
        }
        public List<nint> ReadPointer(nint address, uint count)
        {
            byte[] bytes = new byte[count * 8];
            NtReadVirtualMemory(Handle, address, bytes, count * 8, out _);
            List<nint> Lists = new List<nint>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add((nint)BitConverter.ToInt64(bytes, i * 8));
            }
            return Lists;
        }
        //Int Values
        public int ReadInt(nint address)
        {
            byte[] bytes = new byte[4];
            NtReadVirtualMemory(Handle, address, bytes, 4, out _);
            return BitConverter.ToInt32(bytes);
        }
        public List<int> ReadInt(nint address, uint count)
        {
            byte[] bytes = new byte[count * 4];
            NtReadVirtualMemory(Handle, address, bytes, count * 4, out _);
            List<int> Lists = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToInt32(bytes, i * 4));
            }
            return Lists;
        }
        //Float Values
        public float ReadFloat(nint address)
        {
            byte[] bytes = new byte[4];
            NtReadVirtualMemory(Handle, address, bytes, 4, out _);
            return BitConverter.ToSingle(bytes);
        }
        public List<float> ReadFloat(nint address, uint count)
        {
            byte[] bytes = new byte[count * 4];
            NtReadVirtualMemory(Handle, address, bytes, count * 4, out _);
            List<float> Lists = new List<float>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToSingle(bytes, i * 4));
            }
            return Lists;
        }
        //Vector Values
        public Vector3 ReadVec(nint address)
        {
            byte[] bytes = new byte[12];
            NtReadVirtualMemory(Handle, address, bytes, 12, out _);
            Vector3 _value = new Vector3();
            _value.X = BitConverter.ToSingle(bytes, 0);
            _value.Y = BitConverter.ToSingle(bytes, 4);
            _value.Z = BitConverter.ToSingle(bytes, 8);
            return _value;
        }
        public List<Vector3> ReadVec(nint address, uint count)
        {
            byte[] bytes = new byte[count * 12];
            NtReadVirtualMemory(Handle, address, bytes, count * 12, out _);
            List<Vector3> Lists = new List<Vector3>();
            for (int i = 0; i < count; i++)
            {
                int _i = i + 12;
                Vector3 _value = new Vector3();
                _value.X = BitConverter.ToSingle(bytes, _i);
                _value.Y = BitConverter.ToSingle(bytes, _i + 4);
                _value.Z = BitConverter.ToSingle(bytes, _i + 8);
                Lists.Add(_value);
            }
            return Lists;
        }
        //Matrix Values
        public float[] ReadMatrix4x4(nint address)
        {
            byte[] bytes = new byte[64];
            NtReadVirtualMemory(Handle, address, bytes, 64, out _);
            float[] _value = new float[16];
            _value[0] = BitConverter.ToSingle(bytes, 0);
            _value[1] = BitConverter.ToSingle(bytes, 4);
            _value[2] = BitConverter.ToSingle(bytes, 8);
            _value[3] = BitConverter.ToSingle(bytes, 12);

            _value[4] = BitConverter.ToSingle(bytes, 16);
            _value[5] = BitConverter.ToSingle(bytes, 20);
            _value[6] = BitConverter.ToSingle(bytes, 24);
            _value[7] = BitConverter.ToSingle(bytes, 28);

            _value[8] = BitConverter.ToSingle(bytes, 32);
            _value[9] = BitConverter.ToSingle(bytes, 36);
            _value[10] = BitConverter.ToSingle(bytes, 40);
            _value[11] = BitConverter.ToSingle(bytes, 44);

            _value[12] = BitConverter.ToSingle(bytes, 48);
            _value[13] = BitConverter.ToSingle(bytes, 52);
            _value[14] = BitConverter.ToSingle(bytes, 56);
            _value[15] = BitConverter.ToSingle(bytes, 60);
            return _value;
        }
        public float[] ReadMatrix3x4(nint address)
        {
            byte[] bytes = new byte[48];
            NtReadVirtualMemory(Handle, address, bytes, 48, out _);
            float[] _value = new float[12];
            _value[0] = BitConverter.ToSingle(bytes, 0);
            _value[1] = BitConverter.ToSingle(bytes, 4);
            _value[2] = BitConverter.ToSingle(bytes, 8);
            _value[3] = BitConverter.ToSingle(bytes, 12);

            _value[4] = BitConverter.ToSingle(bytes, 16);
            _value[5] = BitConverter.ToSingle(bytes, 20);
            _value[6] = BitConverter.ToSingle(bytes, 24);
            _value[7] = BitConverter.ToSingle(bytes, 28);

            _value[8] = BitConverter.ToSingle(bytes, 32);
            _value[9] = BitConverter.ToSingle(bytes, 36);
            _value[10] = BitConverter.ToSingle(bytes, 40);
            _value[11] = BitConverter.ToSingle(bytes, 44);
            return _value;
        }
        public float[] ReadMatrix3x3(nint address)
        {
            byte[] bytes = new byte[36];
            NtReadVirtualMemory(Handle, address, bytes, 36, out _);
            float[] _value = new float[9];
            _value[0] = BitConverter.ToSingle(bytes, 0);
            _value[1] = BitConverter.ToSingle(bytes, 4);
            _value[2] = BitConverter.ToSingle(bytes, 8);

            _value[3] = BitConverter.ToSingle(bytes, 12);
            _value[4] = BitConverter.ToSingle(bytes, 16);
            _value[5] = BitConverter.ToSingle(bytes, 20);

            _value[6] = BitConverter.ToSingle(bytes, 24);
            _value[7] = BitConverter.ToSingle(bytes, 28);
            _value[8] = BitConverter.ToSingle(bytes, 32);
            return _value;
        }
        //Double Values
        public double ReadDouble(nint address)
        {
            byte[] bytes = new byte[8];
            NtReadVirtualMemory(Handle, address, bytes, 8, out _);
            return BitConverter.ToDouble(bytes);
        }
        public List<double> ReadDouble(nint address, uint count)
        {
            byte[] bytes = new byte[count * 8];
            NtReadVirtualMemory(Handle, address, bytes, count * 8, out _);
            List<double> Lists = new List<double>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToDouble(bytes, i * 8));
            }
            return Lists;
        }
        //Byte Values
        public byte ReadByte(nint address)
        {
            byte[] bytes = new byte[1];
            NtReadVirtualMemory(Handle, address, bytes, 1, out _);
            return bytes[0];
        }
        public byte[] ReadByte(nint address, uint count)
        {
            byte[] bytes = new byte[count];
            NtReadVirtualMemory(Handle, address, bytes, count, out _);
            return bytes;
        }
        //Bool Values
        public bool ReadBool(nint address)
        {
            byte[] bytes = new byte[1];
            NtReadVirtualMemory(Handle, address, bytes, 1, out _);
            return bytes[0] != 0;
        }
        public List<bool> ReadBool(nint address, uint count)
        {
            byte[] bytes = new byte[count];
            NtReadVirtualMemory(Handle, address, bytes, count, out _);
            List<bool> Lists = new List<bool>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(bytes[i] != 0);
            }
            return Lists;
        }
        //Uint Values
        public uint ReadUint(nint address)
        {
            byte[] bytes = new byte[8];
            NtReadVirtualMemory(Handle, address, bytes, 8, out _);
            return BitConverter.ToUInt32(bytes);
        }
        public List<uint> ReadUint(nint address, uint count)
        {
            byte[] bytes = new byte[count * 8];
            NtReadVirtualMemory(Handle, address, bytes, count * 8, out _);
            List<uint> Lists = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToUInt32(bytes, i * 8));
            }
            return Lists;
        }
        //Char Values
        public char ReadChar(nint address)
        {
            byte[] bytes = new byte[2];
            NtReadVirtualMemory(Handle, address, bytes, 2, out _);
            return BitConverter.ToChar(bytes);
        }
        public List<char> ReadChar(nint address, uint count)
        {
            byte[] bytes = new byte[count * 2];
            NtReadVirtualMemory(Handle, address, bytes, count * 2, out _);
            List<char> Lists = new List<char>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToChar(bytes, i * 2));
            }
            return Lists;
        }
        //Short Values
        public short ReadShort(nint address)
        {
            byte[] bytes = new byte[2];
            NtReadVirtualMemory(Handle, address, bytes, 2, out _);
            return BitConverter.ToInt16(bytes);
        }
        public List<short> ReadShort(nint address, uint count)
        {
            byte[] bytes = new byte[count * 2];
            NtReadVirtualMemory(Handle, address, bytes, count * 2, out _);
            List<short> Lists = new List<short>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToInt16(bytes, i * 2));
            }
            return Lists;
        }
        //UShort Values
        public ushort ReadUShort(nint address)
        {
            byte[] bytes = new byte[2];
            NtReadVirtualMemory(Handle, address, bytes, 2, out _);
            return BitConverter.ToUInt16(bytes);
        }
        public List<ushort> ReadUShort(nint address, uint count)
        {
            byte[] bytes = new byte[count * 2];
            NtReadVirtualMemory(Handle, address, bytes, count * 2, out _);
            List<ushort> Lists = new List<ushort>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToUInt16(bytes, i * 2));
            }
            return Lists;
        }
        //Long Values
        public long ReadLong(nint address)
        {
            byte[] bytes = new byte[8];
            NtReadVirtualMemory(Handle, address, bytes, 8, out _);
            return BitConverter.ToInt64(bytes);
        }
        public List<long> ReadLong(nint address, uint count)
        {
            byte[] bytes = new byte[count * 8];
            NtReadVirtualMemory(Handle, address, bytes, count * 8, out _);
            List<long> Lists = new List<long>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToInt64(bytes, i * 8));
            }
            return Lists;
        }
        //ULong Values
        public ulong ReadULong(nint address)
        {
            byte[] bytes = new byte[8];
            NtReadVirtualMemory(Handle, address, bytes, 8, out _);
            return BitConverter.ToUInt64(bytes);
        }
        public List<ulong> ReadULong(nint address, uint count)
        {
            byte[] bytes = new byte[count * 8];
            NtReadVirtualMemory(Handle, address, bytes, count * 8, out _);
            List<ulong> Lists = new List<ulong>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToUInt64(bytes, i * 8));
            }
            return Lists;
        }


        //Read String (by .foulz.) ////////////////////////////////////////////////////////////////////////
        private string ReadStringBase(nint addy)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buff = new byte[200];
            NtReadVirtualMemory(Handle, addy, buff, 200, out _);
            for (int i = 0; i < 200; i++)
            {
                if (buff[i] == 0)
                    break;
                sb.Append((char)buff[i]);
            }
            return sb.ToString();
        }
        private string ReadStringExplorer(IntPtr address)
        {
            if (address == 0) return "";
            try
            {
                int length = ReadInt(address + 0x18);
                IntPtr strPtr = address;
                if (length >= 16)
                {
                    strPtr = ReadPointer(address);
                }

                var sb = new StringBuilder();
                for (int i = 0; i < length; ++i)
                {
                    byte b = ReadByte(strPtr + i);
                    if (b == 0) break;
                    sb.Append((char)b);
                }
                return sb.ToString();
            }
            catch
            {
                return "";
            }
        }
        public string ReadString(IntPtr address)
        {
            if (address == 0) return "";
            try
            {
                int length = ReadInt(address + 0x18);
                if (length >= 16)
                {
                    IntPtr padding = ReadPointer(address);
                    return ReadStringBase(padding);
                }
                return ReadStringBase(address);
            }
            catch
            {
                return ReadStringExplorer(address);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /////Write Function




        //Pointer Values
        public void WritePointer(nint address, nint value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 8, out _);
        }
        //Float Values
        public void WriteFloat(nint address, float value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 4, out _);
        }
        //Int Values
        public void WriteInt(nint address, int value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 4, out _);
        }
        //uint Values
        public void WriteUInt(nint address, uint value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 4, out _);
        }
        //short Values
        public void WriteShort(nint address, short value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 2, out _);
        }
        //ushort Values
        public void WriteUShort(nint address, ushort value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 2, out _);
        }
        //double Values
        public void WriteDouble(nint address, double value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 8, out _);
        }
        //long Values
        public void WriteLong(nint address, long value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 8, out _);
        }
        //ulong Values
        public void WriteULong(nint address, ulong value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 8, out _);
        }
        //bool Values
        public void WriteBool(nint address, bool value)
        {
            NtWriteVirtualMemory(Handle, address, BitConverter.GetBytes(value), 1, out _);
        }
        //byte Values
        public void WriteByte(nint address, byte value)
        {
            NtWriteVirtualMemory(Handle, address, new byte[] { value }, 1, out _);
        }
        //Vec Values
        public void WriteVec(nint address, Vector3 value)
        {
            byte[] buff = new byte[12];
            byte[] xBytes = BitConverter.GetBytes(value.X);
            byte[] yBytes = BitConverter.GetBytes(value.Y);
            byte[] zBytes = BitConverter.GetBytes(value.Z);
            buff[0] = xBytes[0]; buff[1] = xBytes[1]; buff[2] = xBytes[2]; buff[3] = xBytes[3];
            buff[4] = yBytes[0]; buff[5] = yBytes[1]; buff[6] = yBytes[2]; buff[7] = yBytes[3];
            buff[8] = zBytes[0]; buff[9] = zBytes[1]; buff[10] = zBytes[2]; buff[11] = zBytes[3];
            NtWriteVirtualMemory(Handle, address, buff, 12, out _);
        }

        //String Values (by .Foulz. and chat-gpt)
        private bool WriteStringRaw(IntPtr address, string value)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(value + "\0");

            for (int i = 0; i < bytes.Length; i++)
            {
                WriteByte(address + i, bytes[i]);
            }

            return true;
        }
        public bool WriteString(IntPtr address, string value)
        {
            if (address == IntPtr.Zero) return false;
            try
            {
                int length = ReadInt(address + 0x18);

                if (length >= 16)
                {
                    IntPtr padding = ReadPointer(address);
                    return WriteStringRaw(padding, value);
                }

                return WriteStringRaw(address, value);
            }
            catch
            {
                return WriteStringExplorer(address, value);
            }
        }
        private bool WriteStringExplorer(IntPtr address, string value)
        {
            if (address == IntPtr.Zero) return false;

            try
            {
                int length = ReadInt(address + 0x18);
                IntPtr strPtr = address;

                if (length >= 16)
                {
                    strPtr = ReadPointer(address);
                }

                byte[] bytes = Encoding.ASCII.GetBytes(value + "\0");

                for (int i = 0; i < bytes.Length; i++)
                {
                    WriteByte(strPtr + i, bytes[i]);
                }
                WriteInt(address + 0x18, value.Length);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
