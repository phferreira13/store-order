using Microsoft.Extensions.Configuration;
using order.service.domain.Dtos;
using order.service.domain.Interfaces.HttpClients;
using System.Text.Json;

namespace order.service.http.HttpClients
{
    public class WarehouseHttpClient : IWarehouseHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public WarehouseHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["WarehouseApi:BaseUrl"];
        }

        public async Task<IEnumerable<WarehouseDto>> GetWarehousesAsync()
        {
            // Call the warehouse API to get all warehouses
            // and return the result
            var endpoint = $"{_baseUrl}/api/warehouses";
            var response = await _httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var warehouses = JsonSerializer.Deserialize<IEnumerable<WarehouseDto>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return warehouses;

        }
    }
}
