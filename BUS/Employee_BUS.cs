using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BUS
{
    internal class Employee_BUS
    {
        Employee_DAO employeeDAO = new Employee_DAO();
        public bool Login(string username, string password)
        {

            string query = $"SELECT hashed_password FROM users WHERE user_name = '{username}'";

            DataProvider provider = new DataProvider();
            object result = provider.exeScaler(query);

            if (result != null)
            {
                string hashedPassword = result.ToString();

                if (PasswordEncrypt.VerifyPassword(password, hashedPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public DataTable GetEmployees()
        {
            return employeeDAO.GetEmployees();
        }

        public DataTable AddEmployee(string fullName, string phone, string address)
        {
            return employeeDAO.AddEmployee(fullName, phone, address);
        }

        public int UpdateEmployee(int userId, string fullName, string phone, string address, int userTypeId)
        {
            return employeeDAO.UpdateEmployee(userId, fullName, phone, address, userTypeId);
        }

        public int DeleteEmployee(int userId)
        {
            return employeeDAO.DeleteEmployee(userId);
        }

        public int GetUserTypeId(int userId)
        {
            return employeeDAO.GetUserTypeId(userId);
        }
    }
}
