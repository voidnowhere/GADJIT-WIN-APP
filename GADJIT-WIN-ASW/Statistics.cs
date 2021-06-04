﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADJIT_WIN_ASW
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void LoadWorkerStatsReport()
        {
            try
            {
                CrystalReportWorkerStats crystalReportWorkerStats = new CrystalReportWorkerStats();
                crystalReportWorkerStats.SetDatabaseLogon("gadjit_basic", "cz3l@K$H%!W2", "pff-win-app.database.windows.net", "GADJIT");
                crystalReportWorkerStats.SetParameterValue("from", DTPFrom.Value.ToShortDateString());
                crystalReportWorkerStats.SetParameterValue("to", DateTime.Parse(DateTime.Now.ToShortDateString()).AddHours(23).AddMinutes(59).AddSeconds(59).ToString());
                crystalReportWorkerStats.SetParameterValue("toDate", DateTime.Now.ToShortDateString());
                CrystalReportViewer.ReportSource = crystalReportWorkerStats;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LoadWorkerStatsReport()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGadgetCategoryStatsReport()
        {
            try
            {
                CrystalReportGadgetCategoryStats gadgetCategoryStats = new CrystalReportGadgetCategoryStats();
                gadgetCategoryStats.SetDatabaseLogon("gadjit_basic", "cz3l@K$H%!W2", "pff-win-app.database.windows.net", "GADJIT");
                gadgetCategoryStats.SetParameterValue("from", DTPFrom.Value.ToShortDateString());
                gadgetCategoryStats.SetParameterValue("to", DateTime.Parse(DateTime.Now.ToShortDateString()).AddHours(23).AddMinutes(59).AddSeconds(59).ToString());
                gadgetCategoryStats.SetParameterValue("toDate", DateTime.Now.ToShortDateString());
                CrystalReportViewer.ReportSource = gadgetCategoryStats;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LoadGadgetStatsReport()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGadgetBrandStatsReport()
        {
            try
            {
                CrystalReportGadgetBrandStats gadgetBrandStats = new CrystalReportGadgetBrandStats();
                gadgetBrandStats.SetDatabaseLogon("gadjit_basic", "cz3l@K$H%!W2", "pff-win-app.database.windows.net", "GADJIT");
                gadgetBrandStats.SetParameterValue("from", DTPFrom.Value.ToShortDateString());
                gadgetBrandStats.SetParameterValue("to", DateTime.Parse(DateTime.Now.ToShortDateString()).AddHours(23).AddMinutes(59).AddSeconds(59).ToString());
                gadgetBrandStats.SetParameterValue("toDate", DateTime.Now.ToShortDateString());
                CrystalReportViewer.ReportSource = gadgetBrandStats;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LoadGadgetStatsReport()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            DTPFrom.MaxDate = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
            DTPTo.MaxDate = DateTime.Parse(DateTime.Now.ToShortDateString()).AddHours(23).AddMinutes(59).AddSeconds(59);
            RadioButtonWorkerStats.Checked = true;
            LoadWorkerStatsReport();
        }

        private void RadioButtonWorkerStats_Click(object sender, EventArgs e)
        {
            if (RadioButtonWorkerStats.Checked)
            {
                LoadWorkerStatsReport();
            }
        }

        private void RadioButtonGadgetCategoryStats_Click(object sender, EventArgs e)
        {
            if (RadioButtonGadgetCategoryStats.Checked)
            {
                LoadGadgetCategoryStatsReport();
            }
        }

        private void RadioButtonGadgetBrandStats_Click(object sender, EventArgs e)
        {
            if (RadioButtonGadgetBrandStats.Checked)
            {
                LoadGadgetBrandStatsReport();
            }
        }
    }
}
