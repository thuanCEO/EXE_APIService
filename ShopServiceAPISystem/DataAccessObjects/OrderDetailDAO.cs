using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class OrderDetailDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;
        public OrderDetailDAO(bs6ow0djyzdo8teyhoz4Context context)
        {
            _context = context;
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            orderDetail.Status = 1;
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetail existingOrderDetail = _context.OrderDetails.FirstOrDefault(p => p.Id == orderDetail.Id);
            _context.Entry(existingOrderDetail).CurrentValues.SetValues(orderDetail);
            _context.SaveChanges();
        }

        public bool DeleteOrderDetail(int id)
        {
            var orderDetail = _context.OrderDetails.Find(id);
            if (orderDetail == null)
                return false;
            if (orderDetail != null)
            {
                orderDetail.Status = 0;
                _context.OrderDetails.Update(orderDetail);
                _context.SaveChanges();
            }
            return true;
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails
                .OrderByDescending(x => x.Id)
                .Include(x => x.Product)
                .ToList();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return _context.OrderDetails
                .Include(x => x.Product)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
