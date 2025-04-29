using SolvexShop.Core.Application.ViewModels.Products;
using SolvexShop.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.ViewModels.ProductVariations
{
    public class SaveProductVariationViewModel
    {
      
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El tipo de variación es obligatorio")]
        public VariationType Type { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El valor debe tener entre 1 y 100 caracteres")]
        public string Value { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El Id del producto es obligatorio")]
        public Guid ProductId { get; set; }

        public string ImagePath { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        public string Description { get; set; }

    }
}
