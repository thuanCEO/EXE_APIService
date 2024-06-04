using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] RequestCategoryDTO categoryDTO)
        {
            var categoryId = await _categoryService.CreateCategory(categoryDTO);
            if (categoryId == 0)
            {
                return StatusCode(500, "Error creating category");
            }

            var createdCategory = await _categoryService.GetCategoryById(categoryId);
            if (createdCategory == null)
            {
                return StatusCode(500, "Error fetching newly created category");
            }

            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] RequestCategoryDTO categoryDTO)
        {

            var categoryId = await _categoryService.UpdateCategory(id, categoryDTO);
            if (categoryId == 0)
            {
                return StatusCode(500, "Error updating category");
            }

            var updatedCategory = await _categoryService.GetCategoryById(id);

            return Ok(updatedCategory);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var message = await _categoryService.DeleteCategory(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateCategoryStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateCategoryStatus(int id, int status)
        {
            var category = await _categoryService.UpdateCategoryStatus(id, status);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
