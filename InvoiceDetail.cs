using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                txtTotalPrice.Text = "Tổng Tiền: " + totalPrice;
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
    }
}
