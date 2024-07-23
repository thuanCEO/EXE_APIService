using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class OrderDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context = new bs6ow0djyzdo8teyhoz4Context();
        public OrderDAO()
        {
        }

        public void CreateOrder(Order order, List<OrderDetail> listOrderDetail)
        {
            order.Status = 1;
            order.CreatedDate = DateTime.Now;
            order.IsPayment = false;
            _context.Orders.Add(order);
            _context.SaveChanges();
            foreach (OrderDetail detail in listOrderDetail)
            {
                detail.OrderId = order.Id;
                detail.Status = 1;
            }
            _context.OrderDetails.AddRange(listOrderDetail);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            Order existingOrder = _context.Orders.FirstOrDefault(p => p.Id == order.Id);
            _context.Entry(existingOrder).CurrentValues.SetValues(order);
            _context.SaveChanges();
        }

        public bool DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
                return false;
            if (order != null)
            {
                order.Status = 0;
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
            return true;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .OrderByDescending(x => x.Id)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                .Include(x => x.Voucher)
                .Include(x => x.Payment)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
