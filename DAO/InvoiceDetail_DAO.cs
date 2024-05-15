using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.DAO
{
    public class InvoiceDetail_DAO : DataProvider
    {
        private DataProvider dataProvider = new DataProvider();
        public DataTable LoadInvoiceDetail(int invoiceId)
        {
            StringBuilder query = new StringBuilder("SELECT books.book_name as [Tên Sách]");
            query.Append(", invoice_detail.quantity as [Số Lượng]");
            query.Append(", books.price as [Đơn Giá]");
            query.Append(", books.price * invoice_detail.quantity as [Thành Tiền]");
            query.Append(" FROM invoice_detail, books");
            query.Append(" WHERE books.id = invoice_detail.book_id");
            query.Append(" AND invoice_detail.invoice_id = " + invoiceId);
            return dataProvider.exeQuery(query.ToString());
        }
        public DataTable GetBook()
        {
            return dataProvider.exeQuery("SELECT * FROM books WHERE quantity > 0");
        }

        public int GetTotalPrice(int invoiceId)
        {
            return (int)dataProvider.exeScaler("SELECT SUM(invoice_detail.quantity * books.price) FROM invoice_detail, books " +
                "WHERE invoice_detail.invoice_id = " + invoiceId + " AND " + "invoice_detail.book_id = books.id");
        }

        public int GetBookQuantity(int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM books WHERE id = " + bookId);
        }

        public bool GetInvoiceStatus(int invoiceId)
        {
            return (bool)dataProvider.exeScaler("SELECT status FROM invoice WHERE id = " + invoiceId);
        }
        public int GetInvoiceDetailCount(int invoiceId, int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT COUNT(*) FROM invoice_detail WHERE invoice_id = " + invoiceId + " AND " + "book_id = " + bookId);
        }

        public int GetInvoiceDetailSumQuantity(int invoiceId, int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM invoice_detail WHERE invoice_id = " + invoiceId + " AND " + "book_id = " + bookId);
        }

        public int GetInvoiceDetailId(int invoiceId, int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT id FROM invoice_detail WHERE invoice_id = " + invoiceId + " AND " + "book_id = " + bookId);
        }

        public int AddInvoiceDetail(int bookId, int quantity, int invoiceId)
        {
            StringBuilder query = new StringBuilder("EXEC AddInvoiceDetail ");
            query.Append(" @book_id = " + bookId);
            query.Append(",@quantity = " + quantity);
            query.Append(",@invoice_id = " + invoiceId);
            return dataProvider.exeNonQuery(query.ToString());
        }
        public int UpdateInvoiceDetail(int id, int bookId, int quantity, int invoiceId)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateInvoiceDetail ");
            query.Append(" @id = " + id);
            query.Append(",@book_id = " + bookId);
            query.Append(",@quantity = " + quantity);
            query.Append(",@invoice_id = " + invoiceId);
            return dataProvider.exeNonQuery(query.ToString());
        }

        public int DeleteInvoiceDt(int invoiceDetailId)
        {
            StringBuilder query = new StringBuilder("EXEC DeleteInvoiceDetail ");
            query.Append(" @id = " + invoiceDetailId);
            return dataProvider.exeNonQuery(query.ToString());
        }

        public int UpdateInvoiceTotalPrice(int invoiceId, int totalPrice)
        {
            return dataProvider.exeNonQuery("UPDATE invoice SET total_price = " + totalPrice + " WHERE id = " + invoiceId);
        }

        public void UpdateInvoiceStatus(int invoiceId, int status)
        {
            dataProvider.exeNonQuery("UPDATE invoice SET status = " + status + " WHERE id = " + invoiceId);
        }

        public DataTable GetInvoiceDetail(int invoiceId)
        {
            StringBuilder query = new StringBuilder("SELECT books.book_name");
            query.Append(", invoice_detail.quantity");
            query.Append(", books.price");
            query.Append(", books.price * invoice_detail.quantity as price_item");
            query.Append(", invoice.user_name");
            query.Append(", invoice.user_phone");
            query.Append(", invoice.date_create");
            query.Append(", invoice.total_price");
            query.Append(", users.full_name as employee_name");
            query.Append(" FROM invoice_detail");
            query.Append(" JOIN books ON books.id = invoice_detail.book_id");
            query.Append(" JOIN invoice ON invoice_detail.invoice_id = invoice.id");
            query.Append(" JOIN users ON invoice.user_id = users.id");
            query.Append(" WHERE invoice_detail.invoice_id = " + invoiceId);
            return exeQuery(query.ToString());
        }
    }
}
