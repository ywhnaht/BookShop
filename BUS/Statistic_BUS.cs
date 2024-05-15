using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BUS
{
    public class Statistic_BUS
    {
        private Statistic_DAO statisticDAO = new Statistic_DAO();

        public DataTable GetOverallRevenue(string dateFrom, string dateEnd)
        {
            return statisticDAO.GetOverallRevenue(dateFrom, dateEnd);
        }

        public DataTable GetRevenueByBook(int bookId, string dateFrom, string dateEnd)
        {
            return statisticDAO.GetRevenueByBook(bookId, dateFrom, dateEnd);
        }

        public DataTable GetRevenueByBookType(int bookTypeId, string dateFrom, string dateEnd)
        {
            return statisticDAO.GetRevenueByBookType(bookTypeId, dateFrom, dateEnd);
        }
        public DataTable GetRevenueByUser(int userId, string dateFrom, string dateEnd)
        {
            return statisticDAO.GetRevenueByUser(userId, dateFrom, dateEnd);
        }
    }
}
