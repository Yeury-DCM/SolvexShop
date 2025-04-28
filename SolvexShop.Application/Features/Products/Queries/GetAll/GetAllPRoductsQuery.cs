
using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Response;

namespace SolvexShop.Core.Application.Features.Products.Queries.GetAll
{
    public class GetAllPRoductsQuery : IRequest<Response<List<ProductDto>>>
    {
    }
}
