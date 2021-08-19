using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WaveLogicTestWinForms.Extensions;
using WaveLogicTestWinForms.Model;
using WaveLogicTestWinForms.Resources;
using WaveLogicTestWinForms.Services;

namespace WaveLogicTestWinForms
{
    public partial class frmMain : Form
    {
        YahooService service = new YahooService();

        public frmMain()
        {
            InitializeComponent();
            cbxPeriod.DataSource = Enum.GetValues(typeof(Period));
        }

        private void btnDownloadFromYahoo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxStockName.Text))
            {
                frmMainErrorProvider.SetError(tbxStockName, TextResources.NeedInputStockName);
                return;
            }
            else
            {
                frmMainErrorProvider.SetError(tbxStockName, "");
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
            tsAppStatus.Text = TextResources.DataRecievedSuccessfuly;

            }

      

        private void tbxDepth_Validating(object sender, CancelEventArgs e)
        {
           
            if (!string.IsNullOrEmpty(tbxDepth.Text)&&tbxDepth.Text.IsDepthString())
            {
                tbxDepth.BackColor = Color.Green;
                dtpEndDate.Enabled = false;
                frmMainErrorProvider.SetError(tbxDepth, "");
            }
            else if (string.IsNullOrEmpty(tbxDepth.Text))
            {
                dtpEndDate.Enabled = true;
                frmMainErrorProvider.SetError(tbxDepth, "");
                tbxDepth.BackColor = SystemColors.Window;
            }
            else
            {

                dtpEndDate.Enabled = false;
                frmMainErrorProvider.SetError(tbxDepth, TextResources.IncorrectDepthValue);
            }
        }

        private void btnTransformData_Click(object sender, EventArgs e)
        {
           
            dtgStockValues.DataSource =  service.Store.TransformTo((Period)cbxPeriod.SelectedItem).ToDataTable();
            tsAppStatus.Text = TextResources.TransformationCompleted;
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            var dr = saveExportResult.ShowDialog();

            if (dr == DialogResult.OK)
            {
                service.Store.TransformTo((Period)cbxPeriod.SelectedItem).ExportToPDF(saveExportResult.FileName);
                tsAppStatus.Text = TextResources.SavingCompleted;
                
            }
            else
            {
                tsAppStatus.Text = TextResources.SavingCanceled;
            }
           
        }




    }
}
