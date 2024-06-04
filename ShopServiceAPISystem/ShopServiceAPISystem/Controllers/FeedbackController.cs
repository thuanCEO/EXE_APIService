using AutoMapper;
using DTOs.Feedbacks;
using Microsoft.AspNetCore.Mvc;
using Service;
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
            var feedbacks = await _feedbackService.GetAllFeedbacks();
            if (feedbacks == null)
            {
                return NotFound();
            }
            return Ok(feedbacks);
        }

        [HttpGet]
        [Route("GetFeedbackById/{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost]
        [Route("CreateFeedback")]
        public async Task<IActionResult> CreateFeedback([FromBody] RequestFeedbackDTO feedbackDTO)
        {
            var feedbackId = await _feedbackService.CreateFeedback(feedbackDTO);
            if (feedbackId == 0)
            {
                return StatusCode(500, "Error creating feedback");
            }

            var createdFeedback = await _feedbackService.GetFeedbackById(feedbackId);
            if (createdFeedback == null)
            {
                return StatusCode(500, "Error fetching newly created feedback");
            }

            return CreatedAtAction(nameof(GetFeedbackById), new { id = createdFeedback.Id }, createdFeedback);
        }

        [HttpPut]
        [Route("UpdateFeedback/{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] RequestFeedbackDTO feedbackDTO)
        {

            var feedbackId = await _feedbackService.UpdateFeedback(id, feedbackDTO);
            if (feedbackId == 0)
            {
                return StatusCode(500, "Error updating feedback");
            }

            var updatedFeedback = await _feedbackService.GetFeedbackById(id);

            return Ok(updatedFeedback);
        }

        [HttpDelete]
        [Route("DeleteFeedback/{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var message = await _feedbackService.DeleteFeedback(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateFeedbackStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateFeedbackStatus(int id, int status)
        {
            var feedback = await _feedbackService.UpdateFeedbackStatus(id, status);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }
    }
}
