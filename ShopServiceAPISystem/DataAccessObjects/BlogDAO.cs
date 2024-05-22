using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BlogDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;
        public BlogDAO(bs6ow0djyzdo8teyhoz4Context context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogs()
        {
            return _context.Blogs
                .OrderByDescending(x =>x.Id)
                .Include(x => x.User)
                .ToList();
        }
        public Blog GetBlogByID(int id)
        {
            return _context.Blogs
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }
        public void CreateBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }
    }
}
