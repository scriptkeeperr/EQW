using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
//using System.Text.Json;
//using System.Text.Json.Serialization;

namespace EQW {

    public partial class EQW : Form {

        [DllImport("User32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);


        public class Profile {
            public string Name { get; set; }
            public HotKey HotKey { get; set; }

        }

        #region test data
        readonly string proccessName = "eqgame";
        readonly Profile[] profiles = new Profile[] {
                new Profile {Name = "Veeno",
                    HotKey = new HotKey(Modifiers.CTRL, (uint)Keys.D1)},
                new Profile {Name = "Krizma",
                    HotKey = new HotKey(Modifiers.CTRL, (uint)Keys.D2)},
                new Profile {Name = "Xlag",
                    HotKey = new HotKey(Modifiers.CTRL, (uint)Keys.D3)}
        };
        #endregion

        bool labelAdded = false;

        void InitializeProcessButtons() {
            Process[] processes = Process.GetProcessesByName(proccessName);

            if (processes.Length > 0) {
                AddControls(processes);
                return;
            }

            if (!labelAdded) {
                var label = new Label() {
                    Text = $"no {proccessName} running",
                    Width = Width,
                    AutoSize = true,
                    Font = new System.Drawing.Font(
                        System.Drawing.FontFamily.GenericMonospace.Name, 40),
                    BorderStyle = BorderStyle.FixedSingle
                };
                Controls.Add(label);
                labelAdded = true;
            }
        }

        void AddControls(Process[] processes) {
            int nextTop = 4;
            foreach (var p in processes) {
                var b = new Button() {
                    Text = p.Id.ToString(),
                    Top = nextTop,
                    Left = 4,
                };

                b.Click += (o, e) => {
                    IntPtr handle = p.MainWindowHandle;
                    SwitchToThisWindow(handle, true);
                };

                var cb = new ComboBox() {
                    Top = nextTop,
                    Left = b.Right + 4,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                foreach (var pf in profiles) {
                    cb.Items.Add(pf.Name);
                }

                cb.SelectionChangeCommitted += (o, e) => {
                    var profileHotKey = profiles[cb.SelectedIndex].HotKey;
                    b.Text = profiles[cb.SelectedIndex].Name;
                    var ghk = new GlobalHotKey(
                        Handle, p.MainWindowHandle,
                        profileHotKey.Modifiers,
                        profileHotKey.Key
                    );
                };

                Controls.Add(b);
                Controls.Add(cb);

                nextTop = b.Bottom + 4;
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
            InitializeProcessButtons();
            FormClosing += EQW_FormClosing;
            dataGridView1.DataSource = profiles;
        }

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
            //var mods = Modifiers.NONE;

            //mods |= checkBoxAlt.Checked ? Modifiers.ALT : 0;
            //mods |= checkBoxCtrl.Checked ? Modifiers.CTRL : 0;
            //mods |= checkBoxShift.Checked ? Modifiers.SHIFT : 0;

            // get the key

            // get the name

            // save to disk
        }

        private void EQW_FormClosing(object sender, FormClosingEventArgs e) {
            GlobalHotKey.Handles.Clear();
        }

    }
}