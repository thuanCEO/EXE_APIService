using AutoMapper;
using BusinessObjects.Models;
using DTOs.Create;
using DTOs.Update;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private OrderDetailService _orderDetailService;
        private readonly IMapper _mapper;
        public OrderDetailController(OrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllOrderDetails")]
        public IActionResult GetAllOrderDetails()
        {
            return Ok(_orderDetailService.GetAllOrderDetails());
        }

        [HttpGet]
        [Route("GetOrderDetailById")]
        public IActionResult GetOrderDetailById(int id)
        {
            return Ok(_orderDetailService.GetOrderDetailById(id));
        }

        [HttpPost]
        [Route("CreateOrderDetail")]
        public IActionResult CreateOrderDetail([FromBody] CreateOrderDetailDTO orderDetailDTO)
        {
            OrderDetail orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            _orderDetailService.CreateOrderDetail(orderDetail);
            return Created("", "Tạo thành công");
        }

        [HttpPut]
        [Route("UpdateOrderDetail")]
        public IActionResult UpdateOrderDetail([FromBody] UpdateOrderDetailDTO orderDetailDTO, int id)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            orderDetail.Id = id;
            _orderDetailService.UpdateOrderDetail(orderDetail);
            return Ok("Update thành công");
        }

        [HttpDelete]
        [Route("DeleteOrderDetail")]
        public IActionResult DeleteOrderDetail(int id)
        {
            if (_orderDetailService.DeleteOrderDetail(id) == true)
            {
                return Ok("Xóa thành công");
            }
            else
                return StatusCode(500, "Không tồn tại Id này");

        }
    }
}
