using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class DataProvider
    {
        private string connectString = "Data Source=DESKTOP-ON0SMID\\HUYTHANH;Initial Catalog=BookShop;User ID=sa;Password=huyho2004;";
        public DataTable exeQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public int exeNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                data = cmd.ExecuteNonQuery();
                con.Close();
            }
            return data;
        }

        public object exeScaler(string query)
        {
            object data = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                data = cmd.ExecuteScalar();
                con.Close();
            }
            return data;
        }
    }
}
