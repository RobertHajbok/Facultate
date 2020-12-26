namespace DiceGame
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
            this.lbl_p1Dice1 = new System.Windows.Forms.Label();
            this.lbl_p1Dice2 = new System.Windows.Forms.Label();
            this.lbl_p1Dice3 = new System.Windows.Forms.Label();
            this.lbl_p1Dice4 = new System.Windows.Forms.Label();
            this.lbl_p1Dice5 = new System.Windows.Forms.Label();
            this.btn_p1RollDice = new System.Windows.Forms.Button();
            this.lbl_p1DisplayResults = new System.Windows.Forms.Label();
            this.lbl_p2DisplayResults = new System.Windows.Forms.Label();
            this.btn_p2RollDice = new System.Windows.Forms.Button();
            this.lbl_p2Dice5 = new System.Windows.Forms.Label();
            this.lbl_p2Dice4 = new System.Windows.Forms.Label();
            this.lbl_p2Dice3 = new System.Windows.Forms.Label();
            this.lbl_p2Dice2 = new System.Windows.Forms.Label();
            this.lbl_p2Dice1 = new System.Windows.Forms.Label();
            this.lbl_winnerResult = new System.Windows.Forms.Label();
            this.lbl_p1Name = new System.Windows.Forms.Label();
            this.lbl_p2Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_p1Dice1
            // 
            this.lbl_p1Dice1.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p1Dice1.Location = new System.Drawing.Point(19, 128);
            this.lbl_p1Dice1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p1Dice1.Name = "lbl_p1Dice1";
            this.lbl_p1Dice1.Size = new System.Drawing.Size(38, 41);
            this.lbl_p1Dice1.TabIndex = 0;
            // 
            // lbl_p1Dice2
            // 
            this.lbl_p1Dice2.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p1Dice2.Location = new System.Drawing.Point(61, 128);
            this.lbl_p1Dice2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p1Dice2.Name = "lbl_p1Dice2";
            this.lbl_p1Dice2.Size = new System.Drawing.Size(38, 41);
            this.lbl_p1Dice2.TabIndex = 1;
            // 
            // lbl_p1Dice3
            // 
            this.lbl_p1Dice3.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p1Dice3.Location = new System.Drawing.Point(103, 128);
            this.lbl_p1Dice3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p1Dice3.Name = "lbl_p1Dice3";
            this.lbl_p1Dice3.Size = new System.Drawing.Size(38, 41);
            this.lbl_p1Dice3.TabIndex = 2;
            // 
            // lbl_p1Dice4
            // 
            this.lbl_p1Dice4.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p1Dice4.Location = new System.Drawing.Point(145, 128);
            this.lbl_p1Dice4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p1Dice4.Name = "lbl_p1Dice4";
            this.lbl_p1Dice4.Size = new System.Drawing.Size(38, 41);
            this.lbl_p1Dice4.TabIndex = 3;
            // 
            // lbl_p1Dice5
            // 
            this.lbl_p1Dice5.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p1Dice5.Location = new System.Drawing.Point(187, 128);
            this.lbl_p1Dice5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p1Dice5.Name = "lbl_p1Dice5";
            this.lbl_p1Dice5.Size = new System.Drawing.Size(38, 41);
            this.lbl_p1Dice5.TabIndex = 4;
            // 
            // btn_p1RollDice
            // 
            this.btn_p1RollDice.Location = new System.Drawing.Point(44, 188);
            this.btn_p1RollDice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_p1RollDice.Name = "btn_p1RollDice";
            this.btn_p1RollDice.Size = new System.Drawing.Size(150, 41);
            this.btn_p1RollDice.TabIndex = 5;
            this.btn_p1RollDice.Text = "Roll Dice";
            this.btn_p1RollDice.UseVisualStyleBackColor = true;
            this.btn_p1RollDice.Click += new System.EventHandler(this.btn_p1RollDice_Click);
            // 
            // lbl_p1DisplayResults
            // 
            this.lbl_p1DisplayResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_p1DisplayResults.Location = new System.Drawing.Point(0, 254);
            this.lbl_p1DisplayResults.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p1DisplayResults.Name = "lbl_p1DisplayResults";
            this.lbl_p1DisplayResults.Size = new System.Drawing.Size(238, 41);
            this.lbl_p1DisplayResults.TabIndex = 6;
            this.lbl_p1DisplayResults.Text = "Roll The Dice";
            this.lbl_p1DisplayResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_p2DisplayResults
            // 
            this.lbl_p2DisplayResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_p2DisplayResults.Location = new System.Drawing.Point(348, 254);
            this.lbl_p2DisplayResults.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p2DisplayResults.Name = "lbl_p2DisplayResults";
            this.lbl_p2DisplayResults.Size = new System.Drawing.Size(238, 41);
            this.lbl_p2DisplayResults.TabIndex = 13;
            this.lbl_p2DisplayResults.Text = "Roll The Dice";
            this.lbl_p2DisplayResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_p2RollDice
            // 
            this.btn_p2RollDice.Location = new System.Drawing.Point(391, 188);
            this.btn_p2RollDice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_p2RollDice.Name = "btn_p2RollDice";
            this.btn_p2RollDice.Size = new System.Drawing.Size(150, 41);
            this.btn_p2RollDice.TabIndex = 12;
            this.btn_p2RollDice.Text = "Roll Dice";
            this.btn_p2RollDice.UseVisualStyleBackColor = true;
            this.btn_p2RollDice.Click += new System.EventHandler(this.btn_p2RollDice_Click);
            // 
            // lbl_p2Dice5
            // 
            this.lbl_p2Dice5.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p2Dice5.Location = new System.Drawing.Point(533, 128);
            this.lbl_p2Dice5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p2Dice5.Name = "lbl_p2Dice5";
            this.lbl_p2Dice5.Size = new System.Drawing.Size(38, 41);
            this.lbl_p2Dice5.TabIndex = 11;
            // 
            // lbl_p2Dice4
            // 
            this.lbl_p2Dice4.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p2Dice4.Location = new System.Drawing.Point(491, 128);
            this.lbl_p2Dice4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p2Dice4.Name = "lbl_p2Dice4";
            this.lbl_p2Dice4.Size = new System.Drawing.Size(38, 41);
            this.lbl_p2Dice4.TabIndex = 10;
            // 
            // lbl_p2Dice3
            // 
            this.lbl_p2Dice3.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p2Dice3.Location = new System.Drawing.Point(449, 128);
            this.lbl_p2Dice3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p2Dice3.Name = "lbl_p2Dice3";
            this.lbl_p2Dice3.Size = new System.Drawing.Size(38, 41);
            this.lbl_p2Dice3.TabIndex = 9;
            // 
            // lbl_p2Dice2
            // 
            this.lbl_p2Dice2.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p2Dice2.Location = new System.Drawing.Point(407, 128);
            this.lbl_p2Dice2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p2Dice2.Name = "lbl_p2Dice2";
            this.lbl_p2Dice2.Size = new System.Drawing.Size(38, 41);
            this.lbl_p2Dice2.TabIndex = 8;
            // 
            // lbl_p2Dice1
            // 
            this.lbl_p2Dice1.Image = global::DiceGame.Properties.Resources.dice_blank;
            this.lbl_p2Dice1.Location = new System.Drawing.Point(365, 128);
            this.lbl_p2Dice1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p2Dice1.Name = "lbl_p2Dice1";
            this.lbl_p2Dice1.Size = new System.Drawing.Size(38, 41);
            this.lbl_p2Dice1.TabIndex = 7;
            // 
            // lbl_winnerResult
            // 
            this.lbl_winnerResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_winnerResult.Location = new System.Drawing.Point(5, 19);
            this.lbl_winnerResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_winnerResult.Name = "lbl_winnerResult";
            this.lbl_winnerResult.Size = new System.Drawing.Size(581, 41);
            this.lbl_winnerResult.TabIndex = 14;
            this.lbl_winnerResult.Text = "Waiting for Roll!";
            this.lbl_winnerResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_p1Name
            // 
            this.lbl_p1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_p1Name.Location = new System.Drawing.Point(28, 87);
            this.lbl_p1Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p1Name.Name = "lbl_p1Name";
            this.lbl_p1Name.Size = new System.Drawing.Size(188, 41);
            this.lbl_p1Name.TabIndex = 15;
            // 
            // lbl_p2Name
            // 
            this.lbl_p2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_p2Name.Location = new System.Drawing.Point(374, 87);
            this.lbl_p2Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_p2Name.Name = "lbl_p2Name";
            this.lbl_p2Name.Size = new System.Drawing.Size(188, 41);
            this.lbl_p2Name.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 457);
            this.Controls.Add(this.lbl_p2Name);
            this.Controls.Add(this.lbl_p1Name);
            this.Controls.Add(this.lbl_winnerResult);
            this.Controls.Add(this.lbl_p2DisplayResults);
            this.Controls.Add(this.btn_p2RollDice);
            this.Controls.Add(this.lbl_p2Dice5);
            this.Controls.Add(this.lbl_p2Dice4);
            this.Controls.Add(this.lbl_p2Dice3);
            this.Controls.Add(this.lbl_p2Dice2);
            this.Controls.Add(this.lbl_p2Dice1);
            this.Controls.Add(this.lbl_p1DisplayResults);
            this.Controls.Add(this.btn_p1RollDice);
            this.Controls.Add(this.lbl_p1Dice5);
            this.Controls.Add(this.lbl_p1Dice4);
            this.Controls.Add(this.lbl_p1Dice3);
            this.Controls.Add(this.lbl_p1Dice2);
            this.Controls.Add(this.lbl_p1Dice1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(604, 495);
            this.MinimumSize = new System.Drawing.Size(604, 495);
            this.Name = "Form1";
            this.Text = "Dice Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_p1Dice1;
        private System.Windows.Forms.Label lbl_p1Dice2;
        private System.Windows.Forms.Label lbl_p1Dice3;
        private System.Windows.Forms.Label lbl_p1Dice4;
        private System.Windows.Forms.Label lbl_p1Dice5;
        private System.Windows.Forms.Button btn_p1RollDice;
        private System.Windows.Forms.Label lbl_p1DisplayResults;
        private System.Windows.Forms.Label lbl_p2DisplayResults;
        private System.Windows.Forms.Button btn_p2RollDice;
        private System.Windows.Forms.Label lbl_p2Dice5;
        private System.Windows.Forms.Label lbl_p2Dice4;
        private System.Windows.Forms.Label lbl_p2Dice3;
        private System.Windows.Forms.Label lbl_p2Dice2;
        private System.Windows.Forms.Label lbl_p2Dice1;
        private System.Windows.Forms.Label lbl_winnerResult;
        private System.Windows.Forms.Label lbl_p1Name;
        private System.Windows.Forms.Label lbl_p2Name;
    }
}

