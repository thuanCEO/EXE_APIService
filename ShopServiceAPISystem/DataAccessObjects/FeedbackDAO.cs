using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class FeedbackDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context = new bs6ow0djyzdo8teyhoz4Context();
        public FeedbackDAO()
        {
        }

        public void CreateFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void UpdateFeedback(Feedback feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteFeedback(int id)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
            }
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return _context.Feedbacks.Include(f => f.User).Include(f => f.Product).ToList();
        }

        public Feedback GetFeedbackById(int id)
        {
            return _context.Feedbacks.Include(f => f.User).Include(f => f.Product).FirstOrDefault(f => f.Id == id);
        }

        public void UpdateFeedbackStatus(int id, int status)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback != null)
            {
                feedback.Status = status;
                _context.SaveChanges();
            }
        }
    }
}
