using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Features.Products.Commands.CreateProduct
{
    public class UpdateProductCommand : IRequest<Response<ProductDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
