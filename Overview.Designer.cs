
namespace ReportVisualizer
{
    partial class Overview
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.cmbHosts = new System.Windows.Forms.ComboBox();
            this.chrtHostSeverity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txbFixes = new System.Windows.Forms.TextBox();
            this.txbInfo = new System.Windows.Forms.TextBox();
            this.lsbAssocCVEs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chrtHostSeverity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbHosts
            // 
            this.cmbHosts.FormattingEnabled = true;
            this.cmbHosts.Location = new System.Drawing.Point(553, 13);
            this.cmbHosts.Name = "cmbHosts";
            this.cmbHosts.Size = new System.Drawing.Size(235, 21);
            this.cmbHosts.TabIndex = 0;
            this.cmbHosts.SelectedIndexChanged += new System.EventHandler(this.cmbHosts_SelectedIndexChanged);
            // 
            // chrtHostSeverity
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtHostSeverity.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Overview";
            this.chrtHostSeverity.Legends.Add(legend1);
            this.chrtHostSeverity.Location = new System.Drawing.Point(13, 13);
            this.chrtHostSeverity.Name = "chrtHostSeverity";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Hosts";
            series1.Points.Add(dataPoint1);
            this.chrtHostSeverity.Series.Add(series1);
            this.chrtHostSeverity.Size = new System.Drawing.Size(534, 299);
            this.chrtHostSeverity.TabIndex = 2;
            this.chrtHostSeverity.Text = "Overview";
            title1.Name = "Title";
            this.chrtHostSeverity.Titles.Add(title1);
            // 
            // txbFixes
            // 
            this.txbFixes.Location = new System.Drawing.Point(13, 318);
            this.txbFixes.Multiline = true;
            this.txbFixes.Name = "txbFixes";
            this.txbFixes.ReadOnly = true;
            this.txbFixes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbFixes.Size = new System.Drawing.Size(534, 119);
            this.txbFixes.TabIndex = 3;
            // 
            // txbInfo
            // 
            this.txbInfo.Location = new System.Drawing.Point(553, 40);
            this.txbInfo.Multiline = true;
            this.txbInfo.Name = "txbInfo";
            this.txbInfo.ReadOnly = true;
            this.txbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbInfo.Size = new System.Drawing.Size(235, 204);
            this.txbInfo.TabIndex = 4;
            // 
            // lsbAssocCVEs
            // 
            this.lsbAssocCVEs.FormattingEnabled = true;
            this.lsbAssocCVEs.Location = new System.Drawing.Point(553, 286);
            this.lsbAssocCVEs.Name = "lsbAssocCVEs";
            this.lsbAssocCVEs.Size = new System.Drawing.Size(235, 147);
            this.lsbAssocCVEs.TabIndex = 5;
            this.lsbAssocCVEs.SelectedIndexChanged += new System.EventHandler(this.lsbAssocCVEs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Associated CVEs";
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbAssocCVEs);
            this.Controls.Add(this.txbInfo);
            this.Controls.Add(this.txbFixes);
            this.Controls.Add(this.chrtHostSeverity);
            this.Controls.Add(this.cmbHosts);
            this.Name = "Overview";
            this.Text = "Overview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Overview_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chrtHostSeverity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbHosts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtHostSeverity;
        private System.Windows.Forms.TextBox txbFixes;
        private System.Windows.Forms.TextBox txbInfo;
        private System.Windows.Forms.ListBox lsbAssocCVEs;
        private System.Windows.Forms.Label label1;
    }
}