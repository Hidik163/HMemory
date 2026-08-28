using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryDllBybli
{
    public class HidikMemory
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int fuckidk, bool a2, int processid);

        public nint ProcessModuleBase;
        public nint Handle;
        public nint GuiWindow;
        public HidikMemory(string name_process)
        {
            Process hello = Process.GetProcessesByName(name_process)[0];     
            if (hello != null)
            {
                Handle = OpenProcess(0x1F0FFF, false, hello.Id);
                ProcessModuleBase = hello.MainModule.BaseAddress;
                GuiWindow = hello.MainWindowHandle;
            }
            else
            {
                Handle = 0;
                ProcessModuleBase = 0;
                GuiWindow = 0;
            }
        }
        //Base Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            byte[] Buffer,
            uint NumberOfBytesToRead,
            out uint NumberOfBytesReaded
        );
        //Base Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            byte[] Buffer,
            uint NumberOfBytesToWrite,
            out uint NumberOfBytesWritten
        );






        //nint Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out nint Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //int Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out int Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //float Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out float Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //Vector3 Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out Vector3 Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //Vector2 Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out Vector2 Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //Matrix4x4 Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out Matrix4x4 Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //Double Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out double Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //uint Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out uint Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //char Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out char Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //short Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out short Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //ushort Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out ushort Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //long Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out long Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //ulong Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out ulong Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );
        //byte Read
        [DllImport("ntdll.dll")]
        private static extern int NtReadVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            out byte Buffer,
            uint NumberOfBytesToRead,
            nint NumberOfBytesRead
        );








        //nint Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref nint Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //float Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref float Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //int Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref int Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //uint Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref uint Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //short Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref short Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //ushort Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref ushort Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //double Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref double Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //long Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref long Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //ulong Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref ulong Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //bool Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref bool Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //byte Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref byte Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //Vector3 Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref Vector3 Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
        );
        //Vector2 Write
        [DllImport("ntdll.dll")]
        private static extern int NtWriteVirtualMemory(
            nint ProcessHandle,
            nint BaseAddress,
            ref Vector2 Buffer,
            uint NumberOfBytesToWrite,
            uint NumberOfBytesWritten
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
                return OpenProcess(0x1F0FFF, false, hello.Id);
            else
                return 0;
        }
        //Pointers Values
        public nint ReadPointer(nint address)
        {
            NtReadVirtualMemory(Handle, address, out nint value, 8, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out int value, 4, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out float value, 4, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out Vector3 value, 12, 0);
            return value;
        }
        public List<Vector3> ReadVec(nint address, uint count)
        {
            byte[] bytes = new byte[count * 12];
            NtReadVirtualMemory(Handle, address, bytes, count * 12, out _);
            List<Vector3> Lists = new List<Vector3>();
            for (int i = 0; i < count; i++)
            {
                int _i = i * 12;
                Vector3 _value = new Vector3();
                _value.X = BitConverter.ToSingle(bytes, _i);
                _value.Y = BitConverter.ToSingle(bytes, _i + 4);
                _value.Z = BitConverter.ToSingle(bytes, _i + 8);
                Lists.Add(_value);
            }
            return Lists;
        }
        //Vector2 Values
        public Vector2 ReadVec2(nint address)
        {
            NtReadVirtualMemory(Handle, address, out Vector2 value, 8, 0);
            return value;
        }
        public List<Vector2> ReadVec2(nint address, uint count)
        {
            byte[] bytes = new byte[count * 8];
            NtReadVirtualMemory(Handle, address, bytes, count * 8, out _);
            List<Vector2> Lists = new List<Vector2>();
            for (int i = 0; i < count; i++)
            {
                int _i = i * 8;
                Vector2 _value = new Vector2();
                _value.X = BitConverter.ToSingle(bytes, _i);
                _value.Y = BitConverter.ToSingle(bytes, _i + 4);
                Lists.Add(_value);
            }
            return Lists;
        }
        //Matrix Values
        public Matrix4x4 ReadMatrix4x4(nint address)
        {
            NtReadVirtualMemory(Handle, address, out Matrix4x4 value, 64, 0);        
            return value;
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
            NtReadVirtualMemory(Handle, address, out double value, 8, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out byte value, 1, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out byte value, 1, 0);
            return value != 0;
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
            NtReadVirtualMemory(Handle, address, out uint value, 4, 0);
            return value;
        }
        public List<uint> ReadUint(nint address, uint count)
        {
            byte[] bytes = new byte[count * 4];
            NtReadVirtualMemory(Handle, address, bytes, count * 4, out _);
            List<uint> Lists = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                Lists.Add(BitConverter.ToUInt32(bytes, i * 4));
            }
            return Lists;
        }
        //Char Values
        public char ReadChar(nint address)
        {
            NtReadVirtualMemory(Handle, address, out char value, 2, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out short value, 2, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out ushort value, 2, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out long value, 8, 0);
            return value;
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
            NtReadVirtualMemory(Handle, address, out ulong value, 8, 0);
            return value;
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
            NtWriteVirtualMemory(Handle, address, ref value, 8, 0);
        }
        //Float Values
        public void WriteFloat(nint address, float value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 4, 0);
        }
        //Int Values
        public void WriteInt(nint address, int value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 4, 0);
        }
        //uint Values
        public void WriteUInt(nint address, uint value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 4, 0);
        }
        //short Values
        public void WriteShort(nint address, short value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 2, 0);
        }
        //ushort Values
        public void WriteUShort(nint address, ushort value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 2, 0);
        }
        //double Values
        public void WriteDouble(nint address, double value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 8, 0);
        }
        //long Values
        public void WriteLong(nint address, long value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 8, 0);
        }
        //ulong Values
        public void WriteULong(nint address, ulong value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 8, 0);
        }
        //bool Values
        public void WriteBool(nint address, bool value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 1, 0);
        }
        //byte Values
        public void WriteByte(nint address, byte value)
        {
            NtWriteVirtualMemory(Handle, address, ref value , 1, 0);
        }
        //Vec Values
        public void WriteVec(nint address, Vector3 value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 12, 0);
        }
        public void WriteVec2(nint address, Vector2 value)
        {
            NtWriteVirtualMemory(Handle, address, ref value, 8, 0);
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

