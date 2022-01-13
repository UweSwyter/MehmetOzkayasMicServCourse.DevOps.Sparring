using Shopping.Client.Infrastructure.Extensions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Client.Services
{
    public class ProductServices : IProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetAllProductsResponse> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("/api/products", cancellationToken);

            return await response.ReadContentAs<GetAllProductsResponse>();
        }
    }
}