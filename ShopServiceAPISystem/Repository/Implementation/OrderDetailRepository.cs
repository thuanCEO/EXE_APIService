using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDetailDAO _dao;
        public OrderDetailRepository(OrderDetailDAO dao)
        {
            _dao = dao;
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            _dao.CreateOrderDetail(orderDetail);
        }

        public bool DeleteOrderDetail(int id)
        {
            return _dao.DeleteOrderDetail(id);
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _dao.GetAllOrderDetails();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return _dao.GetOrderDetailById(id);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _dao.UpdateOrderDetail(orderDetail);
        }
    }
}
