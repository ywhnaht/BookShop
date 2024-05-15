using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAO
{
    public class Employee_DAO
    {
        private DataProvider dataProvider = new DataProvider();

        public DataTable GetEmployees()
        {
            StringBuilder query = new StringBuilder("SELECT id as [Mã Nhân Viên], full_name as [Tên Nhân Viên], phone_number as [Sđt Nhân Viên], address as [Địa Chỉ] FROM users WHERE user_type_id = 1");
            return dataProvider.exeQuery(query.ToString());
        }

        public DataTable AddEmployee(string fullName, string phone, string address)
        {
            StringBuilder query = new StringBuilder("EXEC AddUser ");
            query.Append("@full_name = N'" + fullName + "', ");
            query.Append("@phone = '" + phone + "', ");
            query.Append("@address = N'" + address + "'");
            return dataProvider.exeQuery(query.ToString());
        }

        public int UpdateEmployee(int userId, string fullName, string phone, string address, int userTypeId)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateUser ");
            query.Append("@id = " + userId + ", ");
            query.Append("@full_name = N'" + fullName + "', ");
            query.Append("@phone = '" + phone + "', ");
            query.Append("@address = N'" + address + "', ");
            query.Append("@user_type_id = " + userTypeId);
            return dataProvider.exeNonQuery(query.ToString());
        }
        public int DeleteEmployee(int userId)
        {
            StringBuilder query = new StringBuilder("EXEC DeleteUser @id = " + userId);
            return dataProvider.exeNonQuery(query.ToString());
        }

        public int GetUserTypeId(int userId)
        {
            string query = "SELECT user_type_id FROM users WHERE id = " + userId;
            DataTable dt = dataProvider.exeQuery(query);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["user_type_id"]);
            }
            return -1;
        }
    }
}
