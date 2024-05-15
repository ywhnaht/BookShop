using BookShop.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class InvoiceDetail : Form
    {
        private Invoice_Detail_BUS invoiceDetailBUS = new Invoice_Detail_BUS();
        private DataProvider dataProvider  = new DataProvider();
        private MainForm mainForm;
        private int invoiceId;
        private int invoiceDetailId;
        private int book_bookId;
        private string bookName;
        public InvoiceDetail(int invoiceId, MainForm mainForm)
        {
            InitializeComponent();
            this.invoiceId = invoiceId;
            this.mainForm = mainForm;
            Init();
        }

        private void Init()
        {
            LoaddgInvoiceDetail();
            LoadcbBook();
            LoadPrice();
        }

        private void LoaddgInvoiceDetail()
        {
            DataTable dt = invoiceDetailBUS.GetInvoiceDetails(invoiceId);
            dgInvoiceDetail.DataSource = dt;
            if (invoiceDetailBUS.GetInvoiceStatus(invoiceId))
            {
                btnPrintInvoice.Visible = false;
                btnAddInvoiceDetail.Visible = false;
                btnEditInvoiceDetail.Visible = false;
                btnRemoveInvoiceDetail.Visible = false; 
            }
        }

        private void LoadPrice()
        {
            try
            {
                int totalPrice = invoiceDetailBUS.GetTotalPrice(invoiceId);
                txtTotalPrice.Text = "Tổng Tiền: " + totalPrice.ToString("N0") + " VND";
                invoiceDetailBUS.UpdateInvoiceTotalPrice(invoiceId);
            }
            catch
            {
                txtTotalPrice.Text = "Tổng Tiền: 0";
            }
        }

        private void LoadcbBook()
        {
            DataTable dt = invoiceDetailBUS.GetBook();
            cbBook.DisplayMember = "book_name";
            cbBook.ValueMember = "id";
            cbBook.DataSource = dt;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {

        }
        private void btnAddInvoiceDetail_Click(object sender, EventArgs e)
        {
            try
            {
                int newQuantity = (int)numBookQuantity.Value;
                if (invoiceDetailBUS.AddOrUpdateInvoiceDetail(invoiceId, book_bookId, newQuantity))
                {
                    LoaddgInvoiceDetail();
                    LoadcbBook();
                    LoadPrice();
                    mainForm.LoaddgBook();
                    MessageBox.Show("Thêm sách vào hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm sách vào hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateQuantity(int quantity)
        {
            try
            {
                int newQuantity = (int)numBookQuantity.Value;
                if (invoiceDetailBUS.UpdateInvoiceDetail(invoiceId, book_bookId, newQuantity))
                {
                    LoaddgInvoiceDetail();
                    LoadcbBook();
                    LoadPrice();
                    mainForm.LoaddgBook();
                    MessageBox.Show("Cập nhật sách trong hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Cập nhật sách trong hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditInvoiceDetail_Click(object sender, EventArgs e)
        {
            UpdateQuantity(0);
        }

        private void btnRemoveInvoiceDetail_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + bookName + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                if (invoiceDetailBUS.DeleteInvoiceDetail(invoiceDetailId))
                {
                    LoaddgInvoiceDetail();
                    LoadcbBook();
                    LoadPrice();
                    mainForm.LoaddgBook();
                    MessageBox.Show("Xóa sách khỏi hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa sách khỏi hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            book_bookId = (int)comboBox.SelectedValue;
            bookName = comboBox.Text;
             
        }

        private void dgInvoiceDetail_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId == dgInvoiceDetail.RowCount - 1) rowId = rowId - 1;
            DataGridViewRow row = dgInvoiceDetail.Rows[rowId];

            cbBook.Text = row.Cells[0].Value.ToString();
            numBookQuantity.Value = (int)row.Cells[1].Value;
            invoiceDetailId = (int)dataProvider.exeScaler("SELECT id FROM invoice_detail WHERE invoice_id = " + invoiceId + " AND " + "book_id = " + book_bookId);
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgInvoiceDetail.Rows.Count <= 1)
            {
                MessageBox.Show("Vui lòng chọn sách trước khi in hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult check = MessageBox.Show("Xác nhận thanh toán và in hóa đơn?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    invoiceDetailBUS.UpdateInvoiceStatus(invoiceId, 1);
                    prdInvoice.Document = pdInvoice;
                    prdInvoice.ShowDialog();
                    mainForm.LoaddgInvoice();
                }
            }
        }

        private void pdInvoice_PrintPage(object sender, PrintPageEventArgs e)
        {
            DataTable dt = invoiceDetailBUS.GetInvoiceForPrinting(invoiceId);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow firstRow = dt.Rows[0];
            string userName = firstRow["user_name"].ToString();
            string userPhone = firstRow["user_phone"].ToString();
            DateTime dateCreate = Convert.ToDateTime(firstRow["date_create"]);
            decimal totalPrice = Convert.ToDecimal(firstRow["total_price"]);
            string employeeName = firstRow["employee_name"].ToString();

            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            float fontHeight = font.GetHeight();
            int pageWidth = e.PageBounds.Width;
            int startX = 10;
            int startY = 10;
            int offset = 40;

            // In tiêu đề hóa đơn
            string title = "Hóa đơn bán sách";
            float titleWidth = graphics.MeasureString(title, new Font("Arial", 18, FontStyle.Bold)).Width;
            int titleX = (int)((pageWidth - titleWidth) / 2);
            graphics.DrawString(title, new Font("Arial", 18, FontStyle.Bold), new SolidBrush(Color.Black), titleX, startY);
            offset += (int)fontHeight + 20;

            // In thông tin khách hàng và ngày tháng, căn lề trái
            graphics.DrawString("Tên khách hàng: " + userName, boldFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Số điện thoại: " + userPhone, boldFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Ngày tạo: " + dateCreate.ToString("dd/MM/yyyy"), boldFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Nhân viên xuất hóa đơn: " + employeeName, boldFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)fontHeight + 20;

            // In tiêu đề cột chi tiết hóa đơn, căn giữa
            string columnHeaders = "Tên sách".PadRight(30) + "Số lượng".PadRight(10) + "Đơn giá (VND)".PadRight(15) + "Thành tiền (VND)";
            float columnHeadersWidth = graphics.MeasureString(columnHeaders, boldFont).Width;
            int columnHeadersX = (int)((pageWidth - columnHeadersWidth) / 2);
            graphics.DrawString(columnHeaders, boldFont, new SolidBrush(Color.Black), columnHeadersX, startY + offset);
            offset += (int)fontHeight + 5;
            string separatorLine = new string('-', 80);
            float separatorLineWidth = graphics.MeasureString(separatorLine, font).Width;
            int separatorLineX = (int)((pageWidth - separatorLineWidth) / 2);
            graphics.DrawString(separatorLine, font, new SolidBrush(Color.Black), separatorLineX, startY + offset);
            offset += (int)fontHeight + 5;

            // In các dòng chi tiết hóa đơn, căn giữa
            foreach (DataRow row in dt.Rows)
            {
                string bookName = row["book_name"].ToString();
                int quantity = Convert.ToInt32(row["quantity"]);
                decimal price = Convert.ToDecimal(row["price"]);
                decimal priceItem = Convert.ToDecimal(row["price_item"]);

                string line = bookName.PadRight(30) + quantity.ToString().PadRight(10) + price.ToString("N0").PadRight(15) + priceItem.ToString("N0");
                float lineWidth = graphics.MeasureString(line, font).Width;
                int lineX = (int)((pageWidth - lineWidth) / 2);
                graphics.DrawString(line, font, new SolidBrush(Color.Black), lineX, startY + offset);
                offset += (int)fontHeight + 5;
            }

            // In tổng tiền, căn lề trái
            offset += 20;
            graphics.DrawString("Tổng tiền: " + totalPrice.ToString("N0") + " VND", boldFont, new SolidBrush(Color.Black), startX, startY + offset);
        }

    }
}
