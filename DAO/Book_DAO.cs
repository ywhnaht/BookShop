using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.DAO
{
    public class Book_DAO 
    {
        DataProvider dataProvider = new DataProvider();
        public DataTable LoadBook()
        {
            StringBuilder query = new StringBuilder("SELECT books.id as [Mã Sách]");
            query.Append(", books.book_name as [Tên Sách]");
            query.Append(", book_type.type_name as [Loại Sách]");
            query.Append(", books.author_name as [Tác Giả]");
            query.Append(", books.quantity as [Số Lượng]");
            query.Append(", books.price as [Giá Bán]");
            query.Append(" FROM books");
            query.Append(" LEFT JOIN book_type ON books.book_type_id = book_type.id");

            return dataProvider.exeQuery(query.ToString());
        }

        public DataTable GetBookTypes()
        {
            return dataProvider.exeQuery("SELECT * FROM book_type");
        }
        public int AddBook(string bookName, int bookTypeId, string authorName, int quantity, decimal price)
        {
            StringBuilder query = new StringBuilder("EXEC AddBook ");
            query.Append(" @book_name = N'" + bookName + "'");
            query.Append(",@book_type_id = " + bookTypeId);
            query.Append(",@author_name = N'" + authorName + "'");
            query.Append(",@quantity = " + quantity);
            query.Append(",@price = " + price);

            return dataProvider.exeNonQuery(query.ToString());
        }

        public int DeleteBook(int bookId)
        {
            StringBuilder query = new StringBuilder("EXEC DeleteBook @book_id = " + bookId);
            return dataProvider.exeNonQuery(query.ToString());
        }
        public int UpdateBook(int bookId, string bookName, int bookTypeId, string authorName, int quantity, decimal price)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateBook ");
            query.Append(" @book_id = " + bookId);
            query.Append(",@book_name = N'" + bookName + "'");
            query.Append(",@book_type_id = " + bookTypeId);
            query.Append(",@author_name = N'" + authorName + "'");
            query.Append(",@quantity = " + quantity);
            query.Append(",@price = " + price);

            return dataProvider.exeNonQuery(query.ToString());
        }
        public int GetBookQuantity(int bookId)
        {
            return (int)dataProvider.exeScaler("SELECT SUM(quantity) FROM books WHERE id = " + bookId);
        }
        public void UpdateBookQuantity(int bookId, int newQuantity)
        {
            StringBuilder query = new StringBuilder("UPDATE books SET quantity = " + newQuantity + " WHERE id = " + bookId);
            dataProvider.exeNonQuery(query.ToString());
        }
    }

}
