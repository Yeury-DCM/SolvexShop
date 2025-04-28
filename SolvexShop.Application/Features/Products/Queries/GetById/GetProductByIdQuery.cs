using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Features.Products.Queries.GetById
{
    public class GetProductByIdQuery : IRequest<Response<ProductDto>>
    {
        public Guid Id { get; set; }
    }
}
