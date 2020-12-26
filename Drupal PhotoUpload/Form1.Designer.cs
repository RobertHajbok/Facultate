namespace Drupal_PhotoUpload
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
            this.pnl_Login = new System.Windows.Forms.Panel();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.txt_ServiceEndpoint = new System.Windows.Forms.TextBox();
            this.lbl_ServiceEndpoint = new System.Windows.Forms.Label();
            this.txt_DrupalBaseURL = new System.Windows.Forms.TextBox();
            this.lbl_DrupalBaseURL = new System.Windows.Forms.Label();
            this.pnl_Operations = new System.Windows.Forms.Panel();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Operations = new System.Windows.Forms.TextBox();
            this.txt_DrupalNodeNr = new System.Windows.Forms.TextBox();
            this.lbl_DrupalNodeNr = new System.Windows.Forms.Label();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.lbl_FilePath = new System.Windows.Forms.Label();
            this.btn_GetNode = new System.Windows.Forms.Button();
            this.btn_ChooseJPEG = new System.Windows.Forms.Button();
            this.btn_UploadImage = new System.Windows.Forms.Button();
            this.pnl_Login.SuspendLayout();
            this.pnl_Operations.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Login
            // 
            this.pnl_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Login.Controls.Add(this.btn_Login);
            this.pnl_Login.Controls.Add(this.txt_Password);
            this.pnl_Login.Controls.Add(this.lbl_Password);
            this.pnl_Login.Controls.Add(this.txt_Username);
            this.pnl_Login.Controls.Add(this.lbl_Username);
            this.pnl_Login.Controls.Add(this.txt_ServiceEndpoint);
            this.pnl_Login.Controls.Add(this.lbl_ServiceEndpoint);
            this.pnl_Login.Controls.Add(this.txt_DrupalBaseURL);
            this.pnl_Login.Controls.Add(this.lbl_DrupalBaseURL);
            this.pnl_Login.Location = new System.Drawing.Point(12, 12);
            this.pnl_Login.Name = "pnl_Login";
            this.pnl_Login.Size = new System.Drawing.Size(417, 246);
            this.pnl_Login.TabIndex = 0;
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(149, 108);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(253, 22);
            this.txt_Username.TabIndex = 5;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(42, 111);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(81, 17);
            this.lbl_Username.TabIndex = 4;
            this.lbl_Username.Text = "Username :";
            // 
            // txt_ServiceEndpoint
            // 
            this.txt_ServiceEndpoint.Location = new System.Drawing.Point(149, 62);
            this.txt_ServiceEndpoint.Name = "txt_ServiceEndpoint";
            this.txt_ServiceEndpoint.Size = new System.Drawing.Size(253, 22);
            this.txt_ServiceEndpoint.TabIndex = 3;
            // 
            // lbl_ServiceEndpoint
            // 
            this.lbl_ServiceEndpoint.AutoSize = true;
            this.lbl_ServiceEndpoint.Location = new System.Drawing.Point(20, 65);
            this.lbl_ServiceEndpoint.Name = "lbl_ServiceEndpoint";
            this.lbl_ServiceEndpoint.Size = new System.Drawing.Size(123, 17);
            this.lbl_ServiceEndpoint.TabIndex = 2;
            this.lbl_ServiceEndpoint.Text = "Service Endpoint :";
            // 
            // txt_DrupalBaseURL
            // 
            this.txt_DrupalBaseURL.Location = new System.Drawing.Point(149, 14);
            this.txt_DrupalBaseURL.Name = "txt_DrupalBaseURL";
            this.txt_DrupalBaseURL.Size = new System.Drawing.Size(253, 22);
            this.txt_DrupalBaseURL.TabIndex = 1;
            // 
            // lbl_DrupalBaseURL
            // 
            this.lbl_DrupalBaseURL.AutoSize = true;
            this.lbl_DrupalBaseURL.Location = new System.Drawing.Point(17, 17);
            this.lbl_DrupalBaseURL.Name = "lbl_DrupalBaseURL";
            this.lbl_DrupalBaseURL.Size = new System.Drawing.Size(126, 17);
            this.lbl_DrupalBaseURL.TabIndex = 0;
            this.lbl_DrupalBaseURL.Text = "Drupal Base URL :";
            // 
            // pnl_Operations
            // 
            this.pnl_Operations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Operations.Controls.Add(this.btn_UploadImage);
            this.pnl_Operations.Controls.Add(this.btn_ChooseJPEG);
            this.pnl_Operations.Controls.Add(this.btn_GetNode);
            this.pnl_Operations.Controls.Add(this.txt_FilePath);
            this.pnl_Operations.Controls.Add(this.lbl_FilePath);
            this.pnl_Operations.Controls.Add(this.txt_DrupalNodeNr);
            this.pnl_Operations.Controls.Add(this.lbl_DrupalNodeNr);
            this.pnl_Operations.Location = new System.Drawing.Point(12, 264);
            this.pnl_Operations.Name = "pnl_Operations";
            this.pnl_Operations.Size = new System.Drawing.Size(417, 180);
            this.pnl_Operations.TabIndex = 1;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(149, 149);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(253, 22);
            this.txt_Password.TabIndex = 7;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(46, 152);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(77, 17);
            this.lbl_Password.TabIndex = 6;
            this.lbl_Password.Text = "Password :";
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(177, 197);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(104, 29);
            this.btn_Login.TabIndex = 8;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Operations
            // 
            this.txt_Operations.Location = new System.Drawing.Point(436, 12);
            this.txt_Operations.Multiline = true;
            this.txt_Operations.Name = "txt_Operations";
            this.txt_Operations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Operations.Size = new System.Drawing.Size(473, 432);
            this.txt_Operations.TabIndex = 2;
            // 
            // txt_DrupalNodeNr
            // 
            this.txt_DrupalNodeNr.Location = new System.Drawing.Point(149, 28);
            this.txt_DrupalNodeNr.Name = "txt_DrupalNodeNr";
            this.txt_DrupalNodeNr.Size = new System.Drawing.Size(253, 22);
            this.txt_DrupalNodeNr.TabIndex = 9;
            // 
            // lbl_DrupalNodeNr
            // 
            this.lbl_DrupalNodeNr.AutoSize = true;
            this.lbl_DrupalNodeNr.Location = new System.Drawing.Point(46, 31);
            this.lbl_DrupalNodeNr.Name = "lbl_DrupalNodeNr";
            this.lbl_DrupalNodeNr.Size = new System.Drawing.Size(67, 17);
            this.lbl_DrupalNodeNr.TabIndex = 8;
            this.lbl_DrupalNodeNr.Text = "Node nr :";
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Location = new System.Drawing.Point(149, 74);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.Size = new System.Drawing.Size(253, 22);
            this.txt_FilePath.TabIndex = 11;
            // 
            // lbl_FilePath
            // 
            this.lbl_FilePath.AutoSize = true;
            this.lbl_FilePath.Location = new System.Drawing.Point(46, 77);
            this.lbl_FilePath.Name = "lbl_FilePath";
            this.lbl_FilePath.Size = new System.Drawing.Size(70, 17);
            this.lbl_FilePath.TabIndex = 10;
            this.lbl_FilePath.Text = "File path :";
            // 
            // btn_GetNode
            // 
            this.btn_GetNode.Location = new System.Drawing.Point(23, 130);
            this.btn_GetNode.Name = "btn_GetNode";
            this.btn_GetNode.Size = new System.Drawing.Size(104, 29);
            this.btn_GetNode.TabIndex = 9;
            this.btn_GetNode.Text = "Get Node";
            this.btn_GetNode.UseVisualStyleBackColor = true;
            this.btn_GetNode.Click += new System.EventHandler(this.btn_GetNode_Click);
            // 
            // btn_ChooseJPEG
            // 
            this.btn_ChooseJPEG.Location = new System.Drawing.Point(161, 130);
            this.btn_ChooseJPEG.Name = "btn_ChooseJPEG";
            this.btn_ChooseJPEG.Size = new System.Drawing.Size(110, 29);
            this.btn_ChooseJPEG.TabIndex = 12;
            this.btn_ChooseJPEG.Text = "Choose JPEG";
            this.btn_ChooseJPEG.UseVisualStyleBackColor = true;
            this.btn_ChooseJPEG.Click += new System.EventHandler(this.btn_ChooseJPEG_Click);
            // 
            // btn_UploadImage
            // 
            this.btn_UploadImage.Location = new System.Drawing.Point(298, 130);
            this.btn_UploadImage.Name = "btn_UploadImage";
            this.btn_UploadImage.Size = new System.Drawing.Size(104, 29);
            this.btn_UploadImage.TabIndex = 13;
            this.btn_UploadImage.Text = "Upload Image";
            this.btn_UploadImage.UseVisualStyleBackColor = true;
            this.btn_UploadImage.Click += new System.EventHandler(this.btn_UploadImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 456);
            this.Controls.Add(this.txt_Operations);
            this.Controls.Add(this.pnl_Operations);
            this.Controls.Add(this.pnl_Login);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(939, 503);
            this.MinimumSize = new System.Drawing.Size(939, 503);
            this.Name = "Form1";
            this.Text = "Drupal PhotoUpload";
            this.pnl_Login.ResumeLayout(false);
            this.pnl_Login.PerformLayout();
            this.pnl_Operations.ResumeLayout(false);
            this.pnl_Operations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Login;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TextBox txt_ServiceEndpoint;
        private System.Windows.Forms.Label lbl_ServiceEndpoint;
        private System.Windows.Forms.TextBox txt_DrupalBaseURL;
        private System.Windows.Forms.Label lbl_DrupalBaseURL;
        private System.Windows.Forms.Panel pnl_Operations;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_UploadImage;
        private System.Windows.Forms.Button btn_ChooseJPEG;
        private System.Windows.Forms.Button btn_GetNode;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Label lbl_FilePath;
        private System.Windows.Forms.TextBox txt_DrupalNodeNr;
        private System.Windows.Forms.Label lbl_DrupalNodeNr;
        private System.Windows.Forms.TextBox txt_Operations;
    }
}

