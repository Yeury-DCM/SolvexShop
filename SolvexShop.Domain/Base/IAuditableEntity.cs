
namespace SolvexShop.Core.Domain.Base
{
    public interface IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedBy { get; set; }
        public string DeletedAt { get; set; }

    }
}
