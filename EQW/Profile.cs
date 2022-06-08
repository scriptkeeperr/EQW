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
        public override bool Equals(object obj) {
            var p = obj as Profile;
            return p.ToString().Equals(ToString());
        }
        public override string ToString() {
            return $"{Name} {HotKey}";
        }
    }
}
