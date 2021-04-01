using MMT_Test.Common.Domain;
using MMT_Test.Data.MMTShop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMT_Test.Data
{
    public static class SimpleMapper
    {

        public static T Map<T, T2>(T2 entity)
        {
            try
            {
                switch (entity)
                {
                    case tProduct tProduct:
                        return (T)(object)new Product()
                        {
                            Id = tProduct.Id,
                            Description = tProduct.Description,
                            Name = tProduct.Name,
                            SKU = tProduct.Sku,
                           Price = tProduct.Price
                        };
                    case tCategory tCategory:
                        return (T)(object)new Category()
                        {
                            Id = tCategory.Id,
                            Name = tCategory.Name
                        };
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                return default;
            }

            return default;
        }

        public static List<T> Map<T, T2>(List<T2> entityList)
        {
            return entityList.Select(entity => Map<T, T2>(entity)).ToList();
        }



    }
}
