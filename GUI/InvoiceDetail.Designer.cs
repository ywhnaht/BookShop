namespace BookShop
{
    partial class InvoiceDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceDetail));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.txtTotalPrice = new System.Windows.Forms.Label();
            this.numBookQuantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBook = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveInvoiceDetail = new System.Windows.Forms.Button();
            this.btnEditInvoiceDetail = new System.Windows.Forms.Button();
            this.btnAddInvoiceDetail = new System.Windows.Forms.Button();
            this.ReceiptTitle = new System.Windows.Forms.Label();
            this.dgInvoiceDetail = new System.Windows.Forms.DataGridView();
            this.pdInvoice = new System.Drawing.Printing.PrintDocument();
            this.prdInvoice = new System.Windows.Forms.PrintPreviewDialog();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBookQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPrintInvoice);
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.numBookQuantity);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbBook);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnRemoveInvoiceDetail);
            this.panel3.Controls.Add(this.btnEditInvoiceDetail);
            this.panel3.Controls.Add(this.btnAddInvoiceDetail);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(54, 643);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1469, 222);
            this.panel3.TabIndex = 11;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Location = new System.Drawing.Point(536, 114);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(220, 59);
            this.btnPrintInvoice.TabIndex = 27;
            this.btnPrintInvoice.Text = "In Hóa Đơn";
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.AutoSize = true;
            this.txtTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.Location = new System.Drawing.Point(891, 126);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(178, 31);
            this.txtTotalPrice.TabIndex = 26;
            this.txtTotalPrice.Text = "Tổng Tiền: 0";
            // 
            // numBookQuantity
            // 
            this.numBookQuantity.Location = new System.Drawing.Point(225, 126);
            this.numBookQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.numBookQuantity.Name = "numBookQuantity";
            this.numBookQuantity.Size = new System.Drawing.Size(210, 38);
            this.numBookQuantity.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 31);
            this.label4.TabIndex = 22;
            this.label4.Text = "Số lượng";
            // 
            // cbBook
            // 
            this.cbBook.FormattingEnabled = true;
            this.cbBook.Location = new System.Drawing.Point(225, 42);
            this.cbBook.Margin = new System.Windows.Forms.Padding(4);
            this.cbBook.Name = "cbBook";
            this.cbBook.Size = new System.Drawing.Size(416, 39);
            this.cbBook.TabIndex = 21;
            this.cbBook.SelectedIndexChanged += new System.EventHandler(this.cbBook_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 31);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tên Sách";
            // 
            // btnRemoveInvoiceDetail
            // 
            this.btnRemoveInvoiceDetail.Location = new System.Drawing.Point(1313, 155);
            this.btnRemoveInvoiceDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveInvoiceDetail.Name = "btnRemoveInvoiceDetail";
            this.btnRemoveInvoiceDetail.Size = new System.Drawing.Size(128, 48);
            this.btnRemoveInvoiceDetail.TabIndex = 19;
            this.btnRemoveInvoiceDetail.Text = "Xóa";
            this.btnRemoveInvoiceDetail.UseVisualStyleBackColor = true;
            this.btnRemoveInvoiceDetail.Click += new System.EventHandler(this.btnRemoveInvoiceDetail_Click);
            // 
            // btnEditInvoiceDetail
            // 
            this.btnEditInvoiceDetail.Location = new System.Drawing.Point(1313, 86);
            this.btnEditInvoiceDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditInvoiceDetail.Name = "btnEditInvoiceDetail";
            this.btnEditInvoiceDetail.Size = new System.Drawing.Size(128, 48);
            this.btnEditInvoiceDetail.TabIndex = 18;
            this.btnEditInvoiceDetail.Text = "Sửa";
            this.btnEditInvoiceDetail.UseVisualStyleBackColor = true;
            this.btnEditInvoiceDetail.Click += new System.EventHandler(this.btnEditInvoiceDetail_Click);
            // 
            // btnAddInvoiceDetail
            // 
            this.btnAddInvoiceDetail.Location = new System.Drawing.Point(1313, 23);
            this.btnAddInvoiceDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddInvoiceDetail.Name = "btnAddInvoiceDetail";
            this.btnAddInvoiceDetail.Size = new System.Drawing.Size(128, 48);
            this.btnAddInvoiceDetail.TabIndex = 17;
            this.btnAddInvoiceDetail.Text = "Thêm";
            this.btnAddInvoiceDetail.UseVisualStyleBackColor = true;
            this.btnAddInvoiceDetail.Click += new System.EventHandler(this.btnAddInvoiceDetail_Click);
            // 
            // ReceiptTitle
            // 
            this.ReceiptTitle.AutoSize = true;
            this.ReceiptTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiptTitle.Location = new System.Drawing.Point(649, 49);
            this.ReceiptTitle.Name = "ReceiptTitle";
            this.ReceiptTitle.Size = new System.Drawing.Size(279, 37);
            this.ReceiptTitle.TabIndex = 10;
            this.ReceiptTitle.Text = "Chi Tiết Hóa Đơn";
            // 
            // dgInvoiceDetail
            // 
            this.dgInvoiceDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInvoiceDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInvoiceDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgInvoiceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoiceDetail.Location = new System.Drawing.Point(54, 128);
            this.dgInvoiceDetail.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.dgInvoiceDetail.Name = "dgInvoiceDetail";
            this.dgInvoiceDetail.RowHeadersWidth = 82;
            this.dgInvoiceDetail.RowTemplate.Height = 33;
            this.dgInvoiceDetail.Size = new System.Drawing.Size(1469, 468);
            this.dgInvoiceDetail.TabIndex = 12;
            this.dgInvoiceDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInvoiceDetail_CellClick_1);
            // 
            // pdInvoice
            // 
            this.pdInvoice.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdInvoice_PrintPage);
            // 
            // prdInvoice
            // 
            this.prdInvoice.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prdInvoice.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prdInvoice.ClientSize = new System.Drawing.Size(400, 300);
            this.prdInvoice.Enabled = true;
            this.prdInvoice.Icon = ((System.Drawing.Icon)(resources.GetObject("prdInvoice.Icon")));
            this.prdInvoice.Name = "prdInvoice";
            this.prdInvoice.Visible = false;
            // 
            // InvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1578, 907);
            this.Controls.Add(this.dgInvoiceDetail);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ReceiptTitle);
            this.Name = "InvoiceDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvoiceDetail";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBookQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtTotalPrice;
        private System.Windows.Forms.NumericUpDown numBookQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBook;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemoveInvoiceDetail;
        private System.Windows.Forms.Button btnEditInvoiceDetail;
        private System.Windows.Forms.Button btnAddInvoiceDetail;
        private System.Windows.Forms.Label ReceiptTitle;
        private System.Windows.Forms.DataGridView dgInvoiceDetail;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Drawing.Printing.PrintDocument pdInvoice;
        private System.Windows.Forms.PrintPreviewDialog prdInvoice;
    }
}