using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace EQW {

    public partial class EQW : Form {

        [DllImport("User32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport("User32.dll")]
        static extern void SetWindowTextA(IntPtr hWnd, string text);

        static readonly List<int> processIDs = new List<int>();

        readonly Font icons = new Font("Segoe MDL2 Assets", 11);

        Control label;

        string proccessName = "eqgame";

        public EQW() {
            try {
                InitializeComponent();
                MinimumSize = new Size(640, 240);
                EQW_Resize(this, EventArgs.Empty);
                cbProcesses.Text = proccessName;
                FormClosing += EQW_FormClosing;
                ProfileManager.LoadProfiles();
                InitializeProcessList();
                InitializeProcessPanels();
                InitializeDataGridView();
                btnFind.Font = btnSave.Font =
                btnRefresh.Font = dataGridView.Font = icons;
                btnFind.Text = "\uE773";
                btnSave.Text = "\uE74E";
                btnRefresh.Text = "\uE72C";
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        Process[] ProcessFilter(Process[] processes) {
            return processes.Where(
                p => !processIDs.Contains(p.Id)
            ).ToArray();
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

        #region dynamic layout functions

        void InitializeDataGridView() {
            dataGridView.Font = icons;
            dataGridView.DataSource = ProfileManager.Profiles;
            dataGridView.Columns.Add(new DataGridViewButtonColumn() {
                Name = "Delete",
                HeaderText = string.Empty,
                Text = "\uE74D", // trash can
                UseColumnTextForButtonValue = true,
                Width = dataGridView.ColumnHeadersHeight,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
        }

        void InitializeProcessList() {
            var allProcs = Process.GetProcesses().Where(
                p => p.MainWindowHandle != IntPtr.Zero
            ).ToArray();

            cbProcesses.Items.Clear();
            foreach (Process p in allProcs) {
                cbProcesses.Items.Add(p.ProcessName);
            }
        }

        void InitializeProcessPanels() {
            Process[] processes =
                Process.GetProcessesByName(cbProcesses.Text);
            if (processes.Length > 0) {
                AddPanels(processes);
                if (label != null) {
                    label.Dispose();
                }
                return;
            }
            AddLabel();
        }

        void AddLabel() {
            if (!proccessName.Equals(cbProcesses.Text)) {
                label = null;
                proccessName = cbProcesses.Text;
            }

            if (label == null) {
                label = new Label() {
                    Top = 12,
                    Left = 12,
                    AutoSize = true
                };

                label.Click += (o, e) => {
                    InitializeProcessPanels();
                };
                Controls.Add(label);
            }

            label.Text = $"no {proccessName} running";
        }

        void AddPanels(Process[] processes) {
            var procs = ProcessFilter(processes);
            Panel[] panels = new Panel[procs.Length];

            for (int i = 0; i < procs.Length; i++) {
                Process p = procs[i];
                processIDs.Add(p.Id);

                var b = new Button() {
                    Tag = p.Id,
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
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Width = panelProcs.Width - 40,
                    Height = cb.Height + 8,
                    Tag = p.Id
                };

                foreach (var pf in ProfileManager.Profiles) {
                    cb.Items.Add(pf.Name);
                }

                b.Click += (o, e) => {
                    IntPtr handle = p.MainWindowHandle;
                    SwitchToThisWindow(handle, true);
                };

                cb.Click += (o, e) => {
                    if (cb.Items.Count != ProfileManager.Profiles.Count) {
                        var selected = cb.SelectedItem;
                        if (selected != null) {
                            cb.Items.Clear();
                            foreach (var pf in ProfileManager.Profiles) {
                                cb.Items.Add(pf.Name);
                            }
                            if (cb.Items.Contains(selected)) {
                                cb.SelectedItem = selected;
                            }
                        }
                    }
                };

                cb.SelectionChangeCommitted += (o, e) => {
                    var profile = ProfileManager.Profiles[cb.SelectedIndex];
                    panel.Tag = GlobalHotKey.Create(
                        Handle, p.MainWindowHandle, profile.HotKey
                    );
                    b.Text = cb.Text;
                    SetWindowTextA(p.MainWindowHandle, profile.Name);
                };

                del.Click += (o, e) => {
                    processIDs.Remove((int)b.Tag);
                    if (panel.Tag is GlobalHotKey ghk) {
                        ghk.Dispose();
                    }
                    b.Dispose();
                    cb.Dispose();
                    del.Dispose();
                    panel.Dispose();
                };

                panel.Controls.AddRange(new Control[] { b, cb, del });
                panelProcs.Controls.Add(panel);
            }
        }

        #endregion

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
                btnSave.Focus();
            }
        }

        private void CheckBoxes(KeyEventArgs e) {
            checkBoxAlt.Checked = e.Alt;
            checkBoxCtrl.Checked = e.Control;
            checkBoxShift.Checked = e.Shift;
        }

        private void CheckBoxes(Modifiers m) {
            checkBoxAlt.Checked = (Modifiers.ALT & m) > 0;
            checkBoxCtrl.Checked = (Modifiers.CTRL & m) > 0;
            checkBoxShift.Checked = (Modifiers.SHIFT & m) > 0;
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

                if (name != string.Empty) {
                    try {
                        ProfileManager.Add(new Profile(name, new HotKey(mods, key)));
                    } catch (ProfileExistsException ex) {
                        MessageBox.Show($"{ex}");
                    }
                }
            }
        }

        private void EQW_FormClosing(object sender, FormClosingEventArgs e) {
            processIDs.Clear();
            GlobalHotKey.Handles.Clear();
        }

        private void ButtonFind_Click(object sender, EventArgs e) {
            InitializeProcessPanels();
        }

        private void ComboBoxProcName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                InitializeProcessPanels();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                var profile = ProfileManager.Profiles[e.RowIndex];
                textBoxProfileName.Text = profile.Name;
                textBoxKey.Text = Enum.GetName(typeof(Keys), profile.HotKey.Key);
                CheckBoxes(profile.HotKey.Modifiers);
                if (e.ColumnIndex == dataGridView.Columns["Delete"].Index) {
                    ProfileManager.Remove(profile);
                }
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void EQW_Resize(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                Hide();
                notifyIcon.Visible = true;
            } else {
                panelProcs.Width = Width / 2 - 24;
                panelProcs.Height = Height - btnFind.Bottom - 64;
                panelProcs.Top = btnFind.Bottom + 12;
                dataGridView.Width = panelProcs.Width - 6;
                dataGridView.Height = panelProcs.Height;
                dataGridView.Top = panelProcs.Top;
                dataGridView.Left = panelProcs.Right + 12;
                pnlProfile1.Left = dataGridView.Left;
                if(dataGridView.Width > pnlProfile1.Width * 2) {
                    pnlProfile2.Left = pnlProfile1.Right + 4;
                    pnlProfile1.Top = pnlProfile2.Top;
                } else {
                    pnlProfile2.Left = dataGridView.Left;
                    pnlProfile1.Top = 12;
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e) {
            InitializeProcessList();
        }

        #endregion

    }
}
