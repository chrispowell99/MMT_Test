using Microsoft.EntityFrameworkCore;
using MMT_Test.Common.Interfaces.Data;
using MMT_Test.Data.MMTShop;
using MMT_Test.Data.Repositories;
using MMT_Test.Domain.Interfaces.Data;
using System;

namespace MMT_Test.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        public UnitOfWork(string connectionString)
        {
            var contextOptions = new DbContextOptionsBuilder<MMTShopContext>().UseSqlServer(connectionString).Options;
            _MMTShopContext = new MMTShopContext(contextOptions);
        }

        private MMTShopContext _MMTShopContext;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        public ICategoryRepository Category
        {
            get
            {

                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new CategoryRepository(_MMTShopContext);
                }
                return _categoryRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {

                if (this._productRepository == null)
                {
                    this._productRepository = new ProductRepository(_MMTShopContext);
                }
                return _productRepository;
            }
        }

        public void Save()
        {
            //context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}

