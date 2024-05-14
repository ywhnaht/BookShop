using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BookShop
{
    public partial class MainForm : Form
    {
        public bool IsCheckOut = true;
        private int currentUserId;
        private Authorize userAuthorize;
        public DataProvider dataProvider = new DataProvider();
        private int book_bookTypeId;
        private int book_bookId;
        private int booktype_bookTypeId;
        private int invoice_invoiceId;
        private int receipt_receiptId;
        private int id_bookId;
        private int id_bookTypeId;
        private int id_userId;
        private int user_userId;
        private string dateFrom, dateEnd;
        public MainForm(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
            userAuthorize = new Authorize(userId);
            Init();
        }



        public event EventHandler LogOut;

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogOut(this, new EventArgs());
        }

        private void Init()
        {
            LoaddgBook();
            LoadcbBookType();
            LoaddgBookType();
            LoaddgInvoice();
            LoaddgReceipt();
            LoaddtDate();
            LoaddgEmployee();
            LoadUserProfile();
        }

        // Xử lý sách

        public void LoaddgBook()
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

        public void UpdateBookQuantity(int bookId, int newQuantity, int choose)
        {
            StringBuilder query = new StringBuilder();
            if (choose == 1)
            {
                int count = (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM books WHERE id = " + bookId);
                query = new StringBuilder("UPDATE books SET quantity = " + (count + newQuantity) + " WHERE id = " + bookId);
            }
            else
            {
                int count = (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM books WHERE id = " + bookId);
                query = new StringBuilder("UPDATE books SET quantity = " + (count - newQuantity) + " WHERE id = " + bookId);
            }
            dataProvider.exeNonQuery(query.ToString());
            LoaddgBook();
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
                LoaddgBook();
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
            query.Append(", @user_id = " + currentUserId); 
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
            query.Append(", @user_id = " + currentUserId);
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

        private void btnReceiptDetail_Click(object sender, EventArgs e)
        {
            ReceiptDetail receiptDetail = new ReceiptDetail(receipt_receiptId, this);
            receiptDetail.ShowDialog();
        }

        private void btnInvoiceDetail_Click(object sender, EventArgs e)
        {
            InvoiceDetail invoiceDetail = new InvoiceDetail(invoice_invoiceId, this);
            invoiceDetail.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void LoaddtDate()
        {
            dtDateFrom.Value = DateTime.Now.AddDays(-7);
            dtDateEnd. Value = DateTime.Now;
        }

        private void rbtBookType_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbtEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAll.Checked)
            {
                cbItem.Enabled = false;
                cbItem.Text = string.Empty;
                cbItem.SelectedItem = -1;
            }
            else
            {
                DataTable dt = new DataTable();
                cbItem.Enabled = true;
                if (rbtBook.Checked)
                {
                    dt = dataProvider.exeQuery("SELECT * FROM books");
                    cbItem.DisplayMember = "book_name";
                    cbItem.ValueMember = "id";
                }
                else if (rbtBookType.Checked)
                {
                    dt = dataProvider.exeQuery("SELECT * FROM book_type");
                    cbItem.DisplayMember = "type_name";
                    cbItem.ValueMember = "id";
                }
                else
                {
                    dt = dataProvider.exeQuery("SELECT * FROM users WHERE user_type_id = 1");
                    cbItem.DisplayMember = "full_name";
                    cbItem.ValueMember = "id";
                }
                cbItem.DataSource = dt;
            }
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (rbtAll.Checked)
            {
                dt = dataProvider.exeQuery("EXEC OverallRevenue @date_from = '" + dateFrom + "', @date_end = '" + dateEnd + "'");
            }
            else if (rbtBook.Checked)
            {
                dt = dataProvider.exeQuery("EXEC RevenueByBook @book_id = " + id_bookId + "" +
                    ", @date_from = '" + dateFrom + "', @date_end = '" + dateEnd + "'");
            }
            else if (rbtBookType.Checked)
            {
                dt = dataProvider.exeQuery("EXEC RevenueByBookType @book_type_id = " + id_bookTypeId + "" +
                   ", @date_from = '" + dateFrom + "', @date_end = '" + dateEnd + "'");
            }
            else
            {
                dt = dataProvider.exeQuery("EXEC RevenueByUser @user_id = " + id_userId + "" +
                   ", @date_from = '" + dateFrom + "', @date_end = '" + dateEnd + "'");
            }
            dgRevenue.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                decimal totalRevenue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Thành Tiền"] != DBNull.Value)
                    {
                        totalRevenue += Convert.ToDecimal(row["Thành Tiền"]);
                    }
                }
                if (totalRevenue != 0)
                {
                    lbTotalPrice.Text = "Tổng tiền: " + totalRevenue.ToString("N0") + " VND";
                }
                else
                {
                    lbTotalPrice.Text = "Tổng tiền: 0 VND";
                }
            }
            else
            {
                lbTotalPrice.Text = "Tổng tiền: 0 VND";
            }
        }
        

        private void txtTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void dtDateFrom_ValueChanged(object sender, EventArgs e)
        {
            this.dateFrom = dtDateFrom.Value.ToString("yyyy-MM-dd");
        }

        private void dtDateEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dateEnd = dtDateEnd.Value.ToString("yyyy-MM-dd");
        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (sender as ComboBox);
            if (rbtBook.Checked)
            {
                id_bookId = (int)comboBox.SelectedValue;
            }
            else if (rbtBookType.Checked) {
                id_bookTypeId = (int)comboBox.SelectedValue;
            }
            else if (rbtEmployee.Checked)
            {
                id_userId = (int)comboBox.SelectedValue;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


        // Quản lí nhân viên
        private void dgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) rowId = 0;
            if (rowId == dgEmployee.RowCount - 1) rowId = rowId - 1;
            DataGridViewRow row = dgEmployee.Rows[rowId];

            user_userId = (int)row.Cells[0].Value;
            txtEmployeeName.Text = row.Cells[1].Value.ToString();
            txtEmployeePhone.Text = row.Cells[2].Value.ToString();
            txtEmployeeAddr.Text = row.Cells[3].Value.ToString();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC AddUser ");
            query.Append("@full_name = N'" + txtEmployeeName.Text + "'");
            query.Append(", @phone = '" + txtEmployeePhone.Text + "'");
            query.Append(", @address = N'" + txtEmployeeAddr.Text + "'");

            DataTable dt = dataProvider.exeQuery(query.ToString());

            if (dt.Rows.Count > 0)
            {
                string userName = dt.Rows[0]["UserName"].ToString();
                string password = dt.Rows[0]["Password"].ToString();

                string hashed_pass = PasswordEncrypt.HashPassword(password);
                dataProvider.exeNonQuery("UPDATE users SET hashed_password = '" + hashed_pass + "' WHERE user_name = '" + userName + "'");

                LoaddgEmployee();
                MessageBox.Show("Thêm nhân viên thành công!\nTài khoản: " + userName + "\nMật khẩu: " + password, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm nhân viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public int getUserTypeId(int userId)
        {
            int userTypeId;
            string query = "SELECT user_type_id FROM users WHERE id = " + userId;

            DataTable dt = dataProvider.exeQuery(query);

            if (dt.Rows.Count > 0)
            {
                userTypeId = Convert.ToInt32(dt.Rows[0]["user_type_id"]);
                return userTypeId;
            }
            return -1;
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            int userTypeId = getUserTypeId(currentUserId);
            StringBuilder query = new StringBuilder("EXEC UpdateUser ");
            query.Append(" @id = " + user_userId);
            query.Append(", @full_name = N'" + txtEmployeeName.Text + "'");
            query.Append(", @phone = '" + txtEmployeePhone.Text + "'");
            query.Append(", @address = N'" + txtEmployeeAddr.Text + "'");
            query.Append(", @user_type_id = " + userTypeId);

            int result = dataProvider.exeNonQuery(query.ToString());
            if (result > 0)
            {
                LoaddgEmployee();
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin nhân viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn nhân viên " + txtEmployeeName.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                StringBuilder query = new StringBuilder("EXEC DeleteUser @id = " + user_userId);
                int result = dataProvider.exeNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgEmployee();
                    MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        
        private void LoaddgEmployee()
        {
            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT id as [Mã Nhân Viên]");
            query.Append(", full_name as [Tên Nhân Viên]");
            query.Append(", phone_number as [Sđt Nhân Viên]");
            query.Append(", address as [Địa Chỉ]");
            query.Append(" FROM users");
            query.Append(" WHERE user_type_id = 1");

            dt = dataProvider.exeQuery(query.ToString());

            dgEmployee.DataSource = dt;
        }

        // Quản lí tài khoản

        private void LoadUserProfile()
        {
            DataTable dt = dataProvider.exeQuery("EXEC GetUser @user_id = " + currentUserId);
            if (dt.Rows.Count > 0)
            {
                txtAccountName.Text = dt.Rows[0]["user_name"].ToString();
                txtPassword.Text = dt.Rows[0]["password"].ToString();
                txtNameEmployee.Text = dt.Rows[0]["full_name"].ToString();
                txtPhoneEmployee.Text = dt.Rows[0]["phone_number"].ToString();
                txtAddrEmployee.Text = dt.Rows[0]["address"].ToString();
                string profilePicturePath = dt.Rows[0]["profile_picture"].ToString();
                if (File.Exists(profilePicturePath))
                {
                    pbAvatar.Image = Image.FromFile(profilePicturePath);
                }
                else
                {
                    pbAvatar.Image = Properties.Resources.avatar_trang_4;
                }
            }
        }

        private void btnUpdateAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                string destDir = Path.Combine(Application.StartupPath, "ProfilePictures");
                string destPath = Path.Combine(destDir, fileName);

                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                // Copy file to the destination path
                File.Copy(filePath, destPath, true);

                // Update profile picture path in the database
                StringBuilder query = new StringBuilder("EXEC UpdateUserProfilePicture ");
                query.Append("@user_id = " + currentUserId + ", ");
                query.Append("@profile_picture = N'" + destPath.Replace("'", "''") + "'");

                int result = dataProvider.exeNonQuery(query.ToString());

                if (result > 0)
                {
                    LoadUserProfile();
                    MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Cập nhật ảnh đại diện không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if (txtNameEmployee.Text == string.Empty || txtAccountName.Text == string.Empty || txtPassword.Text == string.Empty || txtPhoneEmployee.Text == string.Empty || txtAddrEmployee.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                int count = (int)dataProvider.exeScaler("SELECT COUNT(*) FROM users WHERE user_name = '" + txtAccountName.Text + "' AND " +
                    "id != " + currentUserId);
                if (count > 0)
                {
                    MessageBox.Show("Tên Tài Khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string pass = txtPassword.Text;
                    StringBuilder query = new StringBuilder("EXEC UpdateUser ");
                    query.Append(" @id = " + currentUserId);
                    query.Append(", @full_name = N'" + txtNameEmployee.Text + "'");
                    query.Append(", @phone = '" + txtPhoneEmployee.Text + "'");
                    query.Append(", @address = N'" + txtAddrEmployee.Text + "'");
                    query.Append(", @user_name = N'" + txtAccountName.Text + "'");
                    query.Append(", @password = N'" + pass + "'");
                    query.Append(", @user_type_id = " + getUserTypeId(currentUserId));

                    int result = dataProvider.exeNonQuery(query.ToString());
                    if (result > 0)
                    {
                        string hashed_pass = PasswordEncrypt.HashPassword(pass);
                        dataProvider.exeNonQuery("UPDATE users SET hashed_password = '" + hashed_pass + "' WHERE id = '" + currentUserId + "'");

                        LoadUserProfile();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

        // Phân Quyền
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage tabPage = e.TabPage;
            if (tabPage == tpBook && !userAuthorize.HasRole("Quản Lý Sách"))
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; 
            }
            else if (tabPage == tpBookType && !userAuthorize.HasRole("Quản Lý Loại Sách"))
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (tabPage == tpInvoice && !userAuthorize.HasRole("Quản Lý Hóa Đơn"))
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (tabPage == tpReceipt && !userAuthorize.HasRole("Quản Lý Phiếu Nhập"))
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (tabPage == tpRevenue && !userAuthorize.HasRole("Quản Lý Doanh Thu"))
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (tabPage == tpEmployee && !userAuthorize.HasRole("Quản Lý Nhân Viên"))
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

    }
}
