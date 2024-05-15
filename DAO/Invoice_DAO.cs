using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.DAO
{
    internal class Invoice_DAO : DataProvider
    {
        private DataProvider dataProvider = new DataProvider();

        public DataTable GetInvoices()
        {
            StringBuilder query = new StringBuilder("SELECT id as [Mã Hóa Đơn], date_create as [Ngày Tạo], user_name as [Tên Khách Hàng], user_phone as [Số Điện Thoại], ");
            query.Append("CASE WHEN status = 1 THEN N'Đã thanh toán' ELSE N'Chưa thanh toán' END AS [Trạng Thái] ");
            query.Append("FROM invoice");
            return dataProvider.exeQuery(query.ToString());
        }

        public int AddInvoice(DateTime dateCreate, int userId, string userName, string userPhone)
        {
            StringBuilder query = new StringBuilder("EXEC AddInvoice ");
            query.Append("@date_create = '" + dateCreate.ToString("yyyy-MM-dd") + "', ");
            query.Append("@user_id = " + userId + ", ");
            query.Append("@user_name = N'" + userName + "', ");
            query.Append("@user_phone = '" + userPhone + "'");
            return dataProvider.exeNonQuery(query.ToString());
        }

        public int UpdateInvoice(int invoiceId, DateTime dateCreate, int userId, string userName, string userPhone)
        {
            StringBuilder query = new StringBuilder("EXEC UpdateInvoice ");
            query.Append("@invoice_id = " + invoiceId + ", ");
            query.Append("@date_create = '" + dateCreate.ToString("yyyy-MM-dd") + "', ");
            query.Append("@user_id = " + userId + ", ");
            query.Append("@user_name = N'" + userName + "', ");
            query.Append("@user_phone = '" + userPhone + "'");
            return dataProvider.exeNonQuery(query.ToString());
        }
        public int DeleteInvoice(int invoiceId)
        {
            StringBuilder query = new StringBuilder("EXEC DeleteInvoice @invoice_id = " + invoiceId);
            return dataProvider.exeNonQuery(query.ToString());
        }

    }
}
