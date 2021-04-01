using MMT_Test.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MMT_Test.Client
{
    public class MMT_Test_API
    {

        private readonly string _URL;
        private readonly HttpClient httpClient = new HttpClient();

        public MMT_Test_API(string URL)
        {
            this._URL = URL;
        }

        public List<Category> GetCategories()
        {
            var result = httpClient.GetStringAsync(_URL + "/api/Category").Result;
            return JsonSerializer.Deserialize<List<Category>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }

        public List<Product> GetCategoryProducts(int categoryId)
        {
            var result = httpClient.GetStringAsync(_URL + "/api/Category/" + categoryId.ToString() + "/products").Result;
            return JsonSerializer.Deserialize<List<Product>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }

        public List<Product> GetFeaturedProducts()
        {
            var result = httpClient.GetStringAsync(_URL + "/api/product/featured").Result;
            return JsonSerializer.Deserialize<List<Product>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }
}
