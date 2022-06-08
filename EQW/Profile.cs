using System;

namespace EQW {

    public class Profile {

        public string Name { get; set; }
        public HotKey HotKey { get; set; }

        public Profile(string name, HotKey hotKey) {
            Name = name;
            HotKey = hotKey;
        }

        public Profile() { }

        public static implicit operator 
            string(Profile p) => p.ToString();

        public bool Equals(Profile p) {
            return p.GetHashCode().Equals(GetHashCode());
        }

        public override bool Equals(object obj) {
            var p = obj as Profile;
            return Equals(p);
        }

        public override string ToString() {
            return $"{Name} {HotKey}";
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, HotKey.ToString());
        }
    }
}
