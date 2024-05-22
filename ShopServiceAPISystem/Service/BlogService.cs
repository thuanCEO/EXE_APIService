using BusinessObjects.Models;
using Repository.Implementation;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BlogService
    {
        private IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public List<Blog> GetAllBlogs()
        {
            return _blogRepository.GetAllBlogs();
        }

        public void AddBlog(Blog blog)
        {
            _blogRepository.CreateBlog(blog);
        }
        public Blog GetBlogByID(int id)
        {
            return _blogRepository.GetBlogByID(id);
        }
    }
}
