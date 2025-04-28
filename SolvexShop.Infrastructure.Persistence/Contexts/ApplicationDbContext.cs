

using Microsoft.EntityFrameworkCore;
using SolvexShop.Core.Application.Interfaces.Services;
using SolvexShop.Core.Domain.Base;
using SolvexShop.Core.Domain.Entities;

namespace SolvexShop.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region Entities
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Primary Keys
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductVariation>().HasKey(pv => pv.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<ProductVariation>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.ProductVariations)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region properties
            #region Product
            modelBuilder.Entity<ProductVariation>().Property(pv => pv.Price).HasPrecision(18, 2);
            #endregion
            #endregion

            #region AutoInclude
            modelBuilder.Entity<Product>().Navigation(p => p.ProductVariations).AutoInclude();
            #endregion


        }

        //Auditoría centralizada
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
          
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditableEntity &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var auditable = (IAuditableEntity)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    auditable.CreatedAt = DateTime.UtcNow;
                    auditable.CreatedBy = _currentUserService.UserId; 
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    auditable.UpdatedAt = DateTime.UtcNow;
                    auditable.UpdatedBy = _currentUserService.UserId;
                }
            }

            
            return await base.SaveChangesAsync(cancellationToken);
        }



    }
}
