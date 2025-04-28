using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Response;
using SolvexShop.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Features.Products.Commands.CreateProduct
{
    public class UpdateProductVariationCommand : IRequest<Response<ProductVariationDto>>
    {       
        public Guid Id { get; set; }
        public VariationType Type { get; set; }
        public string Value { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }

}
