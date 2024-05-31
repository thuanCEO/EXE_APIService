using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using DTOs.Categories;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<ResponseCategoryDTO>>> GetAllCategories()
        {
            var response = new DataResponse<List<ResponseCategoryDTO>>();
            try
            {
                var categories = await Task.Run(() => _categoryRepository.GetAllCategories());
                response.Data = _mapper.Map<List<ResponseCategoryDTO>>(categories);
                response.Success = true;
                response.Message = "Categories retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCategoryDTO>> GetCategoryById(int id)
        {
            var response = new DataResponse<ResponseCategoryDTO>();
            try
            {
                var category = await Task.Run(() => _categoryRepository.GetCategoryById(id));
                if (category == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Category not found.";
                }
                else
                {
                    response.Data = _mapper.Map<ResponseCategoryDTO>(category);
                    response.Success = true;
                    response.Message = "Category retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> CreateCategory(RequestCategoryDTO categoryDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);
                await Task.Run(() => _categoryRepository.CreateCategory(category));
                response.Data = _mapper.Map<ResponseCategoryDTO>(category);
                response.Success = true;
                response.Message = "Category created successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> UpdateCategory(int id, RequestCategoryDTO categoryDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var categoryToUpdate = await Task.Run(() => _categoryRepository.GetCategoryById(id));
                if (categoryToUpdate == null)
                {
                    response.Data = 0;
                    response.Success = false;
                    response.Message = "Category not found.";
                }
                else
                {
                    _mapper.Map(categoryDTO, categoryToUpdate);
                    await Task.Run(() => _categoryRepository.UpdateCategory(categoryToUpdate));
                    response.Data = _mapper.Map<ResponseCategoryDTO>(categoryToUpdate);
                    response.Success = true;
                    response.Message = "Category updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<string>> DeleteCategory(int id)
        {
            var response = new DataResponse<string>();
            try
            {
                var categoryToDelete = await Task.Run(() => _categoryRepository.GetCategoryById(id));
                if (categoryToDelete == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Category not found.";
                }
                else
                {
                    await Task.Run(() => _categoryRepository.DeleteCategory(id));
                    response.Data = "Category deleted successfully.";
                    response.Success = true;
                    response.Message = "Category deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCategoryDTO>> UpdateCategoryStatus(int id, int status)
        {
            var response = new DataResponse<ResponseCategoryDTO>();
            try
            {
                var category = await Task.Run(() => _categoryRepository.GetCategoryById(id));
                if (category == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Category not found.";
                }
                else
                {
                    await Task.Run(() => _categoryRepository.UpdateCategoryStatus(id, status));
                    var updatedCategory = await Task.Run(() => _categoryRepository.GetCategoryById(id));
                    response.Data = _mapper.Map<ResponseCategoryDTO>(updatedCategory);
                    response.Success = true;
                    response.Message = "Category status updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
