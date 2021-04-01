using MMT_Test.Common.Domain;
using MMT_Test.Common.Interfaces.Data;
using MMT_Test.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT_Test.API.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public List<Category>GetCategories()
        {
            return _unitOfWork.Category.GetAll();
        }

        public Category GetCategoryById(int Id)
        {
            return _unitOfWork.Category.GetById(Id);
        }
    }
}
