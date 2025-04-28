using SolvexShop.Core.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Dtos.ProductVariation
{
    public class ProductVariationDto : BaseProductVariationDto
    {
        public ProductDto Product { get; set; }
    }
}
