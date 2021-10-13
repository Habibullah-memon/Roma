namespace Roma
{
    partial class ChangePassword
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
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labeConfirmPassword = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelWelcomeUserf = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.textBoxNewPassword.Location = new System.Drawing.Point(40, 140);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(282, 34);
            this.textBoxNewPassword.TabIndex = 1;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(40, 207);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(282, 34);
            this.textBoxConfirmPassword.TabIndex = 2;
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labelNewPassword.Location = new System.Drawing.Point(40, 117);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(142, 22);
            this.labelNewPassword.TabIndex = 85;
            this.labelNewPassword.Text = "New Password";
            // 
            // labeConfirmPassword
            // 
            this.labeConfirmPassword.AutoSize = true;
            this.labeConfirmPassword.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labeConfirmPassword.Location = new System.Drawing.Point(40, 184);
            this.labeConfirmPassword.Name = "labeConfirmPassword";
            this.labeConfirmPassword.Size = new System.Drawing.Size(171, 22);
            this.labeConfirmPassword.TabIndex = 86;
            this.labeConfirmPassword.Text = "Confirm Password";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.AutoEllipsis = true;
            this.buttonSubmit.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSubmit.FlatAppearance.BorderSize = 2;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Comic Sans MS", 13.25F, System.Drawing.FontStyle.Bold);
            this.buttonSubmit.Location = new System.Drawing.Point(115, 261);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(138, 41);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // labelWelcomeUserf
            // 
            this.labelWelcomeUserf.AutoSize = true;
            this.labelWelcomeUserf.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.labelWelcomeUserf.Location = new System.Drawing.Point(143, 71);
            this.labelWelcomeUserf.Name = "labelWelcomeUserf";
            this.labelWelcomeUserf.Size = new System.Drawing.Size(49, 23);
            this.labelWelcomeUserf.TabIndex = 85;
            this.labelWelcomeUserf.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label1.Location = new System.Drawing.Point(40, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 22);
            this.label1.TabIndex = 85;
            this.label1.Text = "Welcome :";
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
            this.buttonExit.Location = new System.Drawing.Point(319, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(43, 36);
            this.buttonExit.TabIndex = 97;
            this.buttonExit.TabStop = false;
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // ChangePassword
            // 
            this.AcceptButton = this.buttonSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(362, 412);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWelcomeUserf);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.labeConfirmPassword);
            this.Name = "ChangePassword";
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labeConfirmPassword;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelWelcomeUserf;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonExit;
    }
}