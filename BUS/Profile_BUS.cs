using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.BUS
{
    public class Profile_BUS
    {
        private Profile_DAO profileDAO = new Profile_DAO();
        public bool UpdateProfileAvatar(int userId)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };
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

                try
                {
                    // Sử dụng FileStream để sao chép file
                    using (FileStream sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (FileStream destStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                        {
                            sourceStream.CopyTo(destStream);
                        }
                    }

                    return profileDAO.UpdateProfileAvatar(userId, destPath);
                }
                catch (IOException ioEx)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật ảnh đại diện: " + ioEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

        public bool UpdateUserProfile(int userId, string fullName, string userName, string password, string phoneNumber, string address, int userTypeId)
        {
            return profileDAO.UpdateUserProfile(userId, fullName, userName, password, phoneNumber, address, userTypeId);
        }
    }
}
