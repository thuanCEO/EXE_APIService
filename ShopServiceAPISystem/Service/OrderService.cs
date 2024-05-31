using BusinessObjects.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }
        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public void CreateOrder(Order order, List<OrderDetail> listOrderDetail)
        {
            _orderRepository.CreateOrder(order,listOrderDetail);
        }
        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }
        public bool DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }
    }
}
