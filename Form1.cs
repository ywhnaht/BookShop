﻿using System;
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
    public partial class MainForm : Form
    {
        public bool IsCheckOut = true;
        private int currentUerId;

        public DataProvider dataProvider = new DataProvider();
        private int book_bookTypeId;
        private int book_bookId;
        private int booktype_bookTypeId;
        private int invoice_invoiceId;
        private int receipt_receiptId;
        public MainForm(int userId)
        {
            InitializeComponent();
            Init();
            currentUerId = userId;
        }

        public event EventHandler LogOut;

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogOut(this, new EventArgs());
        }

        private void Init()
        {
            LoaddgBook();
            LoaddgBookType();
            LoaddgInvoice();
            LoaddgReceipt();
        }

        // Xử lý sách

        private void LoaddgBook()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT books.id as [Mã Sách]");
            query.Append(", book_name as [Tên Sách]");
            query.Append(", type_name as [Loại Sách]");
            query.Append(", author_name as [Tác Giả]");
            query.Append(", quantity as [Số Lượng]");
            query.Append(", price as [Giá Bán]");
            query.Append(" FROM books, book_type");
            query.Append(" WHERE books.book_type_id = book_type.id");
            dt = dataProvider.exeQuery(query.ToString()); 
            dgBook.DataSource = dt;
        }

        private void LoadcbBookType()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.exeQuery("SELECT * FROM book_type");
            cbBookType.DisplayMember = "type_name";
            cbBookType.ValueMember = "id";
            cbBookType.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId == dgBook.RowCount - 1) rowId = rowId - 1;
            DataGridViewRow row = dgBook.Rows[rowId];

            book_bookId = (int)row.Cells[0].Value;
            txtBook.Text = row.Cells[1].Value.ToString();
            cbBookType.Text = row.Cells[2].Value.ToString();
            txtAuthor.Text = row.Cells[3].Value.ToString();
            numBookQuantity.Value = (int)row.Cells[4].Value;
            numBookPrice.Value = (int)row.Cells[5].Value;

            book_bookTypeId = (int)dataProvider.exeScaler("SELECT id FROM book_type WHERE type_name = N'" + cbBookType.Text + "'");
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC AddBook ");
            query.Append(" @book_name = N'" + txtBook.Text + "'");
            query.Append(",@book_type_id = " + book_bookTypeId);
            query.Append(",@author_name = N'" + txtAuthor.Text + "'");
            query.Append(",@quantity = " + numBookQuantity.Value);
            query.Append(",@price = " + numBookPrice.Value);

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgBook();
                MessageBox.Show("Thêm sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateBook ");
            query.Append(" @book_id = " + book_bookId);
            query.Append(",@book_name = N'" + txtBook.Text + "'");
            query.Append(",@book_type_id = " + book_bookTypeId);
            query.Append(",@author_name = N'" + txtAuthor.Text + "'");
            query.Append(",@quantity = " + numBookQuantity.Value);
            query.Append(",@price = " + numBookPrice.Value);

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgBook();
                MessageBox.Show("Cập nhật sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveBook_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + txtBook.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                StringBuilder query = new StringBuilder("EXEC DeleteBook @book_id = " + book_bookId);
                int result = dataProvider.exeNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgBook();
                    MessageBox.Show("Xóa sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void cbBookType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox; 
            book_bookTypeId = (int)comboBox.SelectedValue;
        }

        // Xử lý loại sách

        private void LoaddgBookType()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT id as [Mã Loại Sách]");
            query.Append(", type_name as [Loại Sách]");
            query.Append("FROM book_type");
            dt = dataProvider.exeQuery(query.ToString());
            dgBookType.DataSource = dt;
        }

        private void dgBookType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId == dgBookType.RowCount - 1) rowId = rowId - 1;
            DataGridViewRow row = dgBookType.Rows[rowId];

            booktype_bookTypeId = (int)row.Cells[0].Value;
            txtBookType.Text = row.Cells[1].Value.ToString();
            //booktype_bookTypeId = (int)dataProvider.exeScaler("SELECT id FROM book_type WHERE type_name = N'" + cbBookType.Text + "'");
        }

        private void btnAddBookType_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC AddBookType ");
            query.Append(" @type_name = N'" + txtBookType.Text + "'");

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgBookType();
                LoadcbBookType();
                MessageBox.Show("Thêm  loại sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm loại sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEditBookType_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateBookType ");
            query.Append(" @type_id = " + booktype_bookTypeId);
            query.Append(",@type_name = N'" + txtBookType.Text + "'");

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgBookType();
                LoadcbBookType();
                MessageBox.Show("Cập nhật loại sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật loại sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveBookType_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sách " + txtBookType.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                StringBuilder query = new StringBuilder("EXEC DeleteBookType @type_id = " + booktype_bookTypeId);
                int result = dataProvider.exeNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgBookType();
                    LoadcbBookType();
                    MessageBox.Show("Xóa loại sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa loại sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        //Xử lí hóa đơn

        private void LoaddgInvoice()
        {
            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT id as [Mã Hóa Đơn]");
            query.Append(", date_create as [Ngày Tạo]");
            query.Append(", user_name as [Tên Khách Hàng]");
            query.Append(", user_phone as [Số Điện Thoại]");
            query.Append(" FROM invoice");

            dt = dataProvider.exeQuery(query.ToString());

            dgInvoice.DataSource = dt;
        }
        private void dgInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId == dgInvoice.RowCount - 1) rowId = rowId - 1;
            DataGridViewRow row = dgInvoice.Rows[rowId];

            invoice_invoiceId = (int)row.Cells[0].Value;
            dtDateCreate.Value = (DateTime)row.Cells[1].Value;
            txtUserName.Text = row.Cells[2].Value.ToString();
            txtPhoneNum.Text = row.Cells[3].Value.ToString();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC AddInvoice ");
            query.Append("@date_create = '" + dtDateCreate.Value.ToString("yyyy-MM-dd") + "'");
            query.Append(", @user_id = " + currentUerId); 
            query.Append(", @user_name = N'" + txtUserName.Text + "'");
            query.Append(", @user_phone = '" + txtPhoneNum.Text + "'");

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgBookType();
                LoadcbBookType();
                LoaddgInvoice();
                MessageBox.Show("Thêm  hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateInvoice ");
            query.Append(" @invoice_id = " + invoice_invoiceId);
            query.Append(", @date_create = '" + dtDateCreate.Value.ToString("yyyy-MM-dd") + "'");
            query.Append(", @user_id = " + currentUerId);
            query.Append(", @user_name = N'" + txtUserName.Text + "'");
            query.Append(", @user_phone = '" + txtPhoneNum.Text + "'");

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgBookType();
                LoadcbBookType();
                LoaddgInvoice();
                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveInvoice_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn có mã " + invoice_invoiceId + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                StringBuilder query = new StringBuilder("EXEC DeleteInvoice @invoice_id = " + invoice_invoiceId);
                int result = dataProvider.exeNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgBookType();
                    LoadcbBookType();
                    LoaddgInvoice();
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }


        //Xử lí phiếu nhập
        private void LoaddgReceipt()
        {
            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT id as [Mã Phiếu Nhập]");
            query.Append(", date_create as [Ngày Tạo]");
            query.Append(", supplier_name as [Nhà Xuất Bản]");
            query.Append(" FROM receipt");

            dt = dataProvider.exeQuery(query.ToString());

            dgReceipt.DataSource = dt;
        }

        private void dgReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId == dgReceipt.RowCount - 1) rowId = rowId - 1;
            DataGridViewRow row = dgReceipt.Rows[rowId];

            receipt_receiptId = (int)row.Cells[0].Value;
            dtReceiptDateCr.Value = (DateTime)row.Cells[1].Value;
            txtSupplier.Text = row.Cells[2].Value.ToString();
        }

        private void btnAddReceipt_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC AddReceipt ");
            query.Append("@date_create = '" + dtReceiptDateCr.Value.ToString("yyyy-MM-dd") + "'");
            query.Append(", @supplier_name = N'" + txtSupplier.Text + "'");

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgBookType();
                LoadcbBookType();
                LoaddgInvoice();
                LoaddgReceipt();
                MessageBox.Show("Thêm phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEditReceipt_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateReceipt ");
            query.Append(" @receipt_id = " + receipt_receiptId);
            query.Append(", @date_create = '" + dtReceiptDateCr.Value.ToString("yyyy-MM-dd") + "'");
            query.Append(", @supplier_name = N'" + txtSupplier.Text + "'");

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgBookType();
                LoadcbBookType();
                LoaddgInvoice();
                LoaddgReceipt();
                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveReceipt_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập có mã " + receipt_receiptId + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                StringBuilder query = new StringBuilder("EXEC DeleteReceipt @receipt_id = " + receipt_receiptId);
                int result = dataProvider.exeNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgBookType();
                    LoadcbBookType();
                    LoaddgInvoice();
                    LoaddgReceipt();
                    MessageBox.Show("Xóa phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
