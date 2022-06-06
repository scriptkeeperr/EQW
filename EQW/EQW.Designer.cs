
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
            this.labelAddProfile = new System.Windows.Forms.Label();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.checkBoxAlt = new System.Windows.Forms.CheckBox();
            this.checkBoxCtrl = new System.Windows.Forms.CheckBox();
            this.checkBoxShift = new System.Windows.Forms.CheckBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSetHotKey = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBoxProcName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.checkBoxAlt.Location = new System.Drawing.Point(322, 41);
            this.checkBoxAlt.Name = "checkBoxAlt";
            this.checkBoxAlt.Size = new System.Drawing.Size(41, 19);
            this.checkBoxAlt.TabIndex = 3;
            this.checkBoxAlt.Text = "Alt";
            this.checkBoxAlt.UseVisualStyleBackColor = true;
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.AutoSize = true;
            this.checkBoxCtrl.Location = new System.Drawing.Point(369, 41);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(45, 19);
            this.checkBoxCtrl.TabIndex = 4;
            this.checkBoxCtrl.Text = "Ctrl";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            // 
            // checkBoxShift
            // 
            this.checkBoxShift.AutoSize = true;
            this.checkBoxShift.Location = new System.Drawing.Point(420, 41);
            this.checkBoxShift.Name = "checkBoxShift";
            this.checkBoxShift.Size = new System.Drawing.Size(50, 19);
            this.checkBoxShift.TabIndex = 5;
            this.checkBoxShift.Text = "Shift";
            this.checkBoxShift.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(322, 70);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(286, 359);
            this.dataGridView.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(572, 41);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(40, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
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
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(12, 12);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 10;
            this.buttonFind.Text = "Find";
            this.buttonFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // textBoxProcName
            // 
            this.textBoxProcName.Location = new System.Drawing.Point(90, 12);
            this.textBoxProcName.Name = "textBoxProcName";
            this.textBoxProcName.Size = new System.Drawing.Size(123, 23);
            this.textBoxProcName.TabIndex = 11;
            this.textBoxProcName.Text = "notepad";
            this.textBoxProcName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxProcName_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(303, 388);
            this.dataGridView1.TabIndex = 13;
            // 
            // EQW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxProcName);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.checkBoxShift);
            this.Controls.Add(this.checkBoxCtrl);
            this.Controls.Add(this.checkBoxAlt);
            this.Controls.Add(this.buttonSetHotKey);
            this.Controls.Add(this.textBoxProfileName);
            this.Controls.Add(this.labelAddProfile);
            this.Name = "EQW";
            this.Text = "EQW";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddProfile;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.CheckBox checkBoxAlt;
        private System.Windows.Forms.CheckBox checkBoxCtrl;
        private System.Windows.Forms.CheckBox checkBoxShift;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSetHotKey;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxProcName;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

