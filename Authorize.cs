using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Authorize
    {
        private DataProvider dataProvider = new DataProvider();
        public int userId { get; set; }
        public List<string> Roles { get; set; }

        public Authorize(int userId)
        {
            this.userId = userId;
            Roles = LoadUserRoles(this.userId);
        }

        private List<string> LoadUserRoles(int userId)
        {
            List<string> roles = new List<string>();
            string query = "SELECT ur.role_name " +
                           "FROM user_role ur " +
                           "INNER JOIN user_type_user_role utur ON ur.id = utur.user_role_id " +
                           "INNER JOIN users u ON utur.user_type_id = u.user_type_id " +
                           "WHERE u.id = '" + userId + "'";

            DataTable dt = dataProvider.exeQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                roles.Add(row["role_name"].ToString());
            }

            return roles;
        }

        public bool HasRole(string roleName)
        {
            return Roles.Contains(roleName);
        }
    }
}
