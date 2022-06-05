using System;

namespace EQW {
    public class HotKeyMessage {
        public static int WM_HOTKEY = 0x0312; // constant from "windows.h"
        public readonly HotKey combo;
        public readonly IntPtr hWnd;

        private HotKeyMessage(IntPtr lParam) {
            var lpInt = (int)lParam;
            var key = (uint)(lpInt >> 16) & 0xFFFF;
            var modifiers = (Modifiers)(lpInt & 0xFFFF);
            combo = new HotKey(modifiers, key);
        }

        public static HotKeyMessage GetFromMessage(System.Windows.Forms.Message m) {
            return m.Msg != WM_HOTKEY ? null : new HotKeyMessage(m.LParam);
        }
    }
}
