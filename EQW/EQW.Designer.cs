
namespace EQW {
    partial class EQW {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EQW));
            this.labelAddProfile = new System.Windows.Forms.Label();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.checkBoxAlt = new System.Windows.Forms.CheckBox();
            this.checkBoxCtrl = new System.Windows.Forms.CheckBox();
            this.checkBoxShift = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.buttonSetHotKey = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.panelProcs = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbProcesses = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAddProfile
            // 
            this.labelAddProfile.AutoSize = true;
            this.labelAddProfile.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAddProfile.Location = new System.Drawing.Point(322, 10);
            this.labelAddProfile.Name = "labelAddProfile";
            this.labelAddProfile.Size = new System.Drawing.Size(79, 16);
            this.labelAddProfile.TabIndex = 0;
            this.labelAddProfile.Text = "Add Profile";
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.Location = new System.Drawing.Point(407, 8);
            this.textBoxProfileName.MaxLength = 100;
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.PlaceholderText = "name";
            this.textBoxProfileName.Size = new System.Drawing.Size(123, 23);
            this.textBoxProfileName.TabIndex = 1;
            // 
            // checkBoxAlt
            // 
            this.checkBoxAlt.AutoSize = true;
            this.checkBoxAlt.Location = new System.Drawing.Point(330, 41);
            this.checkBoxAlt.Name = "checkBoxAlt";
            this.checkBoxAlt.Size = new System.Drawing.Size(41, 19);
            this.checkBoxAlt.TabIndex = 3;
            this.checkBoxAlt.Text = "Alt";
            this.checkBoxAlt.UseVisualStyleBackColor = true;
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.AutoSize = true;
            this.checkBoxCtrl.Location = new System.Drawing.Point(375, 41);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(45, 19);
            this.checkBoxCtrl.TabIndex = 4;
            this.checkBoxCtrl.Text = "Ctrl";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            // 
            // checkBoxShift
            // 
            this.checkBoxShift.AutoSize = true;
            this.checkBoxShift.Location = new System.Drawing.Point(423, 41);
            this.checkBoxShift.Name = "checkBoxShift";
            this.checkBoxShift.Size = new System.Drawing.Size(50, 19);
            this.checkBoxShift.TabIndex = 5;
            this.checkBoxShift.Text = "Shift";
            this.checkBoxShift.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(572, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonSetHotKey
            // 
            this.buttonSetHotKey.Location = new System.Drawing.Point(536, 7);
            this.buttonSetHotKey.Name = "buttonSetHotKey";
            this.buttonSetHotKey.Size = new System.Drawing.Size(76, 23);
            this.buttonSetHotKey.TabIndex = 2;
            this.buttonSetHotKey.Text = "Set Hot Key";
            this.buttonSetHotKey.UseVisualStyleBackColor = true;
            this.buttonSetHotKey.Click += new System.EventHandler(this.ButtonSetHotKey_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(476, 39);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.PlaceholderText = "key";
            this.textBoxKey.Size = new System.Drawing.Size(90, 23);
            this.textBoxKey.TabIndex = 9;
            this.textBoxKey.Enter += new System.EventHandler(this.ButtonSetHotKey_Click);
            this.textBoxKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKey_KeyDown);
            this.textBoxKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxKey_KeyUp);
            this.textBoxKey.Leave += new System.EventHandler(this.TextBoxKey_Leave);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(12, 37);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 10;
            this.btnFind.Text = "Find";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // panelProcs
            // 
            this.panelProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelProcs.AutoScroll = true;
            this.panelProcs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProcs.Location = new System.Drawing.Point(12, 70);
            this.panelProcs.Name = "panelProcs";
            this.panelProcs.Padding = new System.Windows.Forms.Padding(4);
            this.panelProcs.Size = new System.Drawing.Size(290, 359);
            this.panelProcs.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(330, 70);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(282, 359);
            this.dataGridView.TabIndex = 12;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "EQW";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // cbProcesses
            // 
            this.cbProcesses.FormattingEnabled = true;
            this.cbProcesses.Location = new System.Drawing.Point(90, 37);
            this.cbProcesses.Name = "cbProcesses";
            this.cbProcesses.Size = new System.Drawing.Size(180, 23);
            this.cbProcesses.TabIndex = 13;
            this.cbProcesses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBoxProcName_KeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(279, 37);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // EQW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbProcesses);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelProcs);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkBoxShift);
            this.Controls.Add(this.checkBoxCtrl);
            this.Controls.Add(this.checkBoxAlt);
            this.Controls.Add(this.buttonSetHotKey);
            this.Controls.Add(this.textBoxProfileName);
            this.Controls.Add(this.labelAddProfile);
            this.Name = "EQW";
            this.Text = "EQW";
            this.Resize += new System.EventHandler(this.EQW_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddProfile;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.CheckBox checkBoxAlt;
        private System.Windows.Forms.CheckBox checkBoxCtrl;
        private System.Windows.Forms.CheckBox checkBoxShift;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button buttonSetHotKey;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.FlowLayoutPanel panelProcs;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ComboBox cbProcesses;
        private System.Windows.Forms.Button btnRefresh;
    }
}

