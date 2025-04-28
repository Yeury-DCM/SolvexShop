using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Dtos.ProductVariation
{
    public class BaseProductVariationDto
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
