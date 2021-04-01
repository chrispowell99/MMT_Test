using MMT_Test.Common.Domain;
using MMT_Test.Common.Interfaces.Data;
using MMT_Test.Common.Interfaces.Services;
using System.Collections.Generic;

namespace MMT_Test.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public List<Product> GetProducts(bool? featured = null,Category category = null)
        {
                return _unitOfWork.Product.GetAll(featured,category);
        }
    }
}
