namespace Hash_Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.txt_File = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Hash = new System.Windows.Forms.TextBox();
            this.btn_Calculate1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Mode = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.txt_Hash);
            this.grpBox.Controls.Add(this.btn_Calculate1);
            this.grpBox.Controls.Add(this.label2);
            this.grpBox.Controls.Add(this.cmb_Mode);
            this.grpBox.Controls.Add(this.btn_Browse);
            this.grpBox.Controls.Add(this.txt_File);
            this.grpBox.Controls.Add(this.label1);
            this.grpBox.Location = new System.Drawing.Point(12, 12);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(920, 227);
            this.grpBox.TabIndex = 0;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Hash";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(839, 30);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 5;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // txt_File
            // 
            this.txt_File.Location = new System.Drawing.Point(44, 32);
            this.txt_File.Name = "txt_File";
            this.txt_File.Size = new System.Drawing.Size(789, 20);
            this.txt_File.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File";
            // 
            // txt_Hash
            // 
            this.txt_Hash.Location = new System.Drawing.Point(18, 140);
            this.txt_Hash.Name = "txt_Hash";
            this.txt_Hash.ReadOnly = true;
            this.txt_Hash.Size = new System.Drawing.Size(896, 20);
            this.txt_Hash.TabIndex = 11;
            this.txt_Hash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Calculate1
            // 
            this.btn_Calculate1.Location = new System.Drawing.Point(379, 177);
            this.btn_Calculate1.Name = "btn_Calculate1";
            this.btn_Calculate1.Size = new System.Drawing.Size(150, 23);
            this.btn_Calculate1.TabIndex = 10;
            this.btn_Calculate1.Text = "Calculate Hash";
            this.btn_Calculate1.UseVisualStyleBackColor = true;
            this.btn_Calculate1.Click += new System.EventHandler(this.btn_Calculate1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hash";
            // 
            // cmb_Mode
            // 
            this.cmb_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Mode.FormattingEnabled = true;
            this.cmb_Mode.Items.AddRange(new object[] {
            "MD5",
            "RIPEMD160",
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.cmb_Mode.Location = new System.Drawing.Point(44, 78);
            this.cmb_Mode.Name = "cmb_Mode";
            this.cmb_Mode.Size = new System.Drawing.Size(88, 21);
            this.cmb_Mode.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 251);
            this.Controls.Add(this.grpBox);
            this.Name = "Form1";
            this.Text = "Hash Calculator";
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.TextBox txt_Hash;
        private System.Windows.Forms.Button btn_Calculate1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Mode;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox txt_File;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;


    }
}

