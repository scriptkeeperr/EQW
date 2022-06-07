using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;

namespace EQW {

    public partial class EQW : Form {

        [DllImport("User32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        public class Profile {
            public string Name { get; set; }
            public HotKey HotKey { get; set; }
            public Profile(string name, HotKey hotKey) {
                Name = name;
                HotKey = hotKey;
            }
            public Profile() { }
        }

        static readonly BindingList<Profile> profiles = new BindingList<Profile>();

        static readonly List<int> processIDs = new List<int>();

        readonly Font icons = new Font("Segoe MDL2 Assets", 11);

        Control label;

        string proccessName = "eqgame";

        Process[] ProcessFilter(Process[] processes) {
            return processes.Where(p => !processIDs.Contains(p.Id)).ToArray();
        }

        void InitializeProcessButtons() {
            proccessName = textBoxProcName.Text;
            Process[] processes = Process.GetProcessesByName(proccessName);
            if (processes.Length > 0) {
                AddControls(processes);
                if (label != null) {
                    label.Dispose();
                }
                return;
            }
            AddLabel();
        }

        void AddLabel() {
            if (label == null) {
                label = new Label() {
                    Text = $"no {proccessName} running - click here after opening",
                    Top = buttonFind.Bottom + 12,
                    Left = 12,
                };

                label.Click += (o, e) => {
                    InitializeProcessButtons();
                };

                Controls.Add(label);
            }
        }

        void AddControls(Process[] processes) {
            var procs = ProcessFilter(processes);
            Panel[] panels = new Panel[procs.Length];

            for (int i = 0; i < procs.Length; i++) {
                Process p = procs[i];
                processIDs.Add(p.Id);
                var b = new Button() {
                    Text = p.Id.ToString(),
                    Top = 4,
                    Left = 4
                };

                var cb = new ComboBox() {
                    Top = b.Top,
                    Left = b.Right + 4,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                var del = new Button() {
                    Top = cb.Top - 1,
                    Left = cb.Right + 4,
                    Font = icons,
                    Text = "\uE74D",
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Height = cb.Height,
                };

                var panel = new Panel() {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Width = panelProcs.Width - 40,
                    Height = cb.Height + 8,
                    Tag = p.Id
                };

                foreach (var pf in profiles) {
                    cb.Items.Add(pf.Name);
                }

                b.Click += (o, e) => {
                    IntPtr handle = p.MainWindowHandle;
                    SwitchToThisWindow(handle, true);
                };

                cb.Click += (o, e) => {
                    if(cb.Items.Count != profiles.Count) {
                        var selected = cb.SelectedItem;
                        cb.Items.Clear();
                        foreach (var pf in profiles) {
                            cb.Items.Add(pf.Name);
                        }
                        if (cb.Items.Contains(selected)) {
                            cb.SelectedItem = selected;
                        }
                    }
                };

                cb.SelectionChangeCommitted += (o, e) => {
                    var profileHotKey = profiles[cb.SelectedIndex].HotKey;
                    b.Text = cb.Text;
                    var ghk = new GlobalHotKey(
                        Handle, p.MainWindowHandle,
                        profileHotKey.Modifiers,
                        profileHotKey.Key
                    );
                };

                del.Click += (o, e) => {
                    processIDs.Remove((int)panel.Tag);
                    b.Dispose();
                    cb.Dispose();
                    del.Dispose();
                    panel.Dispose();
                };

                panel.Controls.AddRange(new Control[] { b, cb, del });
                panelProcs.Controls.Add(panel);
            }
        }

        protected override void WndProc(ref Message m) {
            var hotKey = HotKeyMessage.GetFromMessage(m);
            if (hotKey != null) {
                if (!GlobalHotKey.Handles.ContainsKey(hotKey.combo)) {
                    return;
                }
                SwitchToThisWindow(GlobalHotKey.Handles[hotKey.combo], true);
            }
            base.WndProc(ref m);
        }

        public EQW() {
            InitializeComponent();
            //profiles.Add(new Profile("Veeno", new HotKey(Modifiers.ALT, (uint)Keys.D1)));
            //profiles.Add(new Profile("Krizma", new HotKey(Modifiers.ALT, (uint)Keys.D2)));
            //profiles.Add(new Profile("Xlag", new HotKey(Modifiers.ALT, (uint)Keys.D3)));

            FormClosing += EQW_FormClosing;
            buttonFind.Font = buttonSave.Font = icons;
            buttonFind.Text = "\uE773";
            buttonSave.Text = "\uE74E";

            InitializeProcessButtons();
            LoadProfiles();

            dataGridView.DataSource = profiles;
        }

        #region event functions
        private void ButtonSetHotKey_Click(object sender, EventArgs e) {
            buttonSetHotKey.Text = "Listening";
            if (!textBoxKey.Focused) {
                textBoxKey.Focus();
            }
        }

        private void TextBoxKey_KeyDown(object sender, KeyEventArgs e) {
            e.SuppressKeyPress = true;
            CheckBoxes(e);
            if ((e.KeyCode & (Keys.ControlKey | Keys.Menu | Keys.ShiftKey)) != e.KeyCode) {
                textBoxKey.Text = Enum.GetName(typeof(Keys), e.KeyCode);
                textBoxKey.Tag = (uint)e.KeyCode;
                buttonSave.Focus();
            }
        }

        private void CheckBoxes(KeyEventArgs e) {
            checkBoxAlt.Checked = e.Alt;
            checkBoxCtrl.Checked = e.Control;
            checkBoxShift.Checked = e.Shift;
        }

        private void TextBoxKey_Leave(object sender, EventArgs e) {
            buttonSetHotKey.Text = "Set Hot Key";
        }

        private void TextBoxKey_KeyUp(object sender, KeyEventArgs e) {
            if ((e.KeyCode & (Keys.ControlKey | Keys.Menu | Keys.ShiftKey)) == e.KeyCode) {
                CheckBoxes(e);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            if (textBoxKey.Tag != null) {
                var mods = Modifiers.NONE;
                var key = (uint)textBoxKey.Tag;
                var name = textBoxProfileName.Text;

                mods |= checkBoxAlt.Checked ? Modifiers.ALT : 0;
                mods |= checkBoxCtrl.Checked ? Modifiers.CTRL : 0;
                mods |= checkBoxShift.Checked ? Modifiers.SHIFT : 0;

                var p = new Profile(name, new HotKey(mods, key));

                if (name != string.Empty && !profiles.Contains(p)) {
                    profiles.Add(p);
                }
                Save();
                dataGridView.Invalidate();
            }
        }

        static void Save() {
            var options = new JsonSerializerOptions { WriteIndented = true };
            byte[] json = JsonSerializer.SerializeToUtf8Bytes(profiles, options);
            string fileName = "profiles.json";
            File.WriteAllBytes(fileName, json);
        }

        static void LoadProfiles() {
            string fileName = "profiles.json";
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

        private void EQW_FormClosing(object sender, FormClosingEventArgs e) {
            GlobalHotKey.Handles.Clear();
        }

        private void ButtonFind_Click(object sender, EventArgs e) {
            InitializeProcessButtons();
        }

        private void TextBoxProcName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                InitializeProcessButtons();
            }
        }
        #endregion

    }
}
