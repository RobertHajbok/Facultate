namespace Tema1
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
            this.button1 = new System.Windows.Forms.Button();
            this.numar1 = new System.Windows.Forms.TextBox();
            this.numar2 = new System.Windows.Forms.TextBox();
            this.numar3 = new System.Windows.Forms.TextBox();
            this.numar4 = new System.Windows.Forms.TextBox();
            this.numar5 = new System.Windows.Forms.TextBox();
            this.numar6 = new System.Windows.Forms.TextBox();
            this.rezultat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(367, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Genereaza si sorteaza";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numar1
            // 
            this.numar1.Font = new System.Drawing.Font("Lucida Console", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numar1.Location = new System.Drawing.Point(12, 12);
            this.numar1.Name = "numar1";
            this.numar1.ReadOnly = true;
            this.numar1.Size = new System.Drawing.Size(56, 61);
            this.numar1.TabIndex = 1;
            this.numar1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numar2
            // 
            this.numar2.Font = new System.Drawing.Font("Lucida Console", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numar2.Location = new System.Drawing.Point(74, 12);
            this.numar2.Name = "numar2";
            this.numar2.ReadOnly = true;
            this.numar2.Size = new System.Drawing.Size(56, 61);
            this.numar2.TabIndex = 2;
            this.numar2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numar3
            // 
            this.numar3.Font = new System.Drawing.Font("Lucida Console", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numar3.Location = new System.Drawing.Point(136, 12);
            this.numar3.Name = "numar3";
            this.numar3.ReadOnly = true;
            this.numar3.Size = new System.Drawing.Size(56, 61);
            this.numar3.TabIndex = 3;
            this.numar3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numar4
            // 
            this.numar4.Font = new System.Drawing.Font("Lucida Console", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numar4.Location = new System.Drawing.Point(198, 12);
            this.numar4.Name = "numar4";
            this.numar4.ReadOnly = true;
            this.numar4.Size = new System.Drawing.Size(56, 61);
            this.numar4.TabIndex = 4;
            this.numar4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numar4.TextChanged += new System.EventHandler(this.numar4_TextChanged);
            // 
            // numar5
            // 
            this.numar5.Font = new System.Drawing.Font("Lucida Console", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numar5.Location = new System.Drawing.Point(260, 12);
            this.numar5.Name = "numar5";
            this.numar5.ReadOnly = true;
            this.numar5.Size = new System.Drawing.Size(56, 61);
            this.numar5.TabIndex = 5;
            this.numar5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numar6
            // 
            this.numar6.Font = new System.Drawing.Font("Lucida Console", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numar6.Location = new System.Drawing.Point(322, 12);
            this.numar6.Name = "numar6";
            this.numar6.ReadOnly = true;
            this.numar6.Size = new System.Drawing.Size(56, 61);
            this.numar6.TabIndex = 6;
            this.numar6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rezultat
            // 
            this.rezultat.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rezultat.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.rezultat.Location = new System.Drawing.Point(12, 76);
            this.rezultat.Name = "rezultat";
            this.rezultat.Size = new System.Drawing.Size(366, 23);
            this.rezultat.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 141);
            this.Controls.Add(this.rezultat);
            this.Controls.Add(this.numar6);
            this.Controls.Add(this.numar5);
            this.Controls.Add(this.numar4);
            this.Controls.Add(this.numar3);
            this.Controls.Add(this.numar2);
            this.Controls.Add(this.numar1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tema 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox numar1;
        private System.Windows.Forms.TextBox numar2;
        private System.Windows.Forms.TextBox numar3;
        private System.Windows.Forms.TextBox numar4;
        private System.Windows.Forms.TextBox numar5;
        private System.Windows.Forms.TextBox numar6;
        private System.Windows.Forms.Label rezultat;
    }
}

