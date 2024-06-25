using BusinessObjects.Models;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;
        private readonly IConfiguration _configuration;

        public ProductDAO(bs6ow0djyzdo8teyhoz4Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task CreateProduct(Product product, IFormFile image)
        {
            if (image != null)
            {
                var imageUrl = await UploadImageToFirebase(image, product.ProductName);
                product.ImageUrl = imageUrl;
            }

            product.Status = 1;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return false;
            if (product != null)
            {
                product.Status = 0;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            return true;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .OrderByDescending(x => x.Id)
                .Include(x => x.Feedbacks)
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products
                .Include(p => p.Feedbacks)
                .ThenInclude(x => x.User)
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Id == id);
        }
        private async Task<string> UploadImageToFirebase(IFormFile image, string name)
        {
           
            var stream = image.OpenReadStream();
            var task = new FirebaseStorage(
                _configuration["Firebase:Bucket"],
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("images")
                .Child(DateTime.Now.ToString("yyyyMMddHHmmssfff") +"_"+ name)
                .PutAsync(stream);

            return await task;
        }
        public int CountProducts(int? status = null)
        {
            if (status.HasValue)
            {
                return _context.Products.Count(p => p.Status == status.Value);
            }
            return _context.Products.Count();
        }
    }
}
