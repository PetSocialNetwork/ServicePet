﻿using Microsoft.EntityFrameworkCore;
using ServicePet.Domain.Interfaces;

namespace ServicePet.DataEntityFramework.Repositories
{
    public class EFRepository<TEntity> : IRepositoryEF<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;
        protected DbSet<TEntity> Entities => _dbContext.Set<TEntity>();
        public EFRepository(DbContext appDbContext)
        {
            _dbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public virtual async Task<TEntity> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleAsync(it => it.Id == id, cancellationToken);
        }
        public virtual async Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await Entities.ToListAsync(cancellationToken);
        }

        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken)
        {
            await Entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task Delete(TEntity entity, CancellationToken cancellationToken)
        {
            Entities.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            await Task.CompletedTask;
        }
        public virtual async Task DeleteRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            Entities.RemoveRange(entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
            await Task.CompletedTask;
        }
    }
}
