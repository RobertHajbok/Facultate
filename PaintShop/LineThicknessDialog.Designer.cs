namespace PaintShop
{
    partial class LineThicknessDialog
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
            this.numThickness = new System.Windows.Forms.NumericUpDown();
            this.trkThickness = new System.Windows.Forms.TrackBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // numThickness
            // 
            this.numThickness.Location = new System.Drawing.Point(143, 12);
            this.numThickness.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThickness.Name = "numThickness";
            this.numThickness.Size = new System.Drawing.Size(41, 20);
            this.numThickness.TabIndex = 0;
            this.numThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThickness.ValueChanged += new System.EventHandler(this.numThickness_ValueChanged);
            // 
            // trkThickness
            // 
            this.trkThickness.Location = new System.Drawing.Point(59, 38);
            this.trkThickness.Maximum = 12;
            this.trkThickness.Minimum = 1;
            this.trkThickness.Name = "trkThickness";
            this.trkThickness.Size = new System.Drawing.Size(159, 45);
            this.trkThickness.TabIndex = 1;
            this.trkThickness.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkThickness.Value = 1;
            this.trkThickness.Scroll += new System.EventHandler(this.trkThickness_Scroll);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(143, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(62, 89);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thickness :";
            // 
            // LineThicknessDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(282, 124);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.trkThickness);
            this.Controls.Add(this.numThickness);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LineThicknessDialog";
            this.Text = "Choose line thickness";
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numThickness;
        private System.Windows.Forms.TrackBar trkThickness;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
    }
}