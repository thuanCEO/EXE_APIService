using BusinessObjects.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderDetailService
    {
        private IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailRepository.GetAllOrderDetails();
        }
        public OrderDetail GetOrderDetailById(int id)
        {
            return _orderDetailRepository.GetOrderDetailById(id);
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.CreateOrderDetail(orderDetail);
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }
        public bool DeleteOrderDetail(int id)
        {
            return _orderDetailRepository.DeleteOrderDetail(id);
        }
    }
}
