namespace Cifrul_lui_Caesar
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
            this.tboxIO = new System.Windows.Forms.TextBox();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIO = new System.Windows.Forms.Label();
            this.tbShift = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tboxIO
            // 
            this.tboxIO.Location = new System.Drawing.Point(12, 25);
            this.tboxIO.Multiline = true;
            this.tboxIO.Name = "tboxIO";
            this.tboxIO.Size = new System.Drawing.Size(281, 256);
            this.tboxIO.TabIndex = 0;
            this.tboxIO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tboxIO_MouseClick);
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(299, 47);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(86, 23);
            this.Encrypt.TabIndex = 1;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(299, 76);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(86, 23);
            this.Decrypt.TabIndex = 2;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Shifts";
            // 
            // lblIO
            // 
            this.lblIO.AutoSize = true;
            this.lblIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIO.Location = new System.Drawing.Point(12, 9);
            this.lblIO.Name = "lblIO";
            this.lblIO.Size = new System.Drawing.Size(36, 13);
            this.lblIO.TabIndex = 4;
            this.lblIO.Text = "Input";
            // 
            // tbShift
            // 
            this.tbShift.Location = new System.Drawing.Point(338, 156);
            this.tbShift.Name = "tbShift";
            this.tbShift.Size = new System.Drawing.Size(46, 20);
            this.tbShift.TabIndex = 5;
            this.tbShift.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbShift_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 293);
            this.Controls.Add(this.tbShift);
            this.Controls.Add(this.lblIO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.tboxIO);
            this.Name = "Form1";
            this.Text = "Cifrul lui Caesar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxIO;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIO;
        private System.Windows.Forms.TextBox tbShift;
    }
}

