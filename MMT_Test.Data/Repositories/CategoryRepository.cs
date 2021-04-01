using MMT_Test.Common.Domain;
using MMT_Test.Data.MMTShop;
using MMT_Test.Domain;
using MMT_Test.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MMT_Test.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository 
    {
        private readonly MMTShopContext _context;

        public CategoryRepository(MMTShopContext context)
        {
            this._context = context;
        }

        public override List<Category> GetAll()
        {
            var categoryId = new SqlParameter("categoryId", DBNull.Value);
            var categories = _context.Categories.FromSqlRaw("Execute dbo.GetCategories @categoryId", categoryId);
            return SimpleMapper.Map<Category, tCategory>(categories.ToList());
        }

        public override Category GetById(int Id)
        {
            var categoryId = new SqlParameter("categoryId", Id);
            var category = _context.Categories.FromSqlRaw("Execute dbo.GetCategories  @categoryId",categoryId);
            return SimpleMapper.Map<Category, tCategory>(category.ToList().FirstOrDefault());
        }
    }
}
