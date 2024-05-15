using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BUS
{
    public class BookType_BUS
    {
        private BookType_DAO bookTypeDAO = new BookType_DAO();
        public DataTable GetBookTypes()
        {
            return bookTypeDAO.GetBookTypes();
        }

        public bool AddBookType(string typeName)
        {
            int result = bookTypeDAO.AddBookType(typeName);
            return result > 0;
        }

        public bool UpdateBookType(int typeId, string typeName)
        {
            int result = bookTypeDAO.UpdateBookType(typeId, typeName);
            return result > 0;
        }

        public bool DeleteBookType(int typeId)
        {
            int result = bookTypeDAO.DeleteBookType(typeId);
            return result > 0;
        }
    }
}
