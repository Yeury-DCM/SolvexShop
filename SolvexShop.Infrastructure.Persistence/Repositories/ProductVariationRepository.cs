

using AutoMapper;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Domain.Entities;
using SolvexShop.Infrastructure.Persistence.Contexts;

namespace SolvexShop.Infrastructure.Persistence.Repositories
{
    public class ProductVariationRepository :BaseRepository<ProductVariation, Guid>, IProductVariationRepository
    {
        public ProductVariationRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
