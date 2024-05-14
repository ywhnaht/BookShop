using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class InvoiceDetail : Form
    {
        DataProvider dataProvider = new DataProvider();
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
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT books.book_name as [Tên Sách]");
            query.Append(", invoice_detail.quantity as [Số Lượng]");
            query.Append(", books.price as [Đơn Giá]");
            query.Append(", books.price * invoice_detail.quantity as [Thành Tiền]");
            query.Append(" FROM invoice_detail, books");
            query.Append(" WHERE books.id = invoice_detail.book_id");
            query.Append(" AND invoice_detail.invoice_id = " + this.invoiceId);
            dt = dataProvider.exeQuery(query.ToString());
            dgInvoiceDetail.DataSource = dt;
        }

        private void LoadPrice()
        {
            if ((int)dataProvider.exeScaler("SELECT COUNT(*) FROM invoice_detail WHERE invoice_id = " + invoiceId) > 0)
            {
                int totalPrice = (int)dataProvider.exeScaler("SELECT SUM(invoice_detail.quantity * books.price) FROM invoice_detail, books " +
                    "WHERE invoice_detail.invoice_id = " + this.invoiceId + " AND " + "invoice_detail.book_id = books.id");
                txtTotalPrice.Text = "Tổng Tiền: " + totalPrice.ToString("N0") + " VND";
                dataProvider.exeNonQuery("UPDATE invoice SET total_price = " + totalPrice + " WHERE id = " + this.invoiceId);
            }
            else
            {
                txtTotalPrice.Text = "Tổng Tiền: 0";
            }
        }

        private void LoadcbBook()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.exeQuery("SELECT * FROM books WHERE quantity > 0");
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

        private void ReceiptTitle_Click(object sender, EventArgs e)
        {

        }

        private void dgInvoiceDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int rowId = e.RowIndex;
            //if (rowId < 0) rowId = 0;
            //if (rowId == dgInvoiceDetail.RowCount - 1) rowId = rowId - 1;
            //DataGridViewRow row = dgInvoiceDetail.Rows[rowId];

            //cbBook.Text = row.Cells[0].Value.ToString();
            //numBookQuantity.Value = (int)row.Cells[1].Value;
            //invoiceDetailId = (int)dataProvider.exeScaler("SELECT id FROM invoice_detail WHERE invoice_id = " +  invoiceId + " AND book_id = " + book_bookId);
        }

        private void btnAddInvoiceDetail_Click(object sender, EventArgs e)
        {
            int count = (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM books WHERE id = " + book_bookId);
            int newQuantity = (int)numBookQuantity.Value;
            if (newQuantity <= count)
            {
                int sum = (int)dataProvider.exeScaler("SELECT COUNT(*) FROM invoice_detail WHERE invoice_id = " + invoiceId + " AND " +
                "book_id = " + book_bookId);
                if (sum == 0)
                {
                    StringBuilder query = new StringBuilder("EXEC AddInvoiceDetail ");
                    query.Append(" @book_id = " + book_bookId);
                    query.Append(",@quantity = " + newQuantity);
                    query.Append(",@invoice_id = " + this.invoiceId);

                    int result = dataProvider.exeNonQuery(query.ToString());
                    if (result > 0)
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
                else
                {
                    sum = (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM invoice_detail WHERE invoice_id = " + invoiceId + " AND " +
                    "book_id = " + book_bookId);
                    UpdateQuantity(sum);
                }
            }
            else
            {
                MessageBox.Show("Không đủ số lượng sách này trong cửa hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void UpdateQuantity(int quantity)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateInvoiceDetail ");
            query.Append(" @id = " + invoiceDetailId);
            query.Append(",@book_id = " + book_bookId);
            query.Append(",@quantity = " + (numBookQuantity.Value + quantity));
            query.Append(",@invoice_id = " + invoiceId);

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                //mainForm.UpdateBookQuantity(book_bookId, quantity, 1);
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

        private void btnEditInvoiceDetail_Click(object sender, EventArgs e)
        {
            UpdateQuantity(0);
        }

        private void btnRemoveInvoiceDetail_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + bookName + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                StringBuilder query = new StringBuilder("EXEC DeleteInvoiceDetail ");
                query.Append(" @id = " + invoiceDetailId);
                int result = dataProvider.exeNonQuery(query.ToString());
                if (result > 0)
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
            invoiceDetailId = (int)dataProvider.exeScaler("SELECT id FROM invoice_detail WHERE invoice_id = " + invoiceId + " AND book_id = " + book_bookId);
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Xác nhận thanh toán và in hóa đơn?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                dataProvider.exeNonQuery("UPDATE invoice SET status = 1 WHERE id = " + invoiceId);
                prdInvoice.Document = pdInvoice;
                prdInvoice.ShowDialog();
            }
        }

        private void pdInvoice_PrintPage(object sender, PrintPageEventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT books.book_name");
            query.Append(", invoice_detail.quantity");
            query.Append(", books.price");
            query.Append(", books.price * invoice_detail.quantity as price_item");
            query.Append(", invoice.user_name");
            query.Append(", invoice.user_phone");
            query.Append(", invoice.date_create");
            query.Append(", invoice.total_price");
            query.Append(", users.full_name as employee_name");
            query.Append(" FROM invoice_detail");
            query.Append(" JOIN books ON books.id = invoice_detail.book_id");
            query.Append(" JOIN invoice ON invoice_detail.invoice_id = invoice.id");
            query.Append(" JOIN users ON invoice.user_id = users.id");
            query.Append(" WHERE invoice_detail.invoice_id = " + this.invoiceId);
            dt = dataProvider.exeQuery(query.ToString());

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
