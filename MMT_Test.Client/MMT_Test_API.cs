using MMT_Test.Common.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

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
            var result = "";
            try
            {
                result = httpClient.GetStringAsync(_URL + "/api/Category").Result;
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
            return Deserialise<List<Category>>(result);
        }

        public List<Product> GetCategoryProducts(int categoryId)
        {
            var result = "";
            try
            {
                 result = httpClient.GetStringAsync(_URL + "/api/Category/" + categoryId.ToString() + "/products").Result;
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
            return Deserialise<List<Product>>(result);
        }

        public List<Product> GetFeaturedProducts()
        {
            var result = "";
            try
            {
                 result = httpClient.GetStringAsync(_URL + "/api/product/featured").Result;
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
            return Deserialise<List<Product>>(result);
        }

        private Exception HandleException(Exception ex)
        {
            if (ex.InnerException is HttpRequestException)
            {
                return new Exception("There was a problem retrieveing the results: " + ex.Message);
            }
            else
            {
                
                return new Exception("There was a problem connecting to the API.");
            }
        }

        private T Deserialise<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }
}
