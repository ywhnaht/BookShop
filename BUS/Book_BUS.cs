using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.BUS
{
    public class Book_BUS
    {
        private Book_DAO bookDAO = new Book_DAO();
        public DataTable GetBooks()
        {
            return bookDAO.LoadBook();
        }
        public DataTable GetBookTypes()
        {
            return bookDAO.GetBookTypes();
        }

        public bool AddBook(string bookName, int bookTypeId, string authorName, int quantity, decimal price)
        {
            int result = bookDAO.AddBook(bookName, bookTypeId, authorName, quantity, price);
            return result > 0;
        }

        public bool UpdateBook(int bookId, string bookName, int bookTypeId, string authorName, int quantity, decimal price)
        {
            int result = bookDAO.UpdateBook(bookId, bookName, bookTypeId, authorName, quantity, price);
            return result > 0;
        }

        public bool DeleteBook(int bookId)
        {
            int result = bookDAO.DeleteBook(bookId);
            return result > 0;
        }

        public bool UpdateBookQuantity(int bookId, int newQuantity, bool increase)
        {
            int currentQuantity = bookDAO.GetBookQuantity(bookId);
            if (increase)
            {
                bookDAO.UpdateBookQuantity(bookId, currentQuantity + newQuantity);
                return true;
            }
            else
            {
                if (currentQuantity < newQuantity)
                {
                    return false;
                } 
                else
                {
                    bookDAO.UpdateBookQuantity(bookId, currentQuantity - newQuantity);
                    return true;
                }
            }
        }
    }
}
