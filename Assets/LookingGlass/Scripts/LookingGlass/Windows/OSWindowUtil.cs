using System;
using System.Runtime.InteropServices;
using UnityEngine;
using LookingGlass.Toolkit;

namespace LookingGlass {
    //NOTE: WINDOWS-ONLY as currently written!
    internal static class OSWindowUtil {
        private const string User32DLL = "User32";
        private const string Kernel32DLL = "Kernel32";

        [DllImport(Kernel32DLL)]
        public static extern uint GetLastError();

        [DllImport(User32DLL)]
        public static extern bool EnumWindows(Func<IntPtr, int, bool> callbackPerWindow, int unknown);

        [DllImport(User32DLL)]
        public static extern bool GetWindowRect(IntPtr window, out ScreenRect result);

        [DllImport(User32DLL)]
        public static extern bool SetWindowPos(IntPtr window, IntPtr insertAfter, int left, int top, int width, int height, uint flags);

        [DllImport(User32DLL)]
        private static extern int GetWindowTextLengthW(IntPtr window);

        [DllImport(User32DLL)]
        private static extern int GetWindowTextW(IntPtr window, [MarshalAs(UnmanagedType.LPWStr)] char[] title, int maxCharacters);

        public static string GetWindowTextW(IntPtr window) {
            int length = GetWindowTextLengthW(window);
            if (length <= 0)
                return "";

            //NOTE: The last param of GetWindowTextW(...), nMaxCount, INCLUDES the NULL character, so +1!
            char[] buffer = new char[length + 1];
            int count = GetWindowTextW(window, buffer, length + 1);
            return new string(buffer, 0, length);
        }
    }
}
