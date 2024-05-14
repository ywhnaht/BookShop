namespace BookShop
{
    partial class ReceiptDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTotalPrice = new System.Windows.Forms.Label();
            this.numBookQuantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBook = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveReceiptDetail = new System.Windows.Forms.Button();
            this.btnEditReceiptDetail = new System.Windows.Forms.Button();
            this.btnAddReceiptDetail = new System.Windows.Forms.Button();
            this.ReceiptTitle = new System.Windows.Forms.Label();
            this.dgReceiptDetail = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBookQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReceiptDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.numBookQuantity);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbBook);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnRemoveReceiptDetail);
            this.panel3.Controls.Add(this.btnEditReceiptDetail);
            this.panel3.Controls.Add(this.btnAddReceiptDetail);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(59, 651);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1469, 222);
            this.panel3.TabIndex = 8;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.AutoSize = true;
            this.txtTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.Location = new System.Drawing.Point(968, 128);
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
            // btnRemoveReceiptDetail
            // 
            this.btnRemoveReceiptDetail.Location = new System.Drawing.Point(1313, 155);
            this.btnRemoveReceiptDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveReceiptDetail.Name = "btnRemoveReceiptDetail";
            this.btnRemoveReceiptDetail.Size = new System.Drawing.Size(128, 48);
            this.btnRemoveReceiptDetail.TabIndex = 19;
            this.btnRemoveReceiptDetail.Text = "Xóa";
            this.btnRemoveReceiptDetail.UseVisualStyleBackColor = true;
            this.btnRemoveReceiptDetail.Click += new System.EventHandler(this.btnRemoveReceiptDetail_Click);
            // 
            // btnEditReceiptDetail
            // 
            this.btnEditReceiptDetail.Location = new System.Drawing.Point(1313, 86);
            this.btnEditReceiptDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditReceiptDetail.Name = "btnEditReceiptDetail";
            this.btnEditReceiptDetail.Size = new System.Drawing.Size(128, 48);
            this.btnEditReceiptDetail.TabIndex = 18;
            this.btnEditReceiptDetail.Text = "Sửa";
            this.btnEditReceiptDetail.UseVisualStyleBackColor = true;
            this.btnEditReceiptDetail.Click += new System.EventHandler(this.btnEditReceiptDetail_Click);
            // 
            // btnAddReceiptDetail
            // 
            this.btnAddReceiptDetail.Location = new System.Drawing.Point(1313, 23);
            this.btnAddReceiptDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddReceiptDetail.Name = "btnAddReceiptDetail";
            this.btnAddReceiptDetail.Size = new System.Drawing.Size(128, 48);
            this.btnAddReceiptDetail.TabIndex = 17;
            this.btnAddReceiptDetail.Text = "Thêm";
            this.btnAddReceiptDetail.UseVisualStyleBackColor = true;
            this.btnAddReceiptDetail.Click += new System.EventHandler(this.btnAddReceiptDetail_Click);
            // 
            // ReceiptTitle
            // 
            this.ReceiptTitle.AutoSize = true;
            this.ReceiptTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiptTitle.Location = new System.Drawing.Point(620, 58);
            this.ReceiptTitle.Name = "ReceiptTitle";
            this.ReceiptTitle.Size = new System.Drawing.Size(323, 37);
            this.ReceiptTitle.TabIndex = 7;
            this.ReceiptTitle.Text = "Chi Tiết Phiếu Nhập";
            // 
            // dgReceiptDetail
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgReceiptDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgReceiptDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgReceiptDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgReceiptDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgReceiptDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgReceiptDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReceiptDetail.Location = new System.Drawing.Point(59, 139);
            this.dgReceiptDetail.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.dgReceiptDetail.Name = "dgReceiptDetail";
            this.dgReceiptDetail.RowHeadersWidth = 82;
            this.dgReceiptDetail.RowTemplate.Height = 33;
            this.dgReceiptDetail.Size = new System.Drawing.Size(1469, 468);
            this.dgReceiptDetail.TabIndex = 6;
            this.dgReceiptDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReceiptDetail_CellClick);
            // 
            // ReceiptDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1589, 907);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ReceiptTitle);
            this.Controls.Add(this.dgReceiptDetail);
            this.Name = "ReceiptDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReceiptDetail";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBookQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReceiptDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label ReceiptTitle;
        private System.Windows.Forms.DataGridView dgReceiptDetail;
        private System.Windows.Forms.NumericUpDown numBookQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBook;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemoveReceiptDetail;
        private System.Windows.Forms.Button btnEditReceiptDetail;
        private System.Windows.Forms.Button btnAddReceiptDetail;
        private System.Windows.Forms.Label txtTotalPrice;
    }
}