

namespace SolvexShop.Core.Domain.Base
{
    public abstract class BaseAuditableEntity<TId> : IAuditableEntity, IHasId<TId>
    {
        public TId Id { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DeletedBy { get; set; }
        public string DeletedAt { get; set; }
    } 
    
}
