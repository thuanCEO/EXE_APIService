using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBlogRepository
    {
        void CreateBlog(Blog blog);
        void UpdateBlog(Blog blog);
        bool DeleteBlog(int id);
        List<Blog> GetAllBlogs();
        Blog GetBlogById(int id);
    }
}
