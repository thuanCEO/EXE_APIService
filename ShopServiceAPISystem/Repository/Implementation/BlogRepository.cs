using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class BlogRepository :IBlogRepository
    {
        private readonly BlogDAO _dao;
        public BlogRepository(BlogDAO dao)
        {
            _dao = dao;
        }

        public void CreateBlog(Blog blog)
        {
            _dao.CreateBlog(blog);
        }

        public bool DeleteBlog(int id)
        {
            return _dao.DeleteBlog(id);
        }

        public List<Blog> GetAllBlogs()
        {
            return _dao.GetAllBlogs();
        }

        public Blog GetBlogById(int id)
        {
            return _dao.GetBlogById(id);
        }

        public void UpdateBlog(Blog blog)
        {
            _dao.UpdateBlog(blog);
        }
    }
}
