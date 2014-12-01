using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace StructView.Framework
{
	public class Memory : IDisposable
	{
		public readonly int BaseAddress;
		private bool closed;
		private IntPtr procHandle;
		private Dictionary<string, int> modules;
		public Process Process { get; private set; }
		public Memory(int pId)
		{
			this.Process = Process.GetProcessById(pId);
			this.BaseAddress = this.Process.MainModule.BaseAddress.ToInt32();
			this.Open();
			this.modules = new Dictionary<string, int>();
		}

		public void Dispose()
		{
			this.Close();
		}
		~Memory()
		{
			this.Close();
		}

        /// <summary>
        /// Reads The base Adress of the Module with given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
		public int GetModule(string name)
		{
			if (this.modules.ContainsKey(name))
			{
				return this.modules[name];
			}
			int num = this.Process.Modules.Cast<ProcessModule>().First(m => m.ModuleName == name).BaseAddress.ToInt32();
			this.modules.Add(name, num);
			return num;
		}

        /// <summary>
        /// Is the Process still Alive ?
        /// </summary>
        /// <returns></returns>
		public bool IsInvalid()
		{
			return this.Process.HasExited || this.closed;
		}

        /// <summary>
        /// memory Read : read an integer Value From the given Adress
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
		public int ReadInt(int addr)
		{
			return BitConverter.ToInt32(this.ReadMem(addr, 4), 0);
		}
        
        /// <summary>
        /// memory Read : read an integer Value From Offset-Chain starting at given adress
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="offsets"></param>
        /// <returns></returns>
		public int ReadInt(int addr, params int[] offsets)
		{
			int num = this.ReadInt(addr);
			for (int i = 0; i < offsets.Length; i++)
			{
				int num2 = offsets[i];
				num = this.ReadInt(num + num2);
			}
			return num;
		}

        /// <summary>
        /// Reads a float from the given Adress
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
		public float ReadFloat(int addr)
		{
			return BitConverter.ToSingle(this.ReadMem(addr, 4), 0);
		}

        /// <summary>
        /// Reads a Long-Integer from the given adress
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
		public long ReadLong(int addr)
		{
			return BitConverter.ToInt64(this.ReadMem(addr, 8), 0);
		}

        /// <summary>
        /// Reads unsigned Int from the given Adress
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
		public uint ReadUInt(int addr)
		{
			return BitConverter.ToUInt32(this.ReadMem(addr, 4), 0);
		}

		public short ReadShort(int addr)
		{
			return BitConverter.ToInt16(this.ReadMem(addr, 2), 0);
		}


		public string ReadString(int addr, int length, bool replaceNull = true)
		{
			if (addr <= 65536 && addr >= -1)
			{
				return string.Empty;
			}
			string @string = Encoding.ASCII.GetString(this.ReadMem(addr, length));
			if (replaceNull)
			{
				int num = @string.IndexOf('\0');
				if (num > 0)
				{
					return @string.Substring(0, num);
				}
			}
			return @string;
		}

		public string ReadStringU(int addr, int length, bool replaceNull = true)
		{
			if (addr <= 65536 && addr >= -1)
			{
				return string.Empty;
			}
			byte[] mem = this.ReadMem(addr, length);
			if (mem[0] == 0 && mem[1] == 0)
				return string.Empty;
			string @string = Encoding.Unicode.GetString(mem);
			if (replaceNull)
			{
				int num = @string.IndexOf('\0');
				if (num > 0)
				{
					return @string.Substring(0, num);
				}
			}
			return @string;
		}

	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="addr"></param>
	    /// <returns></returns>
        public byte ReadByte(int addr)
		{
			return this.ReadBytes(addr, 1)[0];
		}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte[] ReadBytes(int addr, int length)
		{
			return this.ReadMem(addr, length);
		}
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public unsafe T Read<T>(int address) where T : struct
        {
            fixed (byte* numRef = this.ReadMem(address, Marshal.SizeOf(typeof(T))))
            {
                return (T)Marshal.PtrToStructure(new IntPtr((void*)numRef), typeof(T));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="str"></param>
		public void WriteStringU(int addr, string str)
		{
			if (addr <= 4096 && addr >= -1)
			{
				return;
			}
			byte[] bytes = Encoding.Unicode.GetBytes(str);
			this.WriteMem(addr, bytes);
		}
		
        public void WriteInt(int addr, int value)
		{
			this.WriteMem(addr, BitConverter.GetBytes(value));
		}
		
        public void WriteFloat(int addr, float value)
		{
			this.WriteMem(addr, BitConverter.GetBytes(value));
		}
		
        public void WriteBytes(int addr, byte[] bytes)
		{
			this.WriteMem(addr, bytes);
		}
		
        private void Open()
		{
			this.procHandle = Kernel.OpenProcess(2035711u, false, this.Process.Id);
		}
		
        private bool Close()
		{
			if (!this.closed)
			{
				this.closed = true;
                return Kernel.CloseHandle(this.procHandle) != 0;
			}
			return true;
		}
		
        private byte[] ReadMem(int addr, int size)
		{
			byte[] array = new byte[size];
            Kernel.ReadProcessMemory(this.procHandle, (IntPtr)addr, array, size, 0);
			return array;
		}
		
        private void WriteMem(int addr, byte[] data)
		{
			int num = 0;
            if (!Kernel.WriteProcessMemory(this.procHandle, new IntPtr(addr), data, (uint)data.Length, out num))
			{
				Console.WriteLine(string.Concat(new object[]
				{
					"mem write addr ",
					addr.ToString("X"),
					" failed ",
					Marshal.GetLastWin32Error()
				}));
			}
		}
		
        public void MakeMemoryWriteable(int addr, int length)
		{
			uint num = 0u;
			if (!Memory.VirtualProtectEx(this.procHandle, new IntPtr(addr), new IntPtr(length), 64u, ref num))
			{
				Console.WriteLine("VirtualProtectEx failed! " + Marshal.GetLastWin32Error());
			}
		}
		[DllImport("kernel32.dll")]
		private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flNewProtect, ref uint lpflOldProtect);
		public int[] FindPatterns(params Pattern[] patterns)
		{
			byte[] exeImage = this.ReadBytes(this.BaseAddress, 0x2000000);
			int[] address = new int[patterns.Length];

			for (int iPattern = 0; iPattern < patterns.Length; iPattern++)
			{
				Pattern pattern = patterns[iPattern];
				byte[] patternData = pattern.Bytes;
				int patternLength = patternData.Length;

				for (int offset = 0; offset < exeImage.Length - patternLength; offset += 4)
				{
					if (this.CompareData(pattern, exeImage, offset)) {
						address[iPattern] = offset;
						Console.WriteLine("Pattern " + iPattern + " is found at " + (this.BaseAddress + offset).ToString("X"));
						break;
					}
				}
			}
			return address;
		}
		
        private bool CompareData(Pattern pattern, byte[] data, int offset)
		{
			for (int i = 0; i < pattern.Bytes.Length; i++)
			{
				if (pattern.Mask[i] == 'x' && pattern.Bytes[i] != data[offset + i])
				{
					return false;
				}
			}
			return true;
		}
	}
}
