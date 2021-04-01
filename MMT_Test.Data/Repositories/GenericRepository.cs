using MMT_Test.Data.MMTShop;
using MMT_Test.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Test.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
    {
        public abstract List<T> GetAll();

        public abstract T GetById(int Id);
    }
}
