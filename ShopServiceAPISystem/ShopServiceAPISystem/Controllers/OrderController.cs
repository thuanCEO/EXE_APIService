using AutoMapper;
using BusinessObjects.Models;
using DTOs.Create;
using DTOs.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(OrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet]
        [Route("GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            return Ok(_orderService.GetOrderById(id));
        }

        [HttpPost]
        [Route("CreateOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            Order order = _mapper.Map<Order>(request.OrderDTO);
            List<OrderDetail> listOrderDetail = _mapper.Map<List<OrderDetail>>(request.OrderDetailDTO);
            _orderService.CreateOrder(order,listOrderDetail);
            return Created("", "Tạo thành công");
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] UpdateOrderDTO orderDTO, int id)
        {
            var order = _mapper.Map<Order>(orderDTO);
            order.Id = id;
            _orderService.UpdateOrder(order);
            return Ok("Update thành công");
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder(int id)
        {
            if (_orderService.DeleteOrder(id) == true)
            {
                return Ok("Xóa thành công");
            }
            else
                return StatusCode(500, "Không tồn tại Id này");

        }
    }
}
