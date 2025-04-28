
using SolvexShop.Core.Domain.Base;

namespace SolvexShop.Core.Domain.Entities
{
    public class Product : BaseAuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }

        //Navegation Property
        public ICollection<ProductVariation> ProductVariations { get; set; } = new List<ProductVariation>();

        public Product()
        {
            Id = Guid.NewGuid();    
        }
    }


    
}
