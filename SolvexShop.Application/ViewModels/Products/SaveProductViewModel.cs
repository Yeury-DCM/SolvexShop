

using System.ComponentModel.DataAnnotations;

namespace SolvexShop.Core.Application.ViewModels.Products
{
    public class SaveProductViewModel
    {
        [Required(ErrorMessage = "El ID es requerido")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
    }
}
