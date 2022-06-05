using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace EQW {

    public class GlobalHotKey : IDisposable {

        [DllImport("User32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("User32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public static Dictionary<string, IntPtr> Handles { get; private set; } =
            new Dictionary<string, IntPtr>();

        readonly IntPtr formHandle;
        readonly IntPtr hWnd; // proccess window
        readonly int id;
        readonly Modifiers mods;
        readonly uint key;
        readonly HotKey hotKey;
        bool registered = false;
        bool disposed = false;

        public GlobalHotKey(IntPtr formHandle, IntPtr hWnd, Modifiers mods, uint key) {
            this.formHandle = formHandle;
            this.hWnd = hWnd;
            this.mods = mods;
            this.key = key;
            hotKey = new HotKey(mods, key);
            id = GetHashCode();
            Register();
        }

        public override int GetHashCode() {
            return formHandle.ToInt32() ^ (int)mods ^ (int)key;
        }

        void Register() {
            Unregister();
            if (!RegisterHotKey(formHandle, id, (uint)mods, key)) {
                throw new GlobalHotkeyException("Failed to register global hotkey");
            }
            Handles.Add(hotKey, hWnd);
            registered = true;
        }

        void Unregister() {
            registered = Handles.ContainsKey(hotKey);
            if (!registered) {
                return;
            }
            if (!UnregisterHotKey(formHandle, id)) {
                throw new GlobalHotkeyException("Failed to unregister global hotkey");
            }
            if (Handles.Remove(hotKey)) {
                registered = false;
            }
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing) {
            if (!disposed) {
                Unregister();
                registered = false;
                disposed = true;
                if (disposing) {
                    GC.SuppressFinalize(this);
                }
            }
        }
    }
}
