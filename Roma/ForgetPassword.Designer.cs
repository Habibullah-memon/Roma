namespace Roma
{
    partial class ForgetPassword
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
            this.textBoxVerificationCode = new System.Windows.Forms.TextBox();
            this.textBoxEmailUserName = new System.Windows.Forms.TextBox();
            this.labeEmail = new System.Windows.Forms.Label();
            this.labelVerificationCode = new System.Windows.Forms.Label();
            this.buttonSendEmailSubmit = new System.Windows.Forms.Button();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxVerificationCode
            // 
            this.textBoxVerificationCode.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.textBoxVerificationCode.Location = new System.Drawing.Point(40, 216);
            this.textBoxVerificationCode.Name = "textBoxVerificationCode";
            this.textBoxVerificationCode.Size = new System.Drawing.Size(282, 34);
            this.textBoxVerificationCode.TabIndex = 78;
            this.textBoxVerificationCode.Visible = false;
            // 
            // textBoxEmailUserName
            // 
            this.textBoxEmailUserName.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.textBoxEmailUserName.Location = new System.Drawing.Point(40, 151);
            this.textBoxEmailUserName.Name = "textBoxEmailUserName";
            this.textBoxEmailUserName.Size = new System.Drawing.Size(282, 34);
            this.textBoxEmailUserName.TabIndex = 1;
            // 
            // labeEmail
            // 
            this.labeEmail.AutoSize = true;
            this.labeEmail.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labeEmail.Location = new System.Drawing.Point(40, 128);
            this.labeEmail.Name = "labeEmail";
            this.labeEmail.Size = new System.Drawing.Size(134, 22);
            this.labeEmail.TabIndex = 77;
            this.labeEmail.Text = "Email Address";
            // 
            // labelVerificationCode
            // 
            this.labelVerificationCode.AutoSize = true;
            this.labelVerificationCode.Enabled = false;
            this.labelVerificationCode.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labelVerificationCode.Location = new System.Drawing.Point(40, 193);
            this.labelVerificationCode.Name = "labelVerificationCode";
            this.labelVerificationCode.Size = new System.Drawing.Size(171, 22);
            this.labelVerificationCode.TabIndex = 76;
            this.labelVerificationCode.Text = "Verification Code";
            this.labelVerificationCode.Visible = false;
            // 
            // buttonSendEmailSubmit
            // 
            this.buttonSendEmailSubmit.AutoEllipsis = true;
            this.buttonSendEmailSubmit.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonSendEmailSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSendEmailSubmit.FlatAppearance.BorderSize = 2;
            this.buttonSendEmailSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendEmailSubmit.Font = new System.Drawing.Font("Comic Sans MS", 13.25F, System.Drawing.FontStyle.Bold);
            this.buttonSendEmailSubmit.Location = new System.Drawing.Point(110, 263);
            this.buttonSendEmailSubmit.Name = "buttonSendEmailSubmit";
            this.buttonSendEmailSubmit.Size = new System.Drawing.Size(138, 41);
            this.buttonSendEmailSubmit.TabIndex = 2;
            this.buttonSendEmailSubmit.Text = "Send Email";
            this.buttonSendEmailSubmit.UseVisualStyleBackColor = false;
            this.buttonSendEmailSubmit.Click += new System.EventHandler(this.ButtonSendEmailSubmit_Click);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labelUserName.Location = new System.Drawing.Point(40, 61);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(108, 22);
            this.labelUserName.TabIndex = 77;
            this.labelUserName.Text = "User Name";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.textBoxUserName.Location = new System.Drawing.Point(40, 84);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(282, 34);
            this.textBoxUserName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 40);
            this.label1.TabIndex = 82;
            this.label1.Text = "Note: Please Enter your Email Address\r\n         to Send Verification Code.";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.BackgroundImage = global::Roma.Properties.Resources.close;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Century Gothic", 0.1F);
            this.buttonExit.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonExit.Location = new System.Drawing.Point(321, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(43, 36);
            this.buttonExit.TabIndex = 97;
            this.buttonExit.TabStop = false;
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // ForgetPassword
            // 
            this.AcceptButton = this.buttonSendEmailSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(362, 412);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSendEmailSubmit);
            this.Controls.Add(this.textBoxVerificationCode);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxEmailUserName);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.labeEmail);
            this.Controls.Add(this.labelVerificationCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ForgetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forget Password | Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxVerificationCode;
        private System.Windows.Forms.TextBox textBoxEmailUserName;
        private System.Windows.Forms.Label labeEmail;
        private System.Windows.Forms.Label labelVerificationCode;
        private System.Windows.Forms.Button buttonSendEmailSubmit;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonExit;
    }
}