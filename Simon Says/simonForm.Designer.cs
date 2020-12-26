namespace Simon_Says
{
    partial class simonForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.turnOffTimer = new System.Windows.Forms.Timer(this.components);
            this.simonButton4 = new Simon_Says.simonButton();
            this.simonButton3 = new Simon_Says.simonButton();
            this.simonButton2 = new Simon_Says.simonButton();
            this.simonButton1 = new Simon_Says.simonButton();            
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // turnOffTimer
            // 
            this.turnOffTimer.Interval = 300;
            this.turnOffTimer.Tick += new System.EventHandler(this.turnOffTimer_Tick);
            // 
            // simonButton4
            // 
            this.simonButton4.Clicked = false;
            this.simonButton4.ForeColor = System.Drawing.Color.DarkGreen;
            this.simonButton4.Location = new System.Drawing.Point(168, 168);
            this.simonButton4.Name = "simonButton4";
            this.simonButton4.Rotation = 180;
            this.simonButton4.Size = new System.Drawing.Size(150, 150);
            this.simonButton4.TabIndex = 3;
            this.simonButton4.Text = "simonButton4";
            this.simonButton4.UseVisualStyleBackColor = true;
            this.simonButton4.Click += new System.EventHandler(this.simonButton_Click);
            // 
            // simonButton3
            // 
            this.simonButton3.Clicked = false;
            this.simonButton3.ForeColor = System.Drawing.Color.Goldenrod;
            this.simonButton3.Location = new System.Drawing.Point(12, 168);
            this.simonButton3.Name = "simonButton3";
            this.simonButton3.Rotation = 270;
            this.simonButton3.Size = new System.Drawing.Size(150, 150);
            this.simonButton3.TabIndex = 2;
            this.simonButton3.Text = "simonButton3";
            this.simonButton3.UseVisualStyleBackColor = true;
            this.simonButton3.Click += new System.EventHandler(this.simonButton_Click);
            // 
            // simonButton2
            // 
            this.simonButton2.Clicked = false;
            this.simonButton2.ForeColor = System.Drawing.Color.DarkRed;
            this.simonButton2.Location = new System.Drawing.Point(168, 12);
            this.simonButton2.Name = "simonButton2";
            this.simonButton2.Rotation = 90;
            this.simonButton2.Size = new System.Drawing.Size(150, 150);
            this.simonButton2.TabIndex = 1;
            this.simonButton2.Text = "simonButton2";
            this.simonButton2.UseVisualStyleBackColor = true;
            this.simonButton2.Click += new System.EventHandler(this.simonButton_Click);
            // 
            // simonButton1
            // 
            this.simonButton1.Clicked = false;
            this.simonButton1.ForeColor = System.Drawing.Color.DarkBlue;
            this.simonButton1.Location = new System.Drawing.Point(12, 12);
            this.simonButton1.Name = "simonButton1";
            this.simonButton1.Rotation = 0;
            this.simonButton1.Size = new System.Drawing.Size(150, 150);
            this.simonButton1.TabIndex = 0;
            this.simonButton1.Text = "simonButton1";
            this.simonButton1.UseVisualStyleBackColor = true;
            this.simonButton1.Click += new System.EventHandler(this.simonButton_Click);
            // 
            // simonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(332, 332);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.simonButton4);
            this.Controls.Add(this.simonButton3);
            this.Controls.Add(this.simonButton2);
            this.Controls.Add(this.simonButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "simonForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private simonButton simonButton1;
        private simonButton simonButton2;
        private simonButton simonButton3;
        private simonButton simonButton4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer turnOffTimer;


    }
}

