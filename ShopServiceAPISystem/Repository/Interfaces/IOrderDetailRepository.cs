using BusinessObjects.Models;

namespace Repository.Interfaces
{
    public interface IOrderDetailRepository
    {
        void CreateOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        bool DeleteOrderDetail(int id);
        List<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailById(int id);
    }
}
