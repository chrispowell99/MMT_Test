using MMT_Test.Common.Domain;
using MMT_Test.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT_Test.Common.Interfaces.Services
{
    public interface IProductService
    {
        List<Product> GetProducts(bool? featured = null, Category category = null);
    }
}
