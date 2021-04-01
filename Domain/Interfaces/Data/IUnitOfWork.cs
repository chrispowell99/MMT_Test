using MMT_Test.Domain.Interfaces.Data;

namespace MMT_Test.Common.Interfaces.Data
{
    public interface IUnitOfWork
    {

        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        void Save();

        void Dispose();

    }
}
