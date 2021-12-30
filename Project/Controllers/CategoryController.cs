using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        [Route("Category/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Category> categories = await _categoryServices.GetAll();
            return Ok(categories);
        }

        [HttpGet]
        [Route("Category/GetById")]
        public async Task<Category> GetById(int Id)
        {
            Category category = await _categoryServices.GetById(Id);
            return category;
        }

        [HttpGet]
        [Route("Category/Add")]
        public async Task<Category> Add(Category category)
        {
            Category category1 = await _categoryServices.Add(category);
            return category1;
        }

        [HttpGet]
        [Route("Category/Update")]
        public async Task<Category> Update(Category category)
        {
            Category category1 = await _categoryServices.Update(category);
            return category1;
        }

        //[HttpGet]
        //[Route("Category/Delete")]
        //public async Task<IActionResult> Delete(int Id)
        //{
        //    var deleteCategory = await _categoryServices.Delete(Id);
        //    if(deleteCategory != null)
        //    {
        //        _categoryServices.
        //    }

        //}
    }
}
