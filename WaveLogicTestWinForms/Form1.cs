using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using Newtonsoft.Json.Linq;
using WaveLogicTestWinForms.Extensions;
using WaveLogicTestWinForms.Model;
using WaveLogicTestWinForms.Model.JSON;
using WaveLogicTestWinForms.Services;

namespace WaveLogicTestWinForms
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
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
            YahooService service = new YahooService();
            IEnumerable<StockData> dt;
            if (!string.IsNullOrEmpty(tbxDepth.Text))
            {
               dt = service.GetJSONData(new Model.StockInfo(dtpStartDate.Value, dtpEndDate.Value, tbxDepth.Text, tbxStockName.Text));
            }
            else
            {
                var days_diff = (dtpEndDate.Value - dtpStartDate.Value).ToDepthValueInDays();
                 dt = service.GetJSONData(new Model.StockInfo(dtpStartDate.Value, dtpEndDate.Value, days_diff, tbxStockName.Text));
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
    }
}
