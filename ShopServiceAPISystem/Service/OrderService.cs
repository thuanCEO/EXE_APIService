﻿using BusinessObjects.Models;
using Repository.Interfaces;

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
            _orderRepository.CreateOrder(order, listOrderDetail);
        }
        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }
        public bool DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }
        public int CountOrders(int? status = null)
        {
            return _orderRepository.CountOrders(status);
        }
    }
}
