using MMT_Test.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Test.Domain.Interfaces.Data
{
   public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetAll(bool? featured = null, Category category = null);
    }
}
