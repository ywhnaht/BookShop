using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BUS
{
    public class Invoice_BUS
    {
        private Invoice_DAO invoiceDAO = new Invoice_DAO();

        public DataTable GetInvoices()
        {
            return invoiceDAO.GetInvoices();
        }

        public bool AddInvoice(DateTime dateCreate, int userId, string userName, string userPhone)
        {
            int result = invoiceDAO.AddInvoice(dateCreate, userId, userName, userPhone);
            return result > 0;
        }
        public bool UpdateInvoice(int invoiceId, DateTime dateCreate, int userId, string userName, string userPhone)
        {
            int result = invoiceDAO.UpdateInvoice(invoiceId, dateCreate, userId, userName, userPhone);
            return result > 0;
        }

        public bool DeleteInvoice(int invoiceId)
        {
            int result = invoiceDAO.DeleteInvoice(invoiceId);
            return result > 0;
        }
    }
}
