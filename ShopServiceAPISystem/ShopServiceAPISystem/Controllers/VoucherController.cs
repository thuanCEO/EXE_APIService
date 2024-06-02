using AutoMapper;
using DTOs.vouchers;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly VoucherService _voucherService;

        public VoucherController(VoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet]
        [Route("GetAllVouchers")]
        public async Task<IActionResult> GetAllVouchers()
        {
            var response = await _voucherService.GetAllVouchers();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetVoucherById/{id}")]
        public async Task<IActionResult> GetVoucherById(int id)
        {
            var response = await _voucherService.GetVoucherById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateVoucher")]
        public async Task<IActionResult> CreateVoucher([FromBody] RequestVoucherDTO voucherDTO)
        {
            var response = await _voucherService.CreateVoucher(voucherDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateVoucher/{id}")]
        public async Task<IActionResult> UpdateVoucher(int id, [FromBody] RequestVoucherDTO voucherDTO)
        {
            var response = await _voucherService.UpdateVoucher(id, voucherDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteVoucher/{id}")]
        public async Task<IActionResult> DeleteVoucher(int id)
        {
            var response = await _voucherService.DeleteVoucher(id);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }


        [HttpPut]
        [Route("UpdateVoucherStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateVoucherStatus(int id, int status)
        {
            var response = await _voucherService.UpdateVoucherStatus(id, status);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }
    }
}
