
namespace WaveLogicTestWinForms
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtgStockValues = new System.Windows.Forms.DataGridView();
            this.btnDownloadFromYahoo = new System.Windows.Forms.Button();
            this.tbxStockName = new System.Windows.Forms.TextBox();
            this.tbxDepth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodStart = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnTransformData = new System.Windows.Forms.Button();
            this.frmMainErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbxPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStockValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmMainErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgStockValues
            // 
            this.dtgStockValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgStockValues.Location = new System.Drawing.Point(71, 108);
            this.dtgStockValues.Name = "dtgStockValues";
            this.dtgStockValues.RowTemplate.Height = 25;
            this.dtgStockValues.Size = new System.Drawing.Size(663, 292);
            this.dtgStockValues.TabIndex = 0;
            // 
            // btnDownloadFromYahoo
            // 
            this.btnDownloadFromYahoo.Location = new System.Drawing.Point(71, 415);
            this.btnDownloadFromYahoo.Name = "btnDownloadFromYahoo";
            this.btnDownloadFromYahoo.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadFromYahoo.TabIndex = 1;
            this.btnDownloadFromYahoo.Text = "Yahoo!";
            this.btnDownloadFromYahoo.UseVisualStyleBackColor = true;
            this.btnDownloadFromYahoo.Click += new System.EventHandler(this.btnDownloadFromYahoo_Click);
            // 
            // tbxStockName
            // 
            this.tbxStockName.Location = new System.Drawing.Point(71, 79);
            this.tbxStockName.Name = "tbxStockName";
            this.tbxStockName.Size = new System.Drawing.Size(75, 23);
            this.tbxStockName.TabIndex = 2;
            // 
            // tbxDepth
            // 
            this.tbxDepth.Location = new System.Drawing.Point(179, 79);
            this.tbxDepth.Name = "tbxDepth";
            this.tbxDepth.Size = new System.Drawing.Size(60, 23);
            this.tbxDepth.TabIndex = 3;
            this.tbxDepth.Validating += new System.ComponentModel.CancelEventHandler(this.tbxDepth_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "StockName";
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Location = new System.Drawing.Point(164, 58);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(90, 15);
            this.lblDepth.TabIndex = 4;
            this.lblDepth.Text = "Depth (ndkmly)";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(270, 79);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(142, 23);
            this.dtpStartDate.TabIndex = 5;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(429, 79);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(132, 23);
            this.dtpEndDate.TabIndex = 5;
            // 
            // lblPeriodStart
            // 
            this.lblPeriodStart.AutoSize = true;
            this.lblPeriodStart.Location = new System.Drawing.Point(324, 58);
            this.lblPeriodStart.Name = "lblPeriodStart";
            this.lblPeriodStart.Size = new System.Drawing.Size(31, 15);
            this.lblPeriodStart.TabIndex = 4;
            this.lblPeriodStart.Text = "Start";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(480, 61);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(27, 15);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End";
            // 
            // btnTransformData
            // 
            this.btnTransformData.Location = new System.Drawing.Point(179, 414);
            this.btnTransformData.Name = "btnTransformData";
            this.btnTransformData.Size = new System.Drawing.Size(75, 23);
            this.btnTransformData.TabIndex = 6;
            this.btnTransformData.Text = "Transform";
            this.btnTransformData.UseVisualStyleBackColor = true;
            this.btnTransformData.Click += new System.EventHandler(this.btnTransformData_Click);
            // 
            // errorProvider1
            // 
            this.frmMainErrorProvider.ContainerControl = this;
            // 
            // cbxPeriod
            // 
            this.cbxPeriod.FormattingEnabled = true;
            this.cbxPeriod.Location = new System.Drawing.Point(588, 79);
            this.cbxPeriod.Name = "cbxPeriod";
            this.cbxPeriod.Size = new System.Drawing.Size(121, 23);
            this.cbxPeriod.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(627, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Period";
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(292, 415);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(93, 23);
            this.btnExportPDF.TabIndex = 8;
            this.btnExportPDF.Text = "ExportToPDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.cbxPeriod);
            this.Controls.Add(this.btnTransformData);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblPeriodStart);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDepth);
            this.Controls.Add(this.tbxStockName);
            this.Controls.Add(this.btnDownloadFromYahoo);
            this.Controls.Add(this.dtgStockValues);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtgStockValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmMainErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgStockValues;
        private System.Windows.Forms.Button btnDownloadFromYahoo;
        private System.Windows.Forms.TextBox tbxStockName;
        private System.Windows.Forms.TextBox tbxDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblPeriodStart;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnTransformData;
        private System.Windows.Forms.ErrorProvider frmMainErrorProvider;
        private System.Windows.Forms.ComboBox cbxPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExportPDF;
    }
}

