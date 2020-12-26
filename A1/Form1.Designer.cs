namespace A1
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
            this.lbl_Indication = new System.Windows.Forms.Label();
            this.btn_Verify = new System.Windows.Forms.Button();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.tb_LinesNr = new System.Windows.Forms.TextBox();
            this.lbl_LinesNr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Indication
            // 
            this.lbl_Indication.AutoSize = true;
            this.lbl_Indication.Location = new System.Drawing.Point(12, 9);
            this.lbl_Indication.Name = "lbl_Indication";
            this.lbl_Indication.Size = new System.Drawing.Size(440, 17);
            this.lbl_Indication.TabIndex = 0;
            this.lbl_Indication.Text = "Verificați dacă inversa unei matrici triunghiulare este tot triunghiulară";
            // 
            // btn_Verify
            // 
            this.btn_Verify.Location = new System.Drawing.Point(337, 35);
            this.btn_Verify.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Verify.Name = "btn_Verify";
            this.btn_Verify.Size = new System.Drawing.Size(100, 28);
            this.btn_Verify.TabIndex = 5;
            this.btn_Verify.Text = "Verifica";
            this.btn_Verify.UseVisualStyleBackColor = true;
            this.btn_Verify.Visible = false;
            this.btn_Verify.Click += new System.EventHandler(this.btn_Verify_Click);
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(176, 35);
            this.btn_Generate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(153, 28);
            this.btn_Generate.TabIndex = 4;
            this.btn_Generate.Text = "Genereaza matricea";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // tb_LinesNr
            // 
            this.tb_LinesNr.Location = new System.Drawing.Point(118, 38);
            this.tb_LinesNr.Margin = new System.Windows.Forms.Padding(4);
            this.tb_LinesNr.Name = "tb_LinesNr";
            this.tb_LinesNr.Size = new System.Drawing.Size(50, 22);
            this.tb_LinesNr.TabIndex = 3;
            this.tb_LinesNr.Text = "3";
            // 
            // lbl_LinesNr
            // 
            this.lbl_LinesNr.AutoSize = true;
            this.lbl_LinesNr.Location = new System.Drawing.Point(12, 41);
            this.lbl_LinesNr.Name = "lbl_LinesNr";
            this.lbl_LinesNr.Size = new System.Drawing.Size(99, 17);
            this.lbl_LinesNr.TabIndex = 6;
            this.lbl_LinesNr.Text = "Linii / coloane:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 774);
            this.Controls.Add(this.lbl_LinesNr);
            this.Controls.Add(this.btn_Verify);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.tb_LinesNr);
            this.Controls.Add(this.lbl_Indication);
            this.Name = "Form1";
            this.Text = "A1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Indication;
        private System.Windows.Forms.Button btn_Verify;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.TextBox tb_LinesNr;
        private System.Windows.Forms.Label lbl_LinesNr;
    }
}

