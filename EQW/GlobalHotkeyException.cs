using System;

namespace EQW {
    public class GlobalHotkeyException : Exception {
        public GlobalHotkeyException(string message) : base(message) { }
        public GlobalHotkeyException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
