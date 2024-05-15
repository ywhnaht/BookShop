using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.DAO
{
    public class Profile_DAO : DataProvider
    {
        public bool UpdateProfileAvatar(int userId, string destPath)
        {
            // Update profile picture path in the database
            StringBuilder query = new StringBuilder("EXEC UpdateUserProfilePicture ");
            query.Append("@user_id = " + userId + ", ");
            query.Append("@profile_picture = N'" + destPath.Replace("'", "''") + "'");

            int result = exeNonQuery(query.ToString());

            return result > 0;
        }

        public bool UpdateUserProfile(int userId, string fullName, string userName, string password, string phoneNumber, string address, int userTypeId)
        {
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int count = (int)exeScaler("SELECT COUNT(*) FROM users WHERE user_name = N'" + userName.Replace("'", "''") + "' AND id != " + userId);
            if (count > 0)
            {
                MessageBox.Show("Tên Tài Khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            StringBuilder query = new StringBuilder("EXEC UpdateUser ");
            query.Append(" @id = " + userId);
            query.Append(", @full_name = N'" + fullName + "'");
            query.Append(", @phone = '" + phoneNumber + "'");
            query.Append(", @address = N'" + address + "'");
            query.Append(", @user_name = N'" + userName + "'");
            query.Append(", @password = N'" + password + "'");
            query.Append(", @user_type_id = " + userTypeId);

            int result = exeNonQuery(query.ToString());
            if (result > 0)
            {
                string hashed_pass = PasswordEncrypt.HashPassword(password);
                exeNonQuery("UPDATE users SET hashed_password = '" + hashed_pass.Replace("'", "''") + "' WHERE id = " + userId);

                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return true;
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }
    }
}
