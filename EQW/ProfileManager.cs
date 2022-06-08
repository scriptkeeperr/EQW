using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EQW {

    public static class ProfileManager {

        static readonly BindingList<Profile> profiles =
            new BindingList<Profile>();

        public static BindingList<Profile> Profiles => profiles;

        public static void Add(Profile profile) {
            if (!Contains(profile)) {
                profiles.Add(profile);
                Save();
            } else {
                throw new ProfileExistsException(
                    $"Profile: {profile} already exists."
                );
            }
        }

        public static void Remove(Profile profile) {
            profiles.Remove(profile);
            Save();
        }

        public static bool Contains(Profile profile) {
            foreach (var p in Profiles) {
                if (p.Equals(profile)) {
                    return true;
                }
            }
            return false;
        }

        public static void Save() {
            var options = 
                new JsonSerializerOptions { WriteIndented = true };
            byte[] json = 
                JsonSerializer.SerializeToUtf8Bytes(profiles, options);
            string fileName = "profiles.json";
            File.WriteAllBytes(fileName, json);
        }

        public static void LoadProfiles() {
            string fileName = "profiles.json";

            if (File.Exists(fileName)) {
                byte[] utf8Json = File.ReadAllBytes(fileName);
                var utf8Reader = new Utf8JsonReader(utf8Json);
                if (utf8Json.Length > 0) {
                    var temp = JsonSerializer.Deserialize<BindingList<Profile>>(ref utf8Reader).ToList();
                    profiles.Clear();
                    foreach (var p in temp) {
                        profiles.Add(p);
                    }
                }
            }
        }
    }
}
