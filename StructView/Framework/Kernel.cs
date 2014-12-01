using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StructView.Framework
{
	public class Kernel
	{
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint access, bool inheritHandle, int processId);
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int CloseHandle(IntPtr hObject);
		[DllImport("kernel32.dll")]
		public static extern void ReadProcessMemory(IntPtr hProcess, IntPtr baseAddress, byte[] buffer, int size, int bytesRead);
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);
	}
}
