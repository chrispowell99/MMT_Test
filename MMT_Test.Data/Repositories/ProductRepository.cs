using MMT_Test.Common.Domain;
using MMT_Test.Data.MMTShop;
using MMT_Test.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MMT_Test.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository 
    {
        private readonly MMTShopContext _context;

        public ProductRepository(MMTShopContext context)
        {
            this._context = context;
        }

        public override List<Product> GetAll()
        {
            return GetAll(null, null);
            // return SimpleMapper.Map<Product, tProduct>(_context.Products.ToList());
        }

        public List<Product> GetAll(bool? isFeatured = null, Category category = null)
        {

            var categoryId = new SqlParameter("categoryId", category != null ? category.Id.ToString() : DBNull.Value);
            var featuredParam = new SqlParameter("featured", isFeatured != null? isFeatured.Value : DBNull.Value);
            var products = _context.Products.FromSqlRaw("Execute dbo.GetProducts @categoryId, @featured", categoryId, featuredParam);
            return SimpleMapper.Map<Product, tProduct>(products.ToList());

            //var query = _context.Products.AsQueryable();

            //if (featured.HasValue)
            //{
            //    query = query.Where(p => p.Featured == featured.Value);
            //}

            //if (category != null)
            //{
            //    query = query.Where(p => p.CategoryId == category.Id);
            //}

            //return SimpleMapper.Map<Product, tProduct>(query.ToList());
        }

        public override Product GetById(int Id)
        {
            var tProduct = _context.Products.Where(p => p.Id == Id).FirstOrDefault();
            if (tProduct != null)
            {
                return SimpleMapper.Map<Product, tProduct>(tProduct);
            }
            else
            {
                return null;
            }
        }
    }
}
