using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Order.Dtos;

namespace Order.Service
{
    public class ProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Product");

                HttpResponseMessage response = await client.GetAsync("/api/Product/get-all-products");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return new List<ProductDto>();
                }

                string apiContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(apiContent))
                {
                    Console.WriteLine("Error: Empty response from API.");
                    return new List<ProductDto>();
                }

                var resp = JsonSerializer.Deserialize<IEnumerable<ResponseDto>>(apiContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (resp != null && resp.Any(r => r.IsSuccess && r.Result != null))
                {
                    var result = resp.First(r => r.IsSuccess && r.Result != null).Result;
                    return JsonSerializer.Deserialize<IEnumerable<ProductDto>>(result.ToString(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<ProductDto>();
                }

                return new List<ProductDto>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Error: {ex.Message}");
                return new List<ProductDto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                return new List<ProductDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                return new List<ProductDto>();
            }
        }

        public async Task<bool> AddProduct(ProductDto productDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Product");

                var content = new StringContent(JsonSerializer.Serialize(productDto), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/Product", content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error adding product: {response.StatusCode} - {response.ReasonPhrase}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                return false;
            }
        }

    }
}
