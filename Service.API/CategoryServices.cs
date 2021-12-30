using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.API;
using Database.API.Repository;
using Database.API.Infrastructure;

namespace Service.API
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int Id);
        Task<Category> Update(Category category);
        Task<bool> Delete(int Id);

        Task<Category> DeleteConfirm(Category category);

        Task<Category> Add(Category category);

    }
    public class CategoryServices : ICategoryServices
    {
        private ICategoryRepository _categoryRepository;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> Add(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int Id)
        {
            Category getById = await GetById(Id);
            if(getById != null)
            {
                _categoryRepository.Delete(getById);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
           return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int Id)
        {
            Category category = await _categoryRepository.GetById(Id);
            if(category != null)
            {
                return category;
            }
            throw new NotImplementedException();
        }

        public async Task<Category> Update(Category category)
        {
            Category getById = await GetById(category.Id);
            if(getById != null)
            {
                _categoryRepository.Update(category);
                return getById;
            }
            throw new NotImplementedException();
        }

        public async Task<Category> DeleteConfirm(Category category)
        {
            //  return await _categoryRepository.Delete(category);
            throw new Exception();
        }
    }
}
