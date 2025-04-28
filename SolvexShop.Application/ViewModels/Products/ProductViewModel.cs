

using SolvexShop.Core.Application.ViewModels.ProductVariations;
using SolvexShop.Core.Domain.Entities;

namespace SolvexShop.Core.Application.ViewModels.Products
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductVariationViewModel> ProductVariations { get; set; }
    }
}
