using BookShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BUS
{
    public class ReceiptDetail_BUS
    {
        private ReceiptDetail_DAO receiptDetailDAO = new ReceiptDetail_DAO();
        public DataTable GetReceiptDetails(int receiptId)
        {
            return receiptDetailDAO.LoadReceiptDetail(receiptId);
        }

        public bool AddReceiptDetail(int receiptId, int bookId, int quantity)
        {
            return receiptDetailDAO.AddReceiptDetail(bookId, quantity, receiptId) > 0;
        }

        public int GetReceiptDetailCount(int receiptId, int bookId)
        {
            return receiptDetailDAO.GetReceiptDetailCount(receiptId, bookId);
        }

        public int GetReceiptDetailSumQuantity(int receiptId, int bookId)
        {
            return receiptDetailDAO.GetReceiptDetailSumQuantity(receiptId, bookId);
        }
        public bool UpdateReceiptDetail(int receiptDetailId, int receiptId, int bookId, int quantity)
        {
            return receiptDetailDAO.UpdateReceiptDetail(receiptDetailId, bookId, quantity, receiptId) > 0;
        }

        public bool DeleteReceiptDetail(int receiptDetailId, int bookId, int receiptId)
        {
            int currentQuantity = receiptDetailDAO.GetReceiptDetailSumQuantity(receiptId, bookId);
            if (currentQuantity < receiptDetailDAO.GetBookQuantity(bookId))
            {
                return receiptDetailDAO.DeleteReceiptDetail(receiptDetailId) > 0;
            }
            else
            {
                // Số lượng sách hiện tại trong cửa hàng nhỏ hơn hoặc bằng số lượng sách trong phiếu nhập chi tiết
                // Báo lỗi
                return false;
            }
        }

        public int GetTotalPrice(int receiptId)
        {
            return receiptDetailDAO.GetTotalPrice(receiptId);
        }

        public int GetReceiptDetailId(int receiptId, int bookId)
        {
            return receiptDetailDAO.GetReceiptDetailId(receiptId, bookId);
        }
    }
}
