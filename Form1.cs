using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ReportVisualizer
{
    public partial class Form1 : Form
    {
        public static DataTable dt = new DataTable("Report");
        public Form1()
        {
            InitializeComponent();

            #region Set up Table corresponding to CSV-Structure
            // Define DataTable with the same Columns the Report.csv has
            dt.Columns.Add(new DataColumn("IP", typeof(string)));
            dt.Columns.Add(new DataColumn("Hostname", typeof(string)));
            dt.Columns.Add(new DataColumn("Port", typeof(string)));
            dt.Columns.Add(new DataColumn("Port Protocol", typeof(string)));
            dt.Columns.Add(new DataColumn("CVSS", typeof(string)));
            dt.Columns.Add(new DataColumn("Severity", typeof(string)));
            dt.Columns.Add(new DataColumn("Solution Type", typeof(string)));
            dt.Columns.Add(new DataColumn("NVT Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Summary", typeof(string)));
            dt.Columns.Add(new DataColumn("Specific Result", typeof(string)));
            dt.Columns.Add(new DataColumn("NVT OID", typeof(string)));
            dt.Columns.Add(new DataColumn("CVEs", typeof(string)));
            dt.Columns.Add(new DataColumn("Task ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Task Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Timestamp", typeof(string)));
            dt.Columns.Add(new DataColumn("Result ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Impact", typeof(string)));
            dt.Columns.Add(new DataColumn("Solution", typeof(string)));
            dt.Columns.Add(new DataColumn("Affected Software/OS", typeof(string)));
            dt.Columns.Add(new DataColumn("Vulnerability Insight", typeof(string)));
            dt.Columns.Add(new DataColumn("Vulnerability Detection Method", typeof(string)));
            dt.Columns.Add(new DataColumn("Product Detection Result", typeof(string)));
            dt.Columns.Add(new DataColumn("BIDs", typeof(string)));
            dt.Columns.Add(new DataColumn("CERTs", typeof(string)));
            dt.Columns.Add(new DataColumn("Other References", typeof(string)));
            #endregion

            // Add a dialog to open a .csv
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Values (;)|*.csv";
            ofd.Title = "Select Data source";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            ofd.ShowDialog();

            // read and load the CSV contents
            dt = ReadCSV(dt, ofd.FileName);
            dataGridView1.DataSource = dt;

            Overview ov = new Overview();
            ov.Show();
            
            //this.Hide();
        }

        public static DataTable ReadCSV(DataTable tableStructure, string filepath)
        {
            try
            {
                int i = 0;

                //Using File.ReadAllLines Method To Read The CSV File.
                foreach (string split in File.ReadAllText(filepath, System.Text.Encoding.UTF7).Split('\r'))
                {

                    if (i > 0)
                        tableStructure.Rows.Add(split.Split(';'));
                    else
                        i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tableStructure;
        }
    }
}
