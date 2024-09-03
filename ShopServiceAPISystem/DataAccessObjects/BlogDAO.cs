using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class BlogDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context = new bs6ow0djyzdo8teyhoz4Context();
        public BlogDAO()
        {
        }

        public void CreateBlog(Blog blog)
        {
            blog.Status = 1;
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void UpdateBlog(Blog blog)
        {
            Blog existingBlog = _context.Blogs.FirstOrDefault(p => p.Id == blog.Id);
            _context.Entry(existingBlog).CurrentValues.SetValues(blog);
            _context.SaveChanges();
        }

        public bool DeleteBlog(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog == null)
                return false;
            if (blog != null)
            {
                blog.Status = 0;
                _context.Blogs.Update(blog);
                _context.SaveChanges();
            }
            return true;
        }

        public List<Blog> GetAllBlogs()
        {
            return _context.Blogs
                .OrderByDescending(x => x.Id)
                .Include(x => x.User)
                .ToList();
        }

        public Blog GetBlogById(int id)
        {
            return _context.Blogs
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
