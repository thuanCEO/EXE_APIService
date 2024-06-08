using BusinessObjects.Models;

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
