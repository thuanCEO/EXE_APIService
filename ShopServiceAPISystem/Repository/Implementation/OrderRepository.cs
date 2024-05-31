using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _dao;
        public OrderRepository(OrderDAO dao)
        {
            _dao = dao;
        }

        public void CreateOrder(Order order, List<OrderDetail> listOrderDetail)
        {
            _dao.CreateOrder(order,listOrderDetail);
        }

        public bool DeleteOrder(int id)
        {
            return _dao.DeleteOrder(id);
        }

        public List<Order> GetAllOrders()
        {
            return _dao.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _dao.GetOrderById(id);
        }

        public void UpdateOrder(Order order)
        {
            _dao.UpdateOrder(order);
        }
    }
}
