using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAO
{
    public class ReceiptDetail_DAO
    {
        private DataProvider dataProvider = new DataProvider();
        public DataTable LoadReceiptDetail(int receiptId)
        {
            StringBuilder query = new StringBuilder("SELECT books.book_name as [Tên Sách]");
            query.Append(", receipt_detail.quantity as [Số Lượng]");
            query.Append(", books.price as [Giá Nhập]");
            query.Append(", books.price * receipt_detail.quantity as [Thành Tiền]");
            query.Append(" FROM receipt_detail, books");
            query.Append(" WHERE books.id = receipt_detail.book_id");
            query.Append(" AND receipt_detail.receipt_id = " + receiptId);
            return dataProvider.exeQuery(query.ToString());
        }
        public DataTable GetBook()
        {
            return dataProvider.exeQuery("SELECT * FROM books WHERE quantity > 0");
        }

        public int GetTotalPrice(int receiptId)
        {
            return (int)dataProvider.exeScaler("SELECT SUM(receipt_detail.quantity * books.price) FROM receipt_detail, books " +
                "WHERE receipt_detail.receipt_id = " + receiptId + " AND " + "receipt_detail.book_id = books.id");
        }

        public int GetBookQuantity(int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM books WHERE id = " + bookId);
        }

        public int GetReceiptDetailCount(int receiptId, int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT COUNT(*) FROM receipt_detail WHERE receipt_id = " + receiptId + " AND " + "book_id = " + bookId);
        }

        public int GetReceiptDetailSumQuantity(int receiptId, int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM receipt_detail WHERE receipt_id = " + receiptId + " AND " + "book_id = " + bookId);
        }

        public int GetReceiptDetailId(int receiptId, int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT id FROM receipt_detail WHERE receipt_id = " + receiptId + " AND " + "book_id = " + bookId);
        }

        public int AddReceiptDetail(int bookId, int quantity, int receiptId)
        {
            int count = GetReceiptDetailCount(receiptId, bookId);
            if (count == 0)
            {
                StringBuilder query = new StringBuilder("EXEC AddReceiptDetail ");
                query.Append(" @receipt_id = " + receiptId);
                query.Append(",@book_id = " + bookId);
                query.Append(",@quantity = " + quantity);
                return dataProvider.exeNonQuery(query.ToString());
            }
            else
            {
                int currentQuantity = GetReceiptDetailSumQuantity(receiptId, bookId);
                return UpdateReceiptDetail(GetReceiptDetailId(receiptId, bookId), bookId, quantity + currentQuantity, receiptId);
            }
        }

        public int UpdateReceiptDetail(int id, int bookId, int quantity, int receiptId)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateReceiptDetail ");
            query.Append(" @receipt_detail_id = " + id);
            query.Append(",@receipt_id = " + receiptId);
            query.Append(",@book_id = " + bookId);
            query.Append(",@quantity = " + quantity);
            return dataProvider.exeNonQuery(query.ToString());
        }

        public int DeleteReceiptDetail(int receiptDetailId)
        {
            StringBuilder query = new StringBuilder("DELETE FROM receipt_detail WHERE id = " + receiptDetailId);
            return dataProvider.exeNonQuery(query.ToString());
        }

    }
}
