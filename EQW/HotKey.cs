using System;

namespace EQW {
    public class HotKey {

        readonly Tuple<Modifiers, uint> combo;

        public HotKey(Modifiers mods, uint key) {
            combo = new Tuple<Modifiers, uint>(mods, key);
        }

        public Modifiers Modifiers => combo.Item1;
        public uint Key => combo.Item2;

        public static implicit operator
            Tuple<Modifiers, uint>(HotKey k) => k.combo;
        public static explicit operator
            HotKey(Tuple<Modifiers, uint> t) => new HotKey(t.Item1, t.Item2);
        public static implicit operator
            string(HotKey k) => k.ToString();

        static readonly string Alt = "Alt+";
        static readonly string Ctrl = "Ctrl+";
        static readonly string Shift = "Shift+";

        public override string ToString() {
            var mods = combo.Item1;
            var str = (int)(mods & Modifiers.SHIFT) > 0 ? Shift : string.Empty;
            str += (int)(mods & Modifiers.CTRL) > 0 ? Ctrl : string.Empty;
            str += (int)(mods & Modifiers.ALT) > 0 ? Alt : string.Empty;
            str += Enum.GetName(typeof(System.Windows.Forms.Keys), combo.Item2);
            return $"{str}";
        }
    }
}
