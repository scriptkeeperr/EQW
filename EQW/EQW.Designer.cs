
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSetHotKey = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAddProfile
            // 
            this.labelAddProfile.AutoSize = true;
            this.labelAddProfile.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAddProfile.Location = new System.Drawing.Point(12, 225);
            this.labelAddProfile.Name = "labelAddProfile";
            this.labelAddProfile.Size = new System.Drawing.Size(103, 21);
            this.labelAddProfile.TabIndex = 0;
            this.labelAddProfile.Text = "Add Profile";
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.Location = new System.Drawing.Point(121, 224);
            this.textBoxProfileName.MaxLength = 100;
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.PlaceholderText = "name";
            this.textBoxProfileName.Size = new System.Drawing.Size(165, 23);
            this.textBoxProfileName.TabIndex = 1;
            // 
            // checkBoxAlt
            // 
            this.checkBoxAlt.AutoSize = true;
            this.checkBoxAlt.Location = new System.Drawing.Point(384, 227);
            this.checkBoxAlt.Name = "checkBoxAlt";
            this.checkBoxAlt.Size = new System.Drawing.Size(41, 19);
            this.checkBoxAlt.TabIndex = 3;
            this.checkBoxAlt.Text = "Alt";
            this.checkBoxAlt.UseVisualStyleBackColor = true;
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.AutoSize = true;
            this.checkBoxCtrl.Location = new System.Drawing.Point(431, 227);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(45, 19);
            this.checkBoxCtrl.TabIndex = 4;
            this.checkBoxCtrl.Text = "Ctrl";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            // 
            // checkBoxShift
            // 
            this.checkBoxShift.AutoSize = true;
            this.checkBoxShift.Location = new System.Drawing.Point(482, 227);
            this.checkBoxShift.Name = "checkBoxShift";
            this.checkBoxShift.Size = new System.Drawing.Size(50, 19);
            this.checkBoxShift.TabIndex = 5;
            this.checkBoxShift.Text = "Shift";
            this.checkBoxShift.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 257);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(707, 181);
            this.dataGridView1.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(644, 223);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 28);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonSetHotKey
            // 
            this.buttonSetHotKey.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSetHotKey.Location = new System.Drawing.Point(292, 223);
            this.buttonSetHotKey.Name = "buttonSetHotKey";
            this.buttonSetHotKey.Size = new System.Drawing.Size(86, 28);
            this.buttonSetHotKey.TabIndex = 2;
            this.buttonSetHotKey.Text = "Set Hot Key";
            this.buttonSetHotKey.UseVisualStyleBackColor = true;
            this.buttonSetHotKey.Click += new System.EventHandler(this.ButtonSetHotKey_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(538, 225);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.PlaceholderText = "key";
            this.textBoxKey.Size = new System.Drawing.Size(100, 23);
            this.textBoxKey.TabIndex = 9;
            this.textBoxKey.Enter += new System.EventHandler(this.ButtonSetHotKey_Click);
            this.textBoxKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKey_KeyDown);
            this.textBoxKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxKey_KeyUp);
            this.textBoxKey.Leave += new System.EventHandler(this.TextBoxKey_Leave);
            // 
            // EQW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBoxShift);
            this.Controls.Add(this.checkBoxCtrl);
            this.Controls.Add(this.checkBoxAlt);
            this.Controls.Add(this.buttonSetHotKey);
            this.Controls.Add(this.textBoxProfileName);
            this.Controls.Add(this.labelAddProfile);
            this.Name = "EQW";
            this.Text = "EQW";
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSetHotKey;
        private System.Windows.Forms.TextBox textBoxKey;
    }
}

