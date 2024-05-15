using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BUS
{
    public class Receipt_BUS
    {
        private Receipt_DAO receiptDAO = new Receipt_DAO();

        public DataTable GetReceipts()
        {
            return receiptDAO.GetReceipts();
        }
        public bool AddReceipt(DateTime dateCreate, string supplierName)
        {
            int result = receiptDAO.AddReceipt(dateCreate, supplierName);
            return result > 0;
        }
        public bool UpdateReceipt(int receiptId, DateTime dateCreate, string supplierName)
        {
            int result = receiptDAO.UpdateReceipt(receiptId, dateCreate, supplierName);
            return result > 0;
        }

        public bool DeleteReceipt(int receiptId)
        {
            int result = receiptDAO.DeleteReceipt(receiptId);
            return result > 0;
        }
    }
}
