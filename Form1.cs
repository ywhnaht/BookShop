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
    public partial class Form1 : Form
    {
        public DataProvider dataProvider = new DataProvider();
        private int bookTypeId;
        private int bookId;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitBook();
        }

        // Xử lý sách
        private void InitBook()
        {
            LoaddgBook();
            LoadcbBookType();
        }

        private void LoaddgBook()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT books.id as [Mã sách]");
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

            bookId = (int)row.Cells[0].Value;
            txtBook.Text = row.Cells[1].Value.ToString();
            cbBookType.Text = row.Cells[2].Value.ToString();
            txtAuthor.Text = row.Cells[3].Value.ToString();
            numBookQuantity.Value = (int)row.Cells[4].Value;
            numBookPrice.Value = (int)row.Cells[5].Value;

            bookTypeId = (int)dataProvider.exeScaler("SELECT id FROM book_type WHERE type_name = N'" + cbBookType.Text + "'");
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC AddBook ");
            query.Append(" @book_name = N'" + txtBook.Text + "'");
            query.Append(",@book_type_id = " + bookTypeId);
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
            query.Append(" @book_id = " + bookId);
            query.Append(",@book_name = N'" + txtBook.Text + "'");
            query.Append(",@book_type_id = " + bookTypeId);
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
                StringBuilder query = new StringBuilder("EXEC DeleteBook @book_id = " + bookId);
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
            bookTypeId = (int)comboBox.SelectedValue;
        }

        // Xử lý loại sách
    }
}
