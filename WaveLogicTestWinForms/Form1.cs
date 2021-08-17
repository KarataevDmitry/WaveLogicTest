using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WaveLogicTestWinForms.Extensions;
using WaveLogicTestWinForms.Model;
using WaveLogicTestWinForms.Services;

namespace WaveLogicTestWinForms
{
    public partial class Form1 : Form
    {
        YahooService service = new YahooService();

        public Form1()
        {
            InitializeComponent();
            cbxPeriod.DataSource = Enum.GetValues(typeof(Period));
        }

        private void btnDownloadFromYahoo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxStockName.Text))
            {
                errorProvider1.SetError(tbxStockName, "You need input stock name");
                return;
            }
            else
            {
                errorProvider1.SetError(tbxStockName, "");
            }
           
            if (!string.IsNullOrEmpty(tbxDepth.Text))
            {
               dtgStockValues.DataSource = service.GetJSONData(new Model.StockInfo(dtpStartDate.Value, dtpEndDate.Value, tbxDepth.Text, tbxStockName.Text)).ToDataTable();

            }
            else
            {
                var days_diff = (dtpEndDate.Value - dtpStartDate.Value).ToDepthValueInDays();
                dtgStockValues.DataSource = service.GetJSONData(new Model.StockInfo(dtpStartDate.Value, dtpEndDate.Value, days_diff, tbxStockName.Text)).ToDataTable();
            }

            //dtgStockValues.DataSource = dt;
            dtgStockValues.Refresh();

            }

      

        private void tbxDepth_Validating(object sender, CancelEventArgs e)
        {
           
            if (!string.IsNullOrEmpty(tbxDepth.Text)&&tbxDepth.Text.IsDepthString())
            {
                tbxDepth.BackColor = Color.Green;
                dtpEndDate.Enabled = false;
                errorProvider1.SetError(tbxDepth, "");
            }
            else if (string.IsNullOrEmpty(tbxDepth.Text))
            {
                dtpEndDate.Enabled = true;
                errorProvider1.SetError(tbxDepth, "");
                tbxDepth.BackColor = SystemColors.Window;
            }
            else
            {

                dtpEndDate.Enabled = false;
                errorProvider1.SetError(tbxDepth, "Value should be a kind of \"DdMmYy\", where D is count of days backward from StartDate, M - count of months, etc.");
            }
        }

        private void btnTransformData_Click(object sender, EventArgs e)
        {
           dtgStockValues.DataSource =  service.Store.TransformTo((Period)cbxPeriod.SelectedItem).ToDataTable();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            service.Store.TransformTo((Period)cbxPeriod.SelectedItem).ExportToPDF("pdf_example.pdf");
        }
    }
}
