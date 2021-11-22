using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ReportVisualizer
{
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();

            // Implement TimeStamp Showing
            string timestamp = "";
            foreach (DataRow row in Form1.dt.Rows)
            {
                if(!string.IsNullOrWhiteSpace(row.Field<string>("Timestamp")))
                    timestamp = row.Field<string>("Timestamp");
            }
            this.Text = timestamp.Replace("T", " ").Replace("Z", "");


            cmbHosts.Items.Add("All");
            cmbHosts.SelectedIndex = 0;
            
            // Set up Variables
            List<string> IPS = new List<string>();
            List<float> SeverityPerSystem = new List<float>();
            string severity = "";

            Series s = chrtHostSeverity.Series.FindByName("Hosts");
            DataPointCollection sp = s.Points;
            s.Color = Color.DarkGray;
            sp.Clear();

            foreach (DataRow row in Form1.dt.Rows)
            {
                IPS.Add(row.Field<string>("IP"));
            }

            txbInfo.Text = "";

            foreach (string ip in Math.GetAllExistingOnce(IPS.ToArray()))
            {
                if (ip != "\n")
                {
                    cmbHosts.Items.Add(ip);

                    foreach (DataRow row in Form1.dt.Rows)
                    {
                        if (row.Field<string>("IP") == ip)
                            SeverityPerSystem.Add(float.Parse(row.Field<string>("CVSS")));
                    }

                    if (Math.GetAverage(SeverityPerSystem.ToArray()) <= 4)
                        severity = "Low (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")" ;
                    else if (Math.GetAverage(SeverityPerSystem.ToArray()) >= 4 && Math.GetAverage(SeverityPerSystem.ToArray()) <= 6)
                        severity = "Medium (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")";
                    else
                        severity = "High (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")";
                    
                    
                    txbInfo.Text += ip + "\r\nSeverity:" + severity + "\r\n\r\n"; // add summary to txbfixes

                    // Add NVTNames to txbFixes (calling string.toString() is a big no no)
                    foreach (DataRow row in Form1.dt.Rows)
                    {
                        if (!string.IsNullOrWhiteSpace(row.Field<string>("NVT Name")))
                            txbFixes.Text += "NVT Name: " + row.Field<string>("NVT Name") + "\r\nNVT OID:   " + row.Field<string>("NVT OID") + "\r\n\r\n";
                    }

                    sp.Add(Math.GetAverage(SeverityPerSystem.ToArray()));
                    SeverityPerSystem.Clear();
                }
            }
        }

        private void cmbHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Initialize Variables
            Series s = chrtHostSeverity.Series.FindByName("Hosts");
            List<float> SeverityPerSystem = new List<float>();
            List<string> NVTNames = new List<string>();

            string severity = "";

            DataPointCollection sp = s.Points;
            sp.Clear();

            if (cmbHosts.SelectedItem.ToString() == "All")
            {
                List<string> IPS = new List<string>();
                s.Color = Color.DarkGray;
                sp.Clear();

                foreach (DataRow row in Form1.dt.Rows)
                {
                    IPS.Add(row.Field<string>("IP"));
                }

                // Clear additional value holders
                txbInfo.Text = "";
                txbFixes.Text = "";
                lsbAssocCVEs.Items.Clear();

                foreach (string ip in Math.GetAllExistingOnce(IPS.ToArray()))
                {
                    if (ip != "\n")
                    {
                        foreach (DataRow row in Form1.dt.Rows)
                        {
                            if (row.Field<string>("IP") == ip)
                                SeverityPerSystem.Add(float.Parse(row.Field<string>("CVSS")));
                        }

                        // Calculate Severity for all Systems
                        if (Math.GetAverage(SeverityPerSystem.ToArray()) <= 4)
                            severity = "Low (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")";
                        else if (Math.GetAverage(SeverityPerSystem.ToArray()) >= 4 && Math.GetAverage(SeverityPerSystem.ToArray()) <= 6)
                            severity = "Medium (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")";
                        else
                            severity = "High (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")";

                        // Add Severity string and number to txbInfo
                        txbInfo.Text += ip + "\r\n Severity: " + severity + "\r\n\r\n"; //add nvt name to txbFixes, add summary to txbfixes, add CVEs to lsbAssocCVE

                        // Add NVTNames to txbFixes (calling string.toString() is a big no no)
                        foreach (DataRow row in Form1.dt.Rows)
                        {
                            if(!string.IsNullOrWhiteSpace(row.Field<string>("NVT Name")))
                                txbFixes.Text += "NVT Name: " + row.Field<string>("NVT Name") + "\r\nNVT OID:   " + row.Field<string>("NVT OID") + "\r\n\r\n";
                        }

                        // Draw Graph
                        sp.Add(Math.GetAverage(SeverityPerSystem.ToArray()));
                        SeverityPerSystem.Clear();
                    }
                }
            }
            else
            {
                foreach (DataRow row in Form1.dt.Rows)
                {
                    if (row.Field<string>("IP") == cmbHosts.SelectedItem.ToString())
                        SeverityPerSystem.Add(float.Parse(row.Field<string>("CVSS")));
                }
                // Set Color of graph depending on System severity
                if (Math.GetAverage(SeverityPerSystem.ToArray()) <= 4)
                    s.Color = Color.Blue;
                else if (Math.GetAverage(SeverityPerSystem.ToArray()) >= 4 && Math.GetAverage(SeverityPerSystem.ToArray()) <= 6)
                    s.Color = Color.Orange;
                else
                    s.Color = Color.Red;

                // Get Severity for current System
                if (Math.GetAverage(SeverityPerSystem.ToArray()) <= 4)
                    severity = "Low (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")";
                else if (Math.GetAverage(SeverityPerSystem.ToArray()) >= 4 && Math.GetAverage(SeverityPerSystem.ToArray()) <= 6)
                    severity = "Medium (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")";
                else
                    severity = "High (" + Math.GetAverage(SeverityPerSystem.ToArray()) + ")";

                // Clear additional value holders
                txbInfo.Text = "";
                txbFixes.Text = "";
                lsbAssocCVEs.Items.Clear();

                // Add Severity string and number to txbInfo
                txbInfo.Text += cmbHosts.SelectedItem.ToString() + "\r\n Severity: " + severity + "\r\n\r\n"; //add nvt name to txbFixes, add summary to txbfixes, add CVEs to lsbAssocCVE


                // Add NVTNames to txbFixes
                foreach (DataRow row in Form1.dt.Rows)
                {
                    if (row.Field<string>("IP") == cmbHosts.SelectedItem.ToString())
                    {
                        txbFixes.Text += "NVT Name: " + row.Field<string>("NVT Name").ToString() + "\r\nNVT OID:   " + row.Field<string>("NVT OID").ToString() + "\r\n\r\n";
                    }
                }

                // Add CVEs to Listbox
                foreach (DataRow row in Form1.dt.Rows)
                {
                    if (row.Field<string>("IP") == cmbHosts.SelectedItem.ToString())
                    {
                        foreach (string cve in row.Field<string>("CVEs").ToString().Split(','))
                            if (cve.Trim() != "")
                            {
                                lsbAssocCVEs.Items.Add(cve);
                            }
                    }
                }

                // Draw Graph
                sp.Add(Math.GetAverage(SeverityPerSystem.ToArray()));
            }
        }

        private void lsbAssocCVEs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Open default browser to CVE-Vulnerability page
            System.Diagnostics.Process.Start("https://nvd.nist.gov/vuln/detail/" + lsbAssocCVEs.SelectedItem.ToString()); 
        }

        private void Overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
