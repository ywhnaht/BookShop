using BookShop.BUS;
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
        private Book_BUS bookBUS = new Book_BUS();
        private BookType_BUS bookTypeBUS = new BookType_BUS();
        private Invoice_BUS invoiceBUS = new Invoice_BUS();
        private Receipt_BUS receiptBUS = new Receipt_BUS();
        private Statistic_BUS statisticBUS = new Statistic_BUS();
        private Profile_BUS profileBUS = new Profile_BUS();
        private Invoice_Detail_BUS invoiceDetailBUS = new Invoice_Detail_BUS();
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
            CheckAccess();
        }

        // Xử lý sách

        public void LoaddgBook()
        {
            DataTable dt = bookBUS.GetBooks();
            dgBook.DataSource = dt;
        }
        private void LoadcbBookType()
        {
            DataTable dt = bookBUS.GetBookTypes();
            cbBookType.DisplayMember = "type_name";
            cbBookType.ValueMember = "id";
            cbBookType.DataSource = dt;
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
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                string bookName = txtBook.Text;
                int bookTypeId = book_bookTypeId;
                string authorName = txtAuthor.Text;
                int quantity = (int)numBookQuantity.Value;
                decimal price = numBookPrice.Value;

                if (bookBUS.AddBook(bookName, bookTypeId, authorName, quantity, price))
                {
                    LoaddgBook();
                    MessageBox.Show("Thêm sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            try
            {
                string bookName = txtBook.Text;
                int bookTypeId = book_bookTypeId;
                string authorName = txtAuthor.Text;
                int quantity = (int)numBookQuantity.Value;
                decimal price = numBookPrice.Value;

                if (bookBUS.UpdateBook(book_bookId, bookName, bookTypeId, authorName, quantity, price))
                {
                    LoaddgBook();
                    MessageBox.Show("Cập nhật sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Cập nhật sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveBook_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + txtBook.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                try
                {
                    if (bookBUS.DeleteBook(book_bookId))
                    {
                        LoaddgBook();
                        MessageBox.Show("Xóa sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Xóa sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbBookType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox; 
            book_bookTypeId = (int)comboBox.SelectedValue;
        }

        public bool UpdateBookQuantity(int bookId, int newQuantity, bool increase)
        {
            if (bookBUS.UpdateBookQuantity(bookId, newQuantity, increase))
            {
                LoaddgBook();
                return true;
            }
            else
            {
                return false;
            }
        }


        // Xử lý loại sách

        private void LoaddgBookType()
        {
            DataTable dt = bookTypeBUS.GetBookTypes();
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
        }

        private void btnAddBookType_Click(object sender, EventArgs e)
        {
            try
            {
                string typeName = txtBookType.Text;
                if (bookTypeBUS.AddBookType(typeName))
                {
                    LoaddgBookType();
                    LoadcbBookType();
                    MessageBox.Show("Thêm loại sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm loại sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditBookType_Click(object sender, EventArgs e)
        {
            try
            {
                string typeName = txtBookType.Text;
                if (bookTypeBUS.UpdateBookType(booktype_bookTypeId, typeName))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveBookType_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sách " + txtBookType.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                try
                {
                    if (bookTypeBUS.DeleteBookType(booktype_bookTypeId))
                    {
                        LoaddgBookType();
                        LoadcbBookType();
                        LoaddgBook();
                        MessageBox.Show("Xóa loại sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Xóa loại sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Xử lí hóa đơn

        public void LoaddgInvoice()
        {
            DataTable dt = invoiceBUS.GetInvoices();
            dgInvoice.DataSource = dt;
            if (dt.Rows.Count <= 0)
            {
                btnInvoiceDetail.Visible = false;
            }
            else
            {
                btnInvoiceDetail.Visible = true;
            }
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
            if (invoiceDetailBUS.GetInvoiceStatus(invoice_invoiceId))
            {
                btnEditInvoice.Enabled = false;
                btnRemoveInvoice.Enabled = false;
            }
            else
            {
                btnEditInvoice.Enabled = true;
                btnRemoveInvoice.Enabled = true;
            }
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateCreate = dtDateCreate.Value;
                string userName = txtUserName.Text;
                string userPhone = txtPhoneNum.Text;

                if (invoiceBUS.AddInvoice(dateCreate, currentUserId, userName, userPhone))
                {
                    LoaddgInvoice();
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateCreate = dtDateCreate.Value;
                string userName = txtUserName.Text;
                string userPhone = txtPhoneNum.Text;

                if (invoiceBUS.UpdateInvoice(invoice_invoiceId, dateCreate, currentUserId, userName, userPhone))
                {
                    LoaddgInvoice();
                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveInvoice_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn có mã " + invoice_invoiceId + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                try
                {
                    if (invoiceBUS.DeleteInvoice(invoice_invoiceId))
                    {
                        LoaddgInvoice();
                        MessageBox.Show("Xóa hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Xử lí phiếu nhập
        private void LoaddgReceipt()
        {
            DataTable dt = receiptBUS.GetReceipts();
            dgReceipt.DataSource = dt;
            if (dt.Rows.Count <= 0)
            {
                btnReceiptDetail.Visible = false;
            }
            else
            {
                btnReceiptDetail.Visible = true;
            }
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
            try
            {
                DateTime dateCreate = dtReceiptDateCr.Value;
                string supplierName = txtSupplier.Text;

                if (receiptBUS.AddReceipt(dateCreate, supplierName))
                {
                    LoaddgReceipt();
                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateCreate = dtReceiptDateCr.Value;
                string supplierName = txtSupplier.Text;

                if (receiptBUS.UpdateReceipt(receipt_receiptId, dateCreate, supplierName))
                {
                    LoaddgReceipt();
                    MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Cập nhật phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveReceipt_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập có mã " + receipt_receiptId + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                try
                {
                    if (receiptBUS.DeleteReceipt(receipt_receiptId))
                    {
                        LoaddgReceipt();
                        MessageBox.Show("Xóa phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Thống Kê
        private void LoaddtDate()
        {
            dtDateFrom.Value = DateTime.Now.AddDays(-7);
            dtDateEnd. Value = DateTime.Now;
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
                dt = statisticBUS.GetOverallRevenue(dateFrom, dateEnd);
            }
            else if (rbtBook.Checked)
            {
                dt = statisticBUS.GetRevenueByBook(id_bookId, dateFrom, dateEnd);
            }
            else if (rbtBookType.Checked)
            {
                dt = statisticBUS.GetRevenueByBookType(id_bookTypeId, dateFrom, dateEnd);
            }
            else
            {
                dt = statisticBUS.GetRevenueByUser(id_userId, dateFrom, dateEnd);
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
                lbTotalPrice.Text = totalRevenue != 0 ? "Tổng tiền: " + totalRevenue.ToString("N0") + " VND" : "Tổng tiền: 0 VND";
            }
            else
            {
                lbTotalPrice.Text = "Tổng tiền: 0 VND";
            }
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
                bool check = profileBUS.UpdateProfileAvatar(currentUserId);

                if (check)
                {
                    LoadUserProfile();
                    MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Cập nhật ảnh đại diện không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            profileBUS.UpdateUserProfile(currentUserId, txtNameEmployee.Text, txtAccountName.Text, txtPassword.Text, txtPhoneEmployee.Text, txtAddrEmployee.Text, getUserTypeId(currentUserId));
        }

        // Phân Quyền
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage tabPage = e.TabPage;
            bool hasAccess = true;
            if (tabPage == tpBook && !userAuthorize.HasRole("Quản Lý Sách"))
            {
                hasAccess = false;
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; 
            }
            else if (tabPage == tpBookType && !userAuthorize.HasRole("Quản Lý Loại Sách"))
            {
                hasAccess = false;
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (tabPage == tpInvoice && !userAuthorize.HasRole("Quản Lý Hóa Đơn"))
            {
                hasAccess = false;
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (tabPage == tpReceipt && !userAuthorize.HasRole("Quản Lý Phiếu Nhập"))
            {
                hasAccess = false;
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (tabPage == tpRevenue && !userAuthorize.HasRole("Quản Lý Doanh Thu"))
            {
                hasAccess = false;
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (tabPage == tpEmployee && !userAuthorize.HasRole("Quản Lý Nhân Viên"))
            {
                hasAccess = false;
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            if (!hasAccess)
            {
                //MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //e.Cancel = true;
                tabPage.Parent = null; // Ẩn TabPage nếu không có quyền truy cập
            }
            else
            {
                tabPage.Parent = tabControl1; // Hiển thị TabPage nếu có quyền truy cập
            }
        }
        private void CheckAccess()
        {
            bool hasBookAccess = userAuthorize.HasRole("Quản Lý Sách");
            bool hasBookTypeAccess = userAuthorize.HasRole("Quản Lý Loại Sách");
            bool hasInvoiceAccess = userAuthorize.HasRole("Quản Lý Hóa Đơn");
            bool hasReceiptAccess = userAuthorize.HasRole("Quản Lý Phiếu Nhập");
            bool hasRevenueAccess = userAuthorize.HasRole("Quản Lý Doanh Thu");
            bool hasEmployeeAccess = userAuthorize.HasRole("Quản Lý Nhân Viên");

            tpBook.Parent = hasBookAccess ? tabControl1 : null;
            tpBookType.Parent = hasBookTypeAccess ? tabControl1 : null;
            tpInvoice.Parent = hasInvoiceAccess ? tabControl1 : null;
            tpReceipt.Parent = hasReceiptAccess ? tabControl1 : null;
            tpRevenue.Parent = hasRevenueAccess ? tabControl1 : null;
            tpEmployee.Parent = hasEmployeeAccess ? tabControl1 : null;
        }
    }
}
