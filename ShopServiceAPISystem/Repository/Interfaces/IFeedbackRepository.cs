using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IFeedbackRepository
    {
        void CreateFeedback(Feedback feedback);
        void UpdateFeedback(Feedback feedback);
        void DeleteFeedback(int id);
        List<Feedback> GetAllFeedbacks();
        Feedback GetFeedbackById(int id);
        void UpdateFeedbackStatus(int id, int status);
    }
}
