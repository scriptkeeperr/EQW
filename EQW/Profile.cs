namespace EQW {

    public class Profile {
        public string Name { get; set; }
        public HotKey HotKey { get; set; }
        public Profile(string name, HotKey hotKey) {
            Name = name;
            HotKey = hotKey;
        }
        public Profile() { }
    }
}
