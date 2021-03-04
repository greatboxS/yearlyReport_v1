using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YReport.Models;

namespace YReport
{
    public partial class Form1 : Form
    {
        private YearlyReportModel YearlyReportModel { get; set; }
        private Timer Timer = new Timer();
        private List<int> ExecutedYear = new List<int>();
        private int reportMonth, reportDay, reportHour, reportMin, reportSec;
        private bool QuitApp = false;
        private bool Show = false;
        public Form1()
        {
            InitializeComponent();

            YearlyReportModel = new YearlyReportModel();
            YearlyReportModel.MStartCol = Properties.Settings.Default.MBeginCol;
            YearlyReportModel.MStartRow = Properties.Settings.Default.MBeginRow;
            YearlyReportModel.YStartCol = Properties.Settings.Default.YBeginCol;
            YearlyReportModel.YStartRow = Properties.Settings.Default.YBeginRow;
            YearlyReportModel.TemplatePath = Properties.Settings.Default.TemplatePath;
            YearlyReportModel.MonthlyReportPath = Properties.Settings.Default.MReportPath;
            YearlyReportModel.YearlyReportPath = Properties.Settings.Default.YReportPath;

            txtTemplatePath.Text = YearlyReportModel.TemplatePath;
            txtMonthlyReportFolder.Text = YearlyReportModel.MonthlyReportPath;
            txtYearlyReportFolder.Text = YearlyReportModel.YearlyReportPath;

            YearlyReportModel.lbStatus = lbStatus;
            Timer.Interval = 500;
            Timer.Tick += Timer_Tick;
            Timer.Enabled = true;
            Timer.Start();

            reportMonth = Properties.Settings.Default.RMonth;
            reportDay = Properties.Settings.Default.RDay;
            reportHour = Properties.Settings.Default.RHour;
            reportMin = Properties.Settings.Default.RMin;
            reportSec = Properties.Settings.Default.RSec;

            YearlyReportNotify.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Show", ShowYearlyReportClick),
                new MenuItem("Exit tool", OnExitToolClick)
            });

            YearlyReportNotify.Visible = true;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.Visible = Show;
            Show = false;
        }

        private void ShowYearlyReportClick(object sender, EventArgs e)
        {
            Show = true;
            this.Show();
            this.BringToFront();
            YearlyReportNotify.Visible = false;
        }

        private void OnExitToolClick(object sender, EventArgs e)
        {
            QuitApp = true;
            Application.Exit();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                int year = DateTime.Now.Year;
                string prefix = "YearlyParameter";
                if (DateTime.Now.Month == reportMonth &&
                    DateTime.Now.Day == reportDay &&
                    DateTime.Now.Hour == reportHour &&
                    DateTime.Now.Minute == reportMin &&
                    DateTime.Now.Second == reportSec)
                {
                    if (ExecutedYear.Contains(year))
                        return;

                    ExecutedYear.Add(year);
                    Task.Factory.StartNew(() => { YearlyReportModel.ExecutingReport(year, prefix); });
                }
            }
            catch { }
        }

        private void ExecutingReport()
        {
            if (string.IsNullOrEmpty(YearlyReportModel.TemplatePath) ||
                            string.IsNullOrEmpty(YearlyReportModel.MonthlyReportPath) ||
                            string.IsNullOrEmpty(YearlyReportModel.YearlyReportPath))
            {
                MessageBox.Show("Template or Monthly folder or Yearly folder is empty.");
                return;
            }
            int year = 0;
            int.TryParse(txtYear.Text, out year);
            if (year == 0)
            {
                MessageBox.Show("Please enter year to be reported (yyyy)");
                return;
            }

            if (string.IsNullOrEmpty(txtNamePrefix.Text))
            {
                MessageBox.Show("Please enter export name prefix.");
                return;
            }


            Task.Factory.StartNew(() => { YearlyReportModel.ExecutingReport(year, txtNamePrefix.Text); });
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            ExecutingReport();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string templateName = BrowseFile();
            if (templateName != null)
            {
                YearlyReportModel.TemplatePath = templateName;
                Properties.Settings.Default.TemplatePath = templateName;
                Properties.Settings.Default.Save();
                txtTemplatePath.Text = templateName;
            }
        }

        private string BrowseFolder()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                return folderBrowserDialog.SelectedPath;
            else
                return null;
        }

        private string BrowseFile()
        {
            OpenFileDialog folderBrowserDialog = new OpenFileDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                return folderBrowserDialog.FileName;
            else
                return null;
        }

        private void btnMonthBrowse_Click(object sender, EventArgs e)
        {
            string path = BrowseFolder();
            if (path != null)
            {
                YearlyReportModel.MonthlyReportPath = path;
                Properties.Settings.Default.MReportPath = path;
                Properties.Settings.Default.Save();
                txtMonthlyReportFolder.Text = path;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (QuitApp)
                return;
            
            YearlyReportNotify.Visible = true;
            Hide();
            e.Cancel = true;
        }

        private void YearlyReportNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            YearlyReportNotify.Visible = false;
            this.BringToFront();
            Show = true;
            this.Show();
        }

        private void btnYearBrowse_Click(object sender, EventArgs e)
        {
            string path = BrowseFolder();
            if (path != null)
            {
                YearlyReportModel.YearlyReportPath = path;
                Properties.Settings.Default.YReportPath = path;
                Properties.Settings.Default.Save();
                txtYearlyReportFolder.Text = path;
            }
        }

        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(char.IsDigit((char)e.KeyCode) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Enter);

            if (e.KeyCode == Keys.Enter)
            {
                ExecutingReport();
            }
        }

        private void MenuOpenReportFolder_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(YearlyReportModel.YearlyReportPath);
            }
            catch { }
        }

        private void MenuRecentReportFile_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(YearlyReportModel.NewReportFile);
            }
            catch { }
        }
    }

    public delegate void ExecutingChanged(string message, object sender);


}
