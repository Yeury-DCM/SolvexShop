

using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Domain.Entities;

namespace SolvexShop.Core.Application.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductVariationDto> ProductVariations { get; set; }
    }
}
