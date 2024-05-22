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
        List<Blog> GetAllBlogs();
        Blog GetBlogByID(int id);
        void CreateBlog(Blog blog);
    }
}
