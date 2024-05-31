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
        public Blog GetBlogById(int id)
        {
            return _blogRepository.GetBlogById(id);
        }

        public void CreateBlog(Blog blog)
        {
            _blogRepository.CreateBlog(blog);
        }
        public void UpdateBlog(Blog blog)
        {
            _blogRepository.UpdateBlog(blog);
        }
        public bool DeleteBlog(int id)
        {
            return _blogRepository.DeleteBlog(id);
        }
    }
}
