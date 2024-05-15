using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.DAO
{
    public class BookType_DAO : DataProvider
    {
        private DataProvider dataProvider = new DataProvider();
        public DataTable GetBookTypes()
        {
            StringBuilder query = new StringBuilder("SELECT id as [Mã Loại Sách], type_name as [Loại Sách] FROM book_type");
            return dataProvider.exeQuery(query.ToString());
        }

        public int AddBookType(string typeName)
        {
            StringBuilder query = new StringBuilder("EXEC AddBookType @type_name = N'" + typeName + "'");
            return dataProvider.exeNonQuery(query.ToString());
        }

        public int UpdateBookType(int typeId, string typeName)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateBookType @type_id = " + typeId + ", @type_name = N'" + typeName + "'");
            return dataProvider.exeNonQuery(query.ToString());
        }

        public int DeleteBookType(int typeId)
        {
            StringBuilder query = new StringBuilder("EXEC DeleteBookType @type_id = " + typeId);
            return dataProvider.exeNonQuery(query.ToString());
        }
    }
}
