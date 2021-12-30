using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.API.Infrastructure;
using Model.API;

namespace Database.API.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {

    }
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContextModel dbContextModel) : base(dbContextModel)
        {
        }
    }
}
