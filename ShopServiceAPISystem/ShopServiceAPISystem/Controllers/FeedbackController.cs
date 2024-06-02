using AutoMapper;
using DTOs.Feedbacks;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        [Route("GetAllFeedbacks")]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var response = await _feedbackService.GetAllFeedbacks();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetFeedbackById/{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var response = await _feedbackService.GetFeedbackById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateFeedback")]
        public async Task<IActionResult> CreateFeedback([FromBody] RequestFeedbackDTO feedbackDTO)
        {
            var response = await _feedbackService.CreateFeedback(feedbackDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return CreatedAtAction(nameof(GetFeedbackById), new { id = response.Data }, response);
        }

        [HttpPut]
        [Route("UpdateFeedback/{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] RequestFeedbackDTO feedbackDTO)
        {
            var response = await _feedbackService.UpdateFeedback(id, feedbackDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteFeedback/{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var response = await _feedbackService.DeleteFeedback(id);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateFeedbackStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateFeedbackStatus(int id, int status)
        {
            var response = await _feedbackService.UpdateFeedbackStatus(id, status);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }
    }
}
