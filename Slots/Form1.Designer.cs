namespace Slots
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
            this.textboxLines = new System.Windows.Forms.TextBox();
            this.textboxBet = new System.Windows.Forms.TextBox();
            this.buttonBetMax = new System.Windows.Forms.Button();
            this.buttonSetBet = new System.Windows.Forms.Button();
            this.buttonSpin = new System.Windows.Forms.Button();
            this.buttonSetLines = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCredit = new System.Windows.Forms.Label();
            this.labelTotalBet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textboxLines
            // 
            this.textboxLines.Location = new System.Drawing.Point(72, 200);
            this.textboxLines.Name = "textboxLines";
            this.textboxLines.Size = new System.Drawing.Size(59, 20);
            this.textboxLines.TabIndex = 1;
            // 
            // textboxBet
            // 
            this.textboxBet.Location = new System.Drawing.Point(12, 200);
            this.textboxBet.Name = "textboxBet";
            this.textboxBet.Size = new System.Drawing.Size(54, 20);
            this.textboxBet.TabIndex = 0;
            // 
            // buttonBetMax
            // 
            this.buttonBetMax.Location = new System.Drawing.Point(137, 213);
            this.buttonBetMax.Name = "buttonBetMax";
            this.buttonBetMax.Size = new System.Drawing.Size(54, 23);
            this.buttonBetMax.TabIndex = 2;
            this.buttonBetMax.Text = "Bet Max";
            this.buttonBetMax.UseVisualStyleBackColor = true;
            this.buttonBetMax.Click += new System.EventHandler(this.buttonBetMax_Click);
            // 
            // buttonSetBet
            // 
            this.buttonSetBet.Location = new System.Drawing.Point(12, 226);
            this.buttonSetBet.Name = "buttonSetBet";
            this.buttonSetBet.Size = new System.Drawing.Size(54, 23);
            this.buttonSetBet.TabIndex = 3;
            this.buttonSetBet.Text = "Set bet";
            this.buttonSetBet.UseVisualStyleBackColor = true;
            this.buttonSetBet.Click += new System.EventHandler(this.buttonSetBet_Click);
            // 
            // buttonSpin
            // 
            this.buttonSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSpin.Location = new System.Drawing.Point(197, 200);
            this.buttonSpin.Name = "buttonSpin";
            this.buttonSpin.Size = new System.Drawing.Size(75, 49);
            this.buttonSpin.TabIndex = 4;
            this.buttonSpin.Text = "Spin";
            this.buttonSpin.UseVisualStyleBackColor = true;
            this.buttonSpin.Click += new System.EventHandler(this.buttonSpin_Click);
            // 
            // buttonSetLines
            // 
            this.buttonSetLines.Location = new System.Drawing.Point(72, 226);
            this.buttonSetLines.Name = "buttonSetLines";
            this.buttonSetLines.Size = new System.Drawing.Size(59, 23);
            this.buttonSetLines.TabIndex = 5;
            this.buttonSetLines.Text = "Set lines";
            this.buttonSetLines.UseVisualStyleBackColor = true;
            this.buttonSetLines.Click += new System.EventHandler(this.buttonSetLines_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Credit :";
            // 
            // labelCredit
            // 
            this.labelCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCredit.Location = new System.Drawing.Point(58, 7);
            this.labelCredit.Name = "labelCredit";
            this.labelCredit.Size = new System.Drawing.Size(50, 16);
            this.labelCredit.TabIndex = 8;
            this.labelCredit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalBet
            // 
            this.labelTotalBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalBet.Location = new System.Drawing.Point(223, 7);
            this.labelTotalBet.Name = "labelTotalBet";
            this.labelTotalBet.Size = new System.Drawing.Size(49, 16);
            this.labelTotalBet.TabIndex = 10;
            this.labelTotalBet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total bet :";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 158);
            this.panel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTotalBet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCredit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSetLines);
            this.Controls.Add(this.buttonSpin);
            this.Controls.Add(this.buttonSetBet);
            this.Controls.Add(this.buttonBetMax);
            this.Controls.Add(this.textboxBet);
            this.Controls.Add(this.textboxLines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Slots";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxLines;
        private System.Windows.Forms.TextBox textboxBet;
        private System.Windows.Forms.Button buttonBetMax;
        private System.Windows.Forms.Button buttonSetBet;
        private System.Windows.Forms.Button buttonSpin;
        private System.Windows.Forms.Button buttonSetLines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCredit;
        private System.Windows.Forms.Label labelTotalBet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}

