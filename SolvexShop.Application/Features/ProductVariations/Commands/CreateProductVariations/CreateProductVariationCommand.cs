
using MediatR;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Response;
using SolvexShop.Core.Domain.Entities;
using SolvexShop.Core.Domain.Enums;

namespace SolvexShop.Core.Application.Features.ProductVariations.Commands.CreateProductVariations
{
    public class CreateProductVariationCommand : IRequest<Response<ProductVariationDto>>
    {
        public VariationType Type { get; set; }
        public string Value { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
