using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
