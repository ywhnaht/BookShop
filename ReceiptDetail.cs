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
    public partial class ReceiptDetail : Form
    {
        DataProvider dataProvider = new DataProvider();
        private MainForm mainForm;
        private int receiptDetailId;
        private int receiptId;
        private int book_bookId;
        private string bookName;
        public ReceiptDetail(int receiptId, MainForm mainForm)
        {
            InitializeComponent();
            this.receiptId = receiptId;
            this.mainForm = mainForm;
            Init();
            ReceiptTitle.Text = "Chi Tiết Phiếu Nhập " + this.receiptId;
        }

        private void Init()
        {
            LoaddgReceiptDetail();
            LoadcbBook();
            LoadPrice();
        }

        private void LoaddgReceiptDetail()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT books.book_name as [Tên Sách]");
            query.Append(", receipt_detail.quantity as [Số Lượng]");
            query.Append(", books.price as [Giá Nhập]");
            query.Append(", books.price * receipt_detail.quantity as [Thành Tiền]");
            query.Append(" FROM receipt_detail, books");
            query.Append(" WHERE books.id = receipt_detail.book_id");
            query.Append(" AND receipt_detail.receipt_id = " + this.receiptId);
            dt = dataProvider.exeQuery(query.ToString());
            dgReceiptDetail.DataSource = dt;
        }

        private void LoadPrice()
        {
            if ((int)dataProvider.exeScaler("SELECT COUNT(*) FROM receipt_detail WHERE receipt_id = " + receiptId) > 0)
            {
                int totalPrice = (int)dataProvider.exeScaler("SELECT SUM(receipt_detail.quantity * books.price) FROM receipt_detail, books " +
                    "WHERE receipt_id = " + this.receiptId + " AND books.id = receipt_detail.book_id");
                txtTotalPrice.Text = "Tổng Tiền: " + totalPrice.ToString("N0") + " VND";
            }
            else
            {
                txtTotalPrice.Text = "Tổng Tiền: 0";
            }
        }
        private void LoadcbBook()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.exeQuery("SELECT * FROM books");
            cbBook.DisplayMember = "book_name";
            cbBook.ValueMember = "id";
            cbBook.DataSource = dt;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            book_bookId = (int)comboBox.SelectedValue;
            bookName = comboBox.Text;
        }

        private void btnAddReceiptDetail_Click(object sender, EventArgs e)
        {
            int count = (int)dataProvider.exeScaler("SELECT COUNT(*) FROM receipt_detail WHERE receipt_id = " + receiptId + " AND " +
                "book_id = " + book_bookId);
            if (count == 0)
            {
                StringBuilder query = new StringBuilder("EXEC AddReceiptDetail ");
                query.Append(" @receipt_id = " + this.receiptId);
                query.Append(",@book_id = " + book_bookId);
                query.Append(",@quantity = " + numBookQuantity.Value);
                int newQuantity = (int)numBookQuantity.Value;
                int result = dataProvider.exeNonQuery(query.ToString());
                if (result > 0)
                {
                    mainForm.UpdateBookQuantity(book_bookId, newQuantity, 1);
                    LoaddgReceiptDetail();
                    LoadcbBook();
                    LoadPrice();
                    MessageBox.Show("Thêm sách vào phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm sách vào phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                count = (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM receipt_detail WHERE receipt_id = " + receiptId + " AND " +
                "book_id = " + book_bookId);
                UpdateQuantity(count);
            }
        }

        private void UpdateQuantity(int quantity)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateReceiptDetail ");
            query.Append(" @receipt_detail_id = " + receiptDetailId);
            query.Append(",@receipt_id = " + receiptId);
            query.Append(",@book_id = " + book_bookId);
            query.Append(",@quantity = " + (numBookQuantity.Value + quantity));

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                //mainForm.UpdateBookQuantity(book_bookId, quantity, 1);
                LoaddgReceiptDetail();
                LoadcbBook();
                LoadPrice();
                MessageBox.Show("Cập nhật sách trong phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật sách trong phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveReceiptDetail_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + bookName + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                int quantity = (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM receipt_detail WHERE id = " + receiptDetailId + " AND " +
                    "book_id = " + book_bookId + " AND receipt_id = " + receiptId);
                StringBuilder query = new StringBuilder("DELETE FROM receipt_detail WHERE id = " + receiptDetailId + " AND " +
                    "book_id = " + book_bookId);
                int result = dataProvider.exeNonQuery(query.ToString());
                if (result > 0)
                {
                    mainForm.UpdateBookQuantity(book_bookId, quantity, 2);
                    LoaddgReceiptDetail();
                    LoadcbBook();
                    LoadPrice();
                    MessageBox.Show("Xóa sách khỏi phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa sách khỏi phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnEditReceiptDetail_Click(object sender, EventArgs e)
        {
            UpdateQuantity(0);
        }

        private void dgReceiptDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId == dgReceiptDetail.RowCount - 1) rowId = rowId - 1;
            DataGridViewRow row = dgReceiptDetail.Rows[rowId];

            cbBook.Text = row.Cells[0].Value.ToString();
            numBookQuantity.Value = (int)row.Cells[1].Value;
            receiptDetailId = (int)dataProvider.exeScaler("SELECT id FROM receipt_detail WHERE receipt_id = " + receiptId + " AND book_id = " + book_bookId);
        }
    }
}
