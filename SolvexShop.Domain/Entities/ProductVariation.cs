
using SolvexShop.Core.Domain.Base;
using SolvexShop.Core.Domain.Enums;

namespace SolvexShop.Core.Domain.Entities
{
    public class ProductVariation : BaseAuditableEntity<Guid>
    {
        public VariationType Type { get; set; }
        public string Value { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        //Navegation properties
        public Product Product { get; set; }    

        public ProductVariation()
        {
            Id = Guid.NewGuid();
        }
    }

}
