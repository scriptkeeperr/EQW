using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace EQW {

    public partial class EQW : Form {

        [DllImport("User32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        public class Game { }

        public EQW() {
            InitializeComponent();
            Process[] processes = Process.GetProcessesByName("eqgame");

            //if (processes.Length > 0) {
            //    IntPtr handle = processes[0].MainWindowHandle;
            //    SwitchToThisWindow(handle, true);
            //}

            int nextTop = 4;
            foreach (var p in processes) {
                //label1.Text += $"{p.Id} {p.Handle} {p.ProcessName}\n";
                var b = new Button() {
                    Text = p.Id.ToString(),
                    Top = nextTop,
                    Left = 4
                };
                b.Click += (o, e) => {
                    IntPtr handle = p.MainWindowHandle;
                    SwitchToThisWindow(handle, true);
                };

                Controls.Add(b);
                nextTop = b.Bottom + 4;
            }

        }
    }
}