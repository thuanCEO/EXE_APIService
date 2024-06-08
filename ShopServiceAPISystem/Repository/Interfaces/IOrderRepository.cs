using BusinessObjects.Models;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, List<OrderDetail> listOrderDetail);
        void UpdateOrder(Order order);
        bool DeleteOrder(int id);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
    }
}
