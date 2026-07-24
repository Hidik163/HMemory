HidikMemory is a lightweight C# library for reading/writing external process memory using native ntdll.dll calls (NtReadVirtualMemory / NtWriteVirtualMemory).

Features
Read/write primitives: int, uint, short, ushort, long, ulong, float, double, bool, byte, char

Pointers (nint)

Vector3

Matrices (3x3, 3x4, 4x4)

Strings

Batch reading as List<T>

Auto-retrieves process handle and base module address

Usage
csharp
var mem = new HidikMemory("process_name");

// Read
int value = mem.ReadInt(0x12345678);
Vector3 pos = mem.ReadVec(0xABCDEF00);
string text = mem.ReadString(0x00400000);

// Write
mem.WriteInt(0x12345678, 999);
mem.WriteFloat(0xABCDEF00, 3.14f);
mem.WriteString(0x00400000, "Hello");

// Batch read
List<float> floats = mem.ReadFloat(address, 10);
