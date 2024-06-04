using AutoMapper;
using DTOs.vouchers;
using Microsoft.AspNetCore.Mvc;
using Service;
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
            var vouchers = await _voucherService.GetAllVouchers();
            if (vouchers == null)
            {
                return NotFound();
            }
            return Ok(vouchers);
        }

        [HttpGet]
        [Route("GetVoucherById/{id}")]
        public async Task<IActionResult> GetVoucherById(int id)
        {
            var voucher = await _voucherService.GetVoucherById(id);
            if (voucher == null)
            {
                return NotFound();
            }
            return Ok(voucher);
        }

        [HttpPost]
        [Route("CreateVoucher")]
        public async Task<IActionResult> CreateVoucher([FromBody] RequestVoucherDTO voucherDTO)
        {
            var voucherId = await _voucherService.CreateVoucher(voucherDTO);
            if (voucherId == 0)
            {
                return StatusCode(500, "Error creating voucher");
            }

            var createdVoucher = await _voucherService.GetVoucherById(voucherId);
            if (createdVoucher == null)
            {
                return StatusCode(500, "Error fetching newly created voucher");
            }

            return CreatedAtAction(nameof(GetVoucherById), new { id = createdVoucher.Id }, createdVoucher);
        }

        [HttpPut]
        [Route("UpdateVoucher/{id}")]
        public async Task<IActionResult> UpdateVoucher(int id, [FromBody] RequestVoucherDTO voucherDTO)
        {
            var voucherId = await _voucherService.UpdateVoucher(id, voucherDTO);
            if (voucherId == 0)
            {
                return StatusCode(500, "Error updating voucher");
            }

            var updatedVoucher = await _voucherService.GetVoucherById(id);

            return Ok(updatedVoucher);
        }

        [HttpDelete]
        [Route("DeleteVoucher/{id}")]
        public async Task<IActionResult> DeleteVoucher(int id)
        {
            var message = await _voucherService.DeleteVoucher(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateVoucherStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateVoucherStatus(int id, int status)
        {
            var voucher = await _voucherService.UpdateVoucherStatus(id, status);
            if (voucher == null)
            {
                return NotFound();
            }
            return Ok(voucher);
        }
    }
}
