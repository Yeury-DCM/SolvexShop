using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Domain.Base;
using SolvexShop.Core.Domain.Result;
using SolvexShop.Infrastructure.Persistence.Contexts;

namespace SolvexShop.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : class, IHasId<TId>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entities;
        private readonly IMapper _mapper;

        public BaseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _entities = context.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<OperationResult<TEntity>> AddAsync(TEntity entity)
        {
            var result = new OperationResult<TEntity>();

            try
            {
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();

                result.IsSuccess = true;
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Error guardando la entidad: {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult<TEntity>> DeleteAsync(TEntity entity)
        {
            var result = new OperationResult<TEntity>();

            try
            {
                if (entity is IAuditableEntity auditableEntity)
                {
                    auditableEntity.IsDeleted = true;
                    auditableEntity.DeletedAt = DateTime.UtcNow;                   

                    _entities.Update(entity);
                }
                else
                {
                    _entities.Remove(entity);
                }

                await _context.SaveChangesAsync();

                result.IsSuccess = true;
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Error eliminando la entidad: {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult<IQueryable<TEntity>>> GetAllAsync()
        {
            var result = new OperationResult<IQueryable<TEntity>>();

            try
            {
                var query =  _entities.AsQueryable();

                if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
                {
                    query = query.Where(e => !EF.Property<bool>(e, nameof(IAuditableEntity.IsDeleted)));
                }

             

                result.IsSuccess = true;
                result.Data = query;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Error obteniendo los registros: {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult<TEntity>> GetByIdAsync(TId id)
        {
            var result = new OperationResult<TEntity>();

            try
            {
                var entity = await _entities.FindAsync(id);

                if (entity == null || (entity is IAuditableEntity auditable && auditable.IsDeleted))
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Entidad no encontrada.";
                    return result;
                }

                result.IsSuccess = true;
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Error obteniendo el registro: {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult<TEntity>> UpdateAsync(TEntity entity)
        {
            var result = new OperationResult<TEntity>();

            try
            {
                TEntity entityToUpdate = await _entities.FindAsync(entity.Id);

                if (entityToUpdate == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Entidad no encontrada.";
                    return result;
                }

                _mapper.Map(entity, entityToUpdate);

                _entities.Update(entityToUpdate);
                await _context.SaveChangesAsync();

                result.IsSuccess = true;
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Error actualizando la entidad: {ex.Message}";
            }

            return result;
        }
    }
}
