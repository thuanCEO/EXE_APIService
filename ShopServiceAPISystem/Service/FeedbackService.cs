using AutoMapper;
using BusinessObjects.Models;
using DTOs.Feedbacks;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class FeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseFeedbackDTO>> GetAllFeedbacks()
        {
            var feedbacks = await Task.Run(() => _feedbackRepository.GetAllFeedbacks());
            return _mapper.Map<List<ResponseFeedbackDTO>>(feedbacks);
        }

        public async Task<ResponseFeedbackDTO> GetFeedbackById(int id)
        {
            var feedback = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
            if (feedback == null)
            {
                return null;
            }
            return _mapper.Map<ResponseFeedbackDTO>(feedback);
        }

        public async Task<int> CreateFeedback(RequestFeedbackDTO feedbackDTO)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDTO);
            await Task.Run(() => _feedbackRepository.CreateFeedback(feedback));
            return feedback.Id;
        }

        public async Task<int> UpdateFeedback(int id, RequestFeedbackDTO feedbackDTO)
        {
            var feedbackToUpdate = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
            if (feedbackToUpdate == null)
            {
                return 0;
            }
            _mapper.Map(feedbackDTO, feedbackToUpdate);
            await Task.Run(() => _feedbackRepository.UpdateFeedback(feedbackToUpdate));
            return feedbackToUpdate.Id;
        }

        public async Task<string> DeleteFeedback(int id)
        {
            var feedbackToDelete = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
            if (feedbackToDelete == null)
            {
                return null;
            }
            await Task.Run(() => _feedbackRepository.DeleteFeedback(id));
            return "Feedback deleted successfully.";
        }

        public async Task<ResponseFeedbackDTO> UpdateFeedbackStatus(int id, int status)
        {
            var feedback = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
            if (feedback == null)
            {
                return null;
            }
            await Task.Run(() => _feedbackRepository.UpdateFeedbackStatus(id, status));
            var updatedFeedback = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
            return _mapper.Map<ResponseFeedbackDTO>(updatedFeedback);
        }
    }
}
