using MMT_Test.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT_Test.Common.Interfaces.Services
{
    public interface ICategoryService
    {

        List<Category> GetCategories();

        Category GetCategoryById(int Id);
    }
}
