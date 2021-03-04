using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YReport.Models
{
    public class YearlyReportModel
    {
        public string TemplatePath { get; set; }
        public string MonthlyReportPath { get; set; }
        public string YearlyReportPath { get; set; }
        public List<MonthlyReportFile> MReportFilePath { get; set; }
        public int ReportYear { get; set; }
        public string NewReportFile { get; set; }

        public int MStartRow { get; set; }
        public int MStartCol { get; set; }
        public int YStartRow { get; set; }
        public int YStartCol { get; set; }
        public Control lbStatus { get; set; }
        public string ExportNamePrefix { get; set; }

        public event ExecutingChanged ExecutingChanged;

        public YearlyReportModel()
        {

        }


        public List<MonthlyReportFile> MonthlyReportFileCheking(string mReportP, int year)
        {
            List<MonthlyReportFile> MReportFiles = new List<MonthlyReportFile>();
            try
            {
                if (Directory.Exists(mReportP) == false)
                    return MReportFiles;

                string[] files = Directory.GetFiles(mReportP);
                foreach (var s in files)
                {
                    string name = Path.GetFileName(s).ToLower();
                    if (name.IndexOf(year.ToString()) > -1 && name.IndexOf("monthly") > -1)
                    {
                        int month = 0;
                        int.TryParse(name.Substring(name.IndexOf("_") + 1, 2), out month);
                        MReportFiles.Add(new MonthlyReportFile(s, month));
                    }
                }

            }
            catch { }
            return MReportFiles;
        }

        public int ExecutingReport(int year, string prefix)
        {
            ReportYear = year;
            ExportNamePrefix = prefix;
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, "Start executing.");

            MReportFilePath = MonthlyReportFileCheking(MonthlyReportPath, ReportYear);

            if(MReportFilePath.Count() == 0)
            {
                lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, "No monthly report has been found. Executing failed.");
                return -1;
            }

            if (File.Exists(TemplatePath) == false)
            {
                lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, "Template file does not exist. Executing failed.");
                return -1;
            }

            NewReportFile = Path.Combine(YearlyReportPath, $"{ExportNamePrefix}_{ReportYear}{Path.GetExtension(TemplatePath)}");

            if (File.Exists(NewReportFile))
            {
                File.Delete(NewReportFile);
                lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, "Delete old report file.");
            }

            lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, "Copy new report file.");


            File.Copy(TemplatePath, NewReportFile);

            lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, "Open report excel file.");


            using (var YReportPackage = new ExcelPackage(new FileInfo(NewReportFile)))
            {
                foreach (var file in MReportFilePath)
                {
                    lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, $"Read data from month: {file.Month}");

                    using (var MReportPackage = new ExcelPackage(new FileInfo(file.FilePath)))
                    {
                        for (int i = 0; i < YReportPackage.Workbook.Worksheets.Count(); i++)
                        {
                            var activeSheet = YReportPackage.Workbook.Worksheets[i];
                            if (activeSheet.Hidden == eWorkSheetHidden.Hidden)
                                continue;

                            if (MReportPackage.Workbook.Worksheets.Count() < i)
                                break;

                            lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, $"Writing data to sheet {activeSheet.Name}");

                            ExecutingSheet(activeSheet, MReportPackage.Workbook.Worksheets[i], file.Month);
                        }
                    }
                }

                YReportPackage.Save();
            }

            lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, "Executing completed.");

            return 1;
        }

        public void ExecutingSheet(ExcelWorksheet ySheet, ExcelWorksheet mSheet, int month)
        {
            try
            {
                int totalDay = DateTime.DaysInMonth(ReportYear, month);
                int mbeginRow = MStartRow + totalDay;
                int mbeginCol = MStartCol;

                int yBeginTotalRow = YStartRow + 12;
                int yBeginTotalCol = YStartCol;

                for (int i = 0; i < 1000; i++)
                {
                    int cl = yBeginTotalCol + i;
                    var cellTotal = ySheet.Cells[yBeginTotalRow, cl];
                    var cellAvg = ySheet.Cells[yBeginTotalRow + 1, cl];

                    var yCellToWrite = ySheet.Cells[YStartRow + month - 1, cl];

                    if (cellTotal == null && cellAvg == null)
                        break;

                    if (string.IsNullOrEmpty(cellTotal.Text) && string.IsNullOrEmpty(cellAvg.Text))
                        break;

                    int mR = 0, mC = 0;

                    if (cellTotal.Value != null && cellTotal.Value != null)
                    {
                        // get monthly report total value
                        mR = mbeginRow;
                        mC = mbeginCol + i;
                    }
                    else
                    {
                        //get monthly report avrega
                        mR = mbeginRow + 1;
                        mC = mbeginCol + i;
                    }

                    var mCellToRead = mSheet.Cells[mR, mC];
                    if (mCellToRead != null && mCellToRead.Value != null)
                    {
                        yCellToWrite.Value = mCellToRead.Value;
                        lbStatus.SetPropertyThreadSafe(() => lbStatus.Text, $"Write data to cell: {yCellToWrite.Address}");
                    }
                    else
                        yCellToWrite.Value = 0;

                }
            }
            catch { }
        }
    }



    public struct MonthlyReportFile
    {
        public string FilePath { get; set; }
        public int Month { get; set; }
        public MonthlyReportFile(string s, int month)
        {
            FilePath = s;
            Month = month == 0 ? 1 : month;
        }
    }
}
