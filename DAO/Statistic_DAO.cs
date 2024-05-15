using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAO
{
    public class Statistic_DAO
    {
        private DataProvider dataProvider = new DataProvider();

        public DataTable GetOverallRevenue(string dateFrom, string dateEnd)
        {
            StringBuilder query = new StringBuilder("EXEC OverallRevenue ");
            query.Append("@date_from = '" + dateFrom + "', ");
            query.Append("@date_end = '" + dateEnd + "'");
            return dataProvider.exeQuery(query.ToString());
        }
        public DataTable GetRevenueByBook(int bookId, string dateFrom, string dateEnd)
        {
            StringBuilder query = new StringBuilder("EXEC RevenueByBook ");
            query.Append("@book_id = " + bookId + ", ");
            query.Append("@date_from = '" + dateFrom + "', ");
            query.Append("@date_end = '" + dateEnd + "'");
            return dataProvider.exeQuery(query.ToString());
        }
        public DataTable GetRevenueByBookType(int bookTypeId, string dateFrom, string dateEnd)
        {
            StringBuilder query = new StringBuilder("EXEC RevenueByBookType ");
            query.Append("@book_type_id = " + bookTypeId + ", ");
            query.Append("@date_from = '" + dateFrom + "', ");
            query.Append("@date_end = '" + dateEnd + "'");
            return dataProvider.exeQuery(query.ToString());
        }
        public DataTable GetRevenueByUser(int userId, string dateFrom, string dateEnd)
        {
            StringBuilder query = new StringBuilder("EXEC RevenueByUser ");
            query.Append("@user_id = " + userId + ", ");
            query.Append("@date_from = '" + dateFrom + "', ");
            query.Append("@date_end = '" + dateEnd + "'");
            return dataProvider.exeQuery(query.ToString());
        }
    }
}
