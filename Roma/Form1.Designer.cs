namespace Roma
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHeadLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHeadRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelHeadLeft.SuspendLayout();
            this.tableLayoutPanelHeadRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Century Gothic", 0.1F);
            this.buttonExit.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonExit.Image = global::Roma.Properties.Resources.shut_down;
            this.buttonExit.Location = new System.Drawing.Point(3, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(39, 35);
            this.buttonExit.TabIndex = 83;
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWelcome.Font = new System.Drawing.Font("MV Boli", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(48, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(213, 41);
            this.labelWelcome.TabIndex = 1;
            this.labelWelcome.Text = "Welcome";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUserName
            // 
            this.labelUserName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelUserName.Font = new System.Drawing.Font("MV Boli", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(3, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(132, 41);
            this.labelUserName.TabIndex = 2;
            this.labelUserName.Text = "UserName";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelHeadLeft, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelHeadRight, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1054, 681);
            this.tableLayoutPanelMain.TabIndex = 3;
            // 
            // tableLayoutPanelHeadLeft
            // 
            this.tableLayoutPanelHeadLeft.ColumnCount = 2;
            this.tableLayoutPanelHeadLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelHeadLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeadLeft.Controls.Add(this.buttonExit, 0, 0);
            this.tableLayoutPanelHeadLeft.Controls.Add(this.labelWelcome, 1, 0);
            this.tableLayoutPanelHeadLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHeadLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelHeadLeft.Name = "tableLayoutPanelHeadLeft";
            this.tableLayoutPanelHeadLeft.RowCount = 1;
            this.tableLayoutPanelHeadLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeadLeft.Size = new System.Drawing.Size(264, 41);
            this.tableLayoutPanelHeadLeft.TabIndex = 84;
            // 
            // tableLayoutPanelHeadRight
            // 
            this.tableLayoutPanelHeadRight.ColumnCount = 4;
            this.tableLayoutPanelHeadRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanelHeadRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanelHeadRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.80963F));
            this.tableLayoutPanelHeadRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.190372F));
            this.tableLayoutPanelHeadRight.Controls.Add(this.labelUserName, 0, 0);
            this.tableLayoutPanelHeadRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHeadRight.Location = new System.Drawing.Point(273, 3);
            this.tableLayoutPanelHeadRight.Name = "tableLayoutPanelHeadRight";
            this.tableLayoutPanelHeadRight.RowCount = 1;
            this.tableLayoutPanelHeadRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeadRight.Size = new System.Drawing.Size(778, 41);
            this.tableLayoutPanelHeadRight.TabIndex = 85;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 681);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MinimumSize = new System.Drawing.Size(1070, 720);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelHeadLeft.ResumeLayout(false);
            this.tableLayoutPanelHeadRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeadLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeadRight;
    }
}

