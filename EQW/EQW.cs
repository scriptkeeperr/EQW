using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;

namespace EQW {

    public partial class EQW : Form {

        [DllImport("User32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        //public class Profile {
        //    public string Name { get; set; }
        //    public HotKey HotKey { get; set; }

        //    public Profile(string name, HotKey hotKey) {
        //        Name = name;
        //        HotKey = hotKey;
        //    }
        //    public Profile() { }
        //}

        #region test data
        string proccessName = "eqgame";

        static readonly Dictionary<string, HotKey> profiles = new Dictionary<string, HotKey>();//{
        //        new Profile {Name = "Veeno",
        //            HotKey = new HotKey(Modifiers.ALT, (uint)Keys.D1)},
        //        new Profile {Name = "Krizma",
        //            HotKey = new HotKey(Modifiers.ALT, (uint)Keys.D2)},
        //        new Profile {Name = "Xlag",
        //            HotKey = new HotKey(Modifiers.ALT, (uint)Keys.D3)}
        //};
        #endregion


        Control label;
        Font icons = new Font("Segoe MDL2 Assets", 11);

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

        void originalLayoutMethod(Process[] processes) {
            int top = 12, left = 12;
            foreach (var p in processes) {
                var b = new Button() {
                    Text = p.Id.ToString(),
                    Top = top,
                    Left = left,
                };

                b.Click += (o, e) => {
                    IntPtr handle = p.MainWindowHandle;
                    SwitchToThisWindow(handle, true);
                };

                var cb = new ComboBox() {
                    Top = top,
                    Left = b.Right + 4,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                foreach (var pf in profiles) {
                    cb.Items.Add(pf.Key);
                }

                cb.SelectionChangeCommitted += (o, e) => {
                    var profileHotKey = profiles[cb.Text];
                    b.Text = cb.Text;
                    var ghk = new GlobalHotKey(
                        Handle, p.MainWindowHandle,
                        profileHotKey.Modifiers,
                        profileHotKey.Key
                    );
                };

                var del = new Button() {
                    Top = top - 1,
                    Left = cb.Right + 4,
                    Font = icons,
                    Text = "\uE74D",
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Height = cb.Height,
                };

                del.Click += (o, e) => {
                    top = b.Top;
                    b.Dispose();
                    cb.Dispose();
                    del.Dispose();
                    buttonFind.Top = textBoxProcName.Top = top;
                };

                top = b.Bottom + 4;
            }
        }
        static DataGridViewComboBoxCell ProfilesBox;
        void AddControls(Process[] processes) {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Font = icons;
            if (ProfilesBox == null) {
                ProfilesBox = new DataGridViewComboBoxCell();
            } else {
                ProfilesBox.Items.Clear();
            }
            ProfilesBox.Items.AddRange(profiles);

            var bcWindow = new DataGridViewButtonColumn() {
                Name = "Window",
                DataPropertyName = "PID",
                ReadOnly = true,
            };

            var cbcProfiles = new DataGridViewComboBoxColumn() {
                Name = "Profiles",
                DataPropertyName = "Profiles",
            };

            var bcDelete = new DataGridViewButtonColumn() {
                Name = "Delete",
                Text = "\uE74E",
            };
            bcDelete.Text = "shit";

            dataGridView1.Columns.AddRange(
                new DataGridViewColumn[] { bcWindow, cbcProfiles, bcDelete }
            );

            foreach (var pf in profiles) {
                cbcProfiles.Items.Add(pf.Key);
            }

            DataGridViewRow row = null;
            foreach (var p in processes) {
                row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewButtonCell() {
                    Value = p.Id.ToString(),
                    Tag = p.MainWindowHandle
                });
                row.Cells.Add(ProfilesBox);
                row.Cells.Add(new DataGridViewButtonCell() {
                    Value = "\uE74E",
                    Tag = p.MainWindowHandle
                });

                dataGridView1.Rows.Add(row);
            }
            row = null;

            dataGridView1.CellClick += (o, e) => {
                if (e.RowIndex >= 0) {
                    if (e.ColumnIndex == dataGridView1.Columns["Window"].Index) {
                        var handle =
                            (IntPtr)dataGridView1[e.ColumnIndex, e.RowIndex].Tag;
                        SwitchToThisWindow(handle, true);
                    }
                }
            };

            dataGridView1.CellValueChanged += (o, e) => {
                var profileHotKey = profiles[
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()
                ];

                var ghk = new GlobalHotKey(
                    Handle,
                    (IntPtr)dataGridView1[
                        dataGridView1.Columns["Window"].Index, e.RowIndex
                    ].Tag,
                    profileHotKey.Modifiers,
                    profileHotKey.Key
                );

                dataGridView1.Invalidate();
            };

            dataGridView1.CurrentCellDirtyStateChanged += (o, e) => {
                if (dataGridView1.IsCurrentCellDirty) {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            dataGridView1.MultiSelect = false;

            dataGridView1.SelectionChanged += (o, e) => {
                var cel = o as DataGridViewComboBoxCell;
                if (cel != null) {
                    var profileHotKey = (HotKey)cel.Value;//profiles[cb.Text];
                    //b.Text = cb.Text;
                    var ghk = new GlobalHotKey(
                        Handle, //p.MainWindowHandle,
                        (IntPtr)dataGridView1.SelectedRows[0].Cells["Window"].Tag,
                        profileHotKey.Modifiers,
                        profileHotKey.Key
                    ); ;
                }
            };
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
            profiles.Add("Veeno", new HotKey(Modifiers.ALT, (uint)Keys.D1));
            profiles.Add("Krizma", new HotKey(Modifiers.ALT, (uint)Keys.D2));
            profiles.Add("Xlag", new HotKey(Modifiers.ALT, (uint)Keys.D3));
            dataGridView1.Font = icons;
            buttonFind.Font = buttonSave.Font = icons;
            buttonFind.Text = "\uE773";
            buttonSave.Text = "\uE74E";
            InitializeProcessButtons();
            FormClosing += EQW_FormClosing;
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
            var mods = Modifiers.NONE;

            mods |= checkBoxAlt.Checked ? Modifiers.ALT : 0;
            mods |= checkBoxCtrl.Checked ? Modifiers.CTRL : 0;
            mods |= checkBoxShift.Checked ? Modifiers.SHIFT : 0;

            // get the key
            var key = (uint)textBoxKey.Tag;

            // get the name
            var name = textBoxProfileName.Text;

            //var profile = new Profile(name, new HotKey(mods, key));
            // save to disk

            //dataGridView.Rows.Add(profile);
            //await Save();
            //profiles.Add(profile);
            profiles.Add(name, new HotKey(mods, key));
            Save();
            dataGridView.Refresh();
        }

        static void Save() {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(profiles, options);
            string fileName = "profiles.json";
            File.WriteAllText(fileName, json);
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
