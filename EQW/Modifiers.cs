using System;

namespace EQW {
    [Flags]
    public enum Modifiers {
        NONE = 0x0000,
        ALT = 0x0001,
        CTRL = 0x0002,
        SHIFT = 0x0004,
        //WIN = 0x0008,
        MOD_NOREPEAT = 0x4000,
    }
}
