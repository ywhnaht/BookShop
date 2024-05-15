using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.DAO
{
    public class Receipt_DAO : DataProvider
    {
        private DataProvider dataProvider = new DataProvider();

        public DataTable GetReceipts()
        {
            StringBuilder query = new StringBuilder("SELECT id as [Mã Phiếu Nhập], date_create as [Ngày Tạo], supplier_name as [Nhà Xuất Bản] FROM receipt");
            return dataProvider.exeQuery(query.ToString());
        }

        public int AddReceipt(DateTime dateCreate, string supplierName)
        {
            StringBuilder query = new StringBuilder("EXEC AddReceipt ");
            query.Append("@date_create = '" + dateCreate.ToString("yyyy-MM-dd") + "', ");
            query.Append("@supplier_name = N'" + supplierName + "'");
            return dataProvider.exeNonQuery(query.ToString());
        }
        public int UpdateReceipt(int receiptId, DateTime dateCreate, string supplierName)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateReceipt ");
            query.Append("@receipt_id = " + receiptId + ", ");
            query.Append("@date_create = '" + dateCreate.ToString("yyyy-MM-dd") + "', ");
            query.Append("@supplier_name = N'" + supplierName + "'");
            return dataProvider.exeNonQuery(query.ToString());
        }

        public int DeleteReceipt(int receiptId)
        {
            StringBuilder query = new StringBuilder("EXEC DeleteReceipt @receipt_id = " + receiptId);
            return dataProvider.exeNonQuery(query.ToString());
        }


    }
}
