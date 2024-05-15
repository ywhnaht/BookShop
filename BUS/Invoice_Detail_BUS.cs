using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BUS
{
    internal class Invoice_Detail_BUS
    {
        private InvoiceDetail_DAO InvoiceDetail_DAO = new InvoiceDetail_DAO();

        public DataTable GetInvoiceDetails(int invoiceId)
        {
            return InvoiceDetail_DAO.LoadInvoiceDetail(invoiceId);
        }

        public int GetTotalPrice(int invoiceId)
        {
            return InvoiceDetail_DAO.GetTotalPrice(invoiceId);
        }
        public DataTable GetBook()
        {
            return InvoiceDetail_DAO.GetBook();
        }

        public int GetBookQuantity(int bookId)
        {
            return InvoiceDetail_DAO.GetBookQuantity(bookId);
        }

        public bool GetInvoiceStatus(int invoiceId)
        {
            return InvoiceDetail_DAO.GetInvoiceStatus(invoiceId);
        }

        public int GetInvoiceDetailCount(int invoiceId, int bookId)
        {
            return InvoiceDetail_DAO.GetInvoiceDetailCount(invoiceId, bookId);
        }

        public int GetInvoiceDetailSumQuantity(int invoiceId, int bookId)
        {
            return InvoiceDetail_DAO.GetInvoiceDetailSumQuantity(invoiceId, bookId);
        }

        public bool AddOrUpdateInvoiceDetail(int invoiceId, int bookId, int quantity)
        {
            int count = InvoiceDetail_DAO.GetBookQuantity(bookId);
            if (quantity <= count)
            {
                int sum = InvoiceDetail_DAO.GetInvoiceDetailCount(invoiceId, bookId);
                if (sum == 0)
                {
                    int result = InvoiceDetail_DAO.AddInvoiceDetail(bookId, quantity, invoiceId);
                    return result > 0;
                }
                else
                {
                    int currentQuantity = InvoiceDetail_DAO.GetInvoiceDetailSumQuantity(invoiceId, bookId);
                    return UpdateInvoiceDetail(invoiceId, bookId, quantity + currentQuantity);
                }
            }
            else
            {
                throw new Exception("Không đủ số lượng sách này trong cửa hàng!");
            }
        }

        public bool UpdateInvoiceDetail(int invoiceId, int bookId, int quantity)
        {
            int invoiceDetailId = InvoiceDetail_DAO.GetInvoiceDetailId(invoiceId, bookId);
            int result = InvoiceDetail_DAO.UpdateInvoiceDetail(invoiceDetailId, bookId, quantity, invoiceId);
            return result > 0;
        }

        public bool DeleteInvoiceDetail(int invoiceDetailId)
        {
            int result = InvoiceDetail_DAO.DeleteInvoiceDt(invoiceDetailId);
            return result > 0;
        }

        public void UpdateInvoiceTotalPrice(int invoiceId)
        {
            int totalPrice = InvoiceDetail_DAO.GetTotalPrice(invoiceId);
            InvoiceDetail_DAO.UpdateInvoiceTotalPrice(invoiceId, totalPrice);
        }

        public void UpdateInvoiceStatus(int invoiceId, int status)
        {
            InvoiceDetail_DAO.UpdateInvoiceStatus(invoiceId, status);
        }

        public DataTable GetInvoiceForPrinting(int invoiceId)
        {
            return InvoiceDetail_DAO.GetInvoiceDetail(invoiceId);
        }
    }
}
