using System;

namespace EQW {
    public class HotKey {
        public HotKey(Modifiers mods, uint key) {
            Modifiers = mods;
            Key = key;
        }

        public HotKey() {}

        public Modifiers Modifiers { get; set; }
        public uint Key { get; set; }

        public static implicit operator
            Tuple<Modifiers, uint>(HotKey k) => k;
        public static explicit operator
            HotKey(Tuple<Modifiers, uint> t) => new HotKey(t.Item1, t.Item2);
        public static implicit operator
            string(HotKey k) => k.ToString();

        static readonly string Alt = "Alt+";
        static readonly string Ctrl = "Ctrl+";
        static readonly string Shift = "Shift+";

        public override string ToString() {
            var mods = Modifiers;
            var str = (int)(mods & Modifiers.SHIFT) > 0 ? Shift : string.Empty;
            str += (int)(mods & Modifiers.CTRL) > 0 ? Ctrl : string.Empty;
            str += (int)(mods & Modifiers.ALT) > 0 ? Alt : string.Empty;
            str += Enum.GetName(typeof(System.Windows.Forms.Keys), Key);
            return $"{str}";
        }
    }
}
