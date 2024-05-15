using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void jFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public int userId { get; private set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPass.Text;

            string query = $"SELECT hashed_password FROM users WHERE user_name = '{username}'";

            DataProvider provider = new DataProvider();
            object result = provider.exeScaler(query);

            if (result != null)
            {
                string hashedPassword = result.ToString();

                if (PasswordEncrypt.VerifyPassword(password, hashedPassword))
                {
                    query = $"SELECT id FROM users WHERE user_name = '{username}'";
                    result = provider.exeScaler(query);

                    userId = Convert.ToInt32(result);

                    MainForm mainForm = new MainForm(userId);
                    mainForm.Show();
                    this.Hide();
                    mainForm.LogOut += MainForm_LogOut;
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }                       
            }
            else
            {
                MessageBox.Show("Tên tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void MainForm_LogOut(object sender, EventArgs e)
        {
            (sender as MainForm).IsCheckOut = false;
            (sender as MainForm).Close();
            this.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void jMaterialTextbox1_Load(object sender, EventArgs e)
        {

        }
    }
}
