using Shopping.Client.Models;
using System.Collections.Generic;

namespace Shopping.Client.Services
{
    public record GetAllProductsResponse(IEnumerable<Product> Products);
}
