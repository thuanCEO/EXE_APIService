using AutoMapper;
using BusinessObjects.Models;
using DTOs;
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

        public async Task<DataResponse<List<ResponseFeedbackDTO>>> GetAllFeedbacks()
        {
            var response = new DataResponse<List<ResponseFeedbackDTO>>();
            try
            {
                var feedbacks = await Task.Run(() => _feedbackRepository.GetAllFeedbacks());
                response.Data = _mapper.Map<List<ResponseFeedbackDTO>>(feedbacks);
                response.Success = true;
                response.Message = "Feedbacks retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseFeedbackDTO>> GetFeedbackById(int id)
        {
            var response = new DataResponse<ResponseFeedbackDTO>();
            try
            {
                var feedback = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
                if (feedback == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Feedback not found.";
                }
                else
                {
                    response.Data = _mapper.Map<ResponseFeedbackDTO>(feedback);
                    response.Success = true;
                    response.Message = "Feedback retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> CreateFeedback(RequestFeedbackDTO feedbackDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var feedback = _mapper.Map<Feedback>(feedbackDTO);
                await Task.Run(() => _feedbackRepository.CreateFeedback(feedback));
                response.Data = _mapper.Map<ResponseFeedbackDTO>(feedback);
                response.Success = true;
                response.Message = "Feedback created successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> UpdateFeedback(int id, RequestFeedbackDTO feedbackDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var feedbackToUpdate = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
                if (feedbackToUpdate == null)
                {
                    response.Data = 0;
                    response.Success = false;
                    response.Message = "Feedback not found.";
                }
                else
                {
                    _mapper.Map(feedbackDTO, feedbackToUpdate);
                    await Task.Run(() => _feedbackRepository.UpdateFeedback(feedbackToUpdate));
                    response.Data = _mapper.Map<ResponseFeedbackDTO>(feedbackToUpdate);
                    response.Success = true;
                    response.Message = "Feedback updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<string>> DeleteFeedback(int id)
        {
            var response = new DataResponse<string>();
            try
            {
                var feedbackToDelete = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
                if (feedbackToDelete == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Feedback not found.";
                }
                else
                {
                    await Task.Run(() => _feedbackRepository.DeleteFeedback(id));
                    response.Data = "Feedback deleted successfully.";
                    response.Success = true;
                    response.Message = "Feedback deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseFeedbackDTO>> UpdateFeedbackStatus(int id, int status)
        {
            var response = new DataResponse<ResponseFeedbackDTO>();
            try
            {
                var feedback = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
                if (feedback == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Feedback not found.";
                }
                else
                {
                    await Task.Run(() => _feedbackRepository.UpdateFeedbackStatus(id, status));
                    var updatedFeedback = await Task.Run(() => _feedbackRepository.GetFeedbackById(id));
                    response.Data = _mapper.Map<ResponseFeedbackDTO>(updatedFeedback);
                    response.Success = true;
                    response.Message = "Feedback status updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
