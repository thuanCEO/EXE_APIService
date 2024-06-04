using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessObjects.Models;
using DTOs.Categories;
using Repository.Interfaces;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<ResponseCategoryDTO>> GetAllCategories()
    {
        var categories = await Task.Run(() => _categoryRepository.GetAllCategories());
        return _mapper.Map<List<ResponseCategoryDTO>>(categories);
    }

    public async Task<ResponseCategoryDTO> GetCategoryById(int id)
    {
        var category = await Task.Run(() => _categoryRepository.GetCategoryById(id));
        if (category == null)
        {
            return null;
        }
        return _mapper.Map<ResponseCategoryDTO>(category);
    }

    public async Task<int> CreateCategory(RequestCategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);
        await Task.Run(() => _categoryRepository.CreateCategory(category));
        return category.Id;
    }

    public async Task<int> UpdateCategory(int id, RequestCategoryDTO categoryDTO)
    {
        var categoryToUpdate = await Task.Run(() => _categoryRepository.GetCategoryById(id));
        if (categoryToUpdate == null)
        {
            return 0;
        }
        _mapper.Map(categoryDTO, categoryToUpdate);
        await Task.Run(() => _categoryRepository.UpdateCategory(categoryToUpdate));
        return categoryToUpdate.Id;
    }

    public async Task<string> DeleteCategory(int id)
    {
        var categoryToDelete = await Task.Run(() => _categoryRepository.GetCategoryById(id));
        if (categoryToDelete == null)
        {
            return null;
        }
        await Task.Run(() => _categoryRepository.DeleteCategory(id));
        return "Category deleted successfully.";
    }

    public async Task<ResponseCategoryDTO> UpdateCategoryStatus(int id, int status)
    {
        var category = await Task.Run(() => _categoryRepository.GetCategoryById(id));
        if (category == null)
        {
            return null;
        }
        await Task.Run(() => _categoryRepository.UpdateCategoryStatus(id, status));
        var updatedCategory = await Task.Run(() => _categoryRepository.GetCategoryById(id));
        return _mapper.Map<ResponseCategoryDTO>(updatedCategory);
    }
}
