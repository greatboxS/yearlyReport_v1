namespace YReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnMonthBrowse = new System.Windows.Forms.Button();
            this.txtMonthlyReportFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnYearBrowse = new System.Windows.Forms.Button();
            this.txtYearlyReportFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpenReportFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecentReportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamePrefix = new System.Windows.Forms.TextBox();
            this.YearlyReportNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(50, 96);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(68, 20);
            this.txtYear.TabIndex = 2;
            this.txtYear.Text = "2021";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYear_KeyDown);
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(124, 19);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(325, 20);
            this.txtTemplatePath.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Template file:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(455, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(39, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(419, 94);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnMonthBrowse
            // 
            this.btnMonthBrowse.Location = new System.Drawing.Point(455, 42);
            this.btnMonthBrowse.Name = "btnMonthBrowse";
            this.btnMonthBrowse.Size = new System.Drawing.Size(39, 23);
            this.btnMonthBrowse.TabIndex = 9;
            this.btnMonthBrowse.Text = "...";
            this.btnMonthBrowse.UseVisualStyleBackColor = true;
            this.btnMonthBrowse.Click += new System.EventHandler(this.btnMonthBrowse_Click);
            // 
            // txtMonthlyReportFolder
            // 
            this.txtMonthlyReportFolder.Location = new System.Drawing.Point(124, 44);
            this.txtMonthlyReportFolder.Name = "txtMonthlyReportFolder";
            this.txtMonthlyReportFolder.Size = new System.Drawing.Size(325, 20);
            this.txtMonthlyReportFolder.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Monthly report folder:";
            // 
            // btnYearBrowse
            // 
            this.btnYearBrowse.Location = new System.Drawing.Point(455, 67);
            this.btnYearBrowse.Name = "btnYearBrowse";
            this.btnYearBrowse.Size = new System.Drawing.Size(39, 23);
            this.btnYearBrowse.TabIndex = 12;
            this.btnYearBrowse.Text = "...";
            this.btnYearBrowse.UseVisualStyleBackColor = true;
            this.btnYearBrowse.Click += new System.EventHandler(this.btnYearBrowse_Click);
            // 
            // txtYearlyReportFolder
            // 
            this.txtYearlyReportFolder.Location = new System.Drawing.Point(124, 69);
            this.txtYearlyReportFolder.Name = "txtYearlyReportFolder";
            this.txtYearlyReportFolder.Size = new System.Drawing.Size(325, 20);
            this.txtYearlyReportFolder.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Yearly report folder:";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(504, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "https://github.com/greatboxs/yearlyreport_v1\r\n";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbStatus
            // 
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbStatus.Location = new System.Drawing.Point(0, 130);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(504, 23);
            this.lbStatus.TabIndex = 14;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(504, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpenReportFolder,
            this.MenuRecentReportFile});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MenuOpenReportFolder
            // 
            this.MenuOpenReportFolder.Name = "MenuOpenReportFolder";
            this.MenuOpenReportFolder.Size = new System.Drawing.Size(206, 22);
            this.MenuOpenReportFolder.Text = "Open yearly report folder";
            this.MenuOpenReportFolder.Click += new System.EventHandler(this.MenuOpenReportFolder_Click);
            // 
            // MenuRecentReportFile
            // 
            this.MenuRecentReportFile.Name = "MenuRecentReportFile";
            this.MenuRecentReportFile.Size = new System.Drawing.Size(206, 22);
            this.MenuRecentReportFile.Text = "Recent report file";
            this.MenuRecentReportFile.Click += new System.EventHandler(this.MenuRecentReportFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Export name prefix:";
            // 
            // txtNamePrefix
            // 
            this.txtNamePrefix.Location = new System.Drawing.Point(238, 96);
            this.txtNamePrefix.Name = "txtNamePrefix";
            this.txtNamePrefix.Size = new System.Drawing.Size(173, 20);
            this.txtNamePrefix.TabIndex = 17;
            this.txtNamePrefix.Text = "YearlyParameter";
            this.txtNamePrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // YearlyReportNotify
            // 
            this.YearlyReportNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("YearlyReportNotify.Icon")));
            this.YearlyReportNotify.Text = "YearlyReport";
            this.YearlyReportNotify.Visible = true;
            this.YearlyReportNotify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.YearlyReportNotify_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 166);
            this.Controls.Add(this.txtNamePrefix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnYearBrowse);
            this.Controls.Add(this.txtYearlyReportFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMonthBrowse);
            this.Controls.Add(this.txtMonthlyReportFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtTemplatePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(520, 205);
            this.MinimumSize = new System.Drawing.Size(520, 205);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yearly report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnMonthBrowse;
        private System.Windows.Forms.TextBox txtMonthlyReportFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnYearBrowse;
        private System.Windows.Forms.TextBox txtYearlyReportFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuOpenReportFolder;
        private System.Windows.Forms.ToolStripMenuItem MenuRecentReportFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamePrefix;
        private System.Windows.Forms.NotifyIcon YearlyReportNotify;
    }
}

