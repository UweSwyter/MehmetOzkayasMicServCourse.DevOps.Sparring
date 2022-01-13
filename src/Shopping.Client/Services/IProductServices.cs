using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Client.Services
{
    public interface IProductServices
    {
        Task<GetAllProductsResponse> GetAllProductsAsync(CancellationToken cancellationToken);
    }
}