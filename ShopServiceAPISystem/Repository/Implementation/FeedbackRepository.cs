using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDAO _dao;

        public FeedbackRepository(FeedbackDAO dao)
        {
            _dao = dao;
        }

        public void CreateFeedback(Feedback feedback)
        {
            _dao.CreateFeedback(feedback);
        }

        public void UpdateFeedback(Feedback feedback)
        {
            _dao.UpdateFeedback(feedback);
        }

        public void DeleteFeedback(int id)
        {
            _dao.DeleteFeedback(id);
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return _dao.GetAllFeedbacks();
        }

        public Feedback GetFeedbackById(int id)
        {
            return _dao.GetFeedbackById(id);
        }

        public void UpdateFeedbackStatus(int id, int status)
        {
            _dao.UpdateFeedbackStatus(id, status);
        }
    }
}
