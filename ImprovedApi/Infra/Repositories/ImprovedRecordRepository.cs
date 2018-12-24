
using AutoMapper.QueryableExtensions;
using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Domain.ViewModels;
using ImprovedApi.Infra.Contexts;
using ImprovedApi.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace ImprovedApi.Infra.Repositories
{
    public abstract class ImprovedRecordRepository<TEntity, TDbContext> : ImprovedQueryRepository<TEntity, TDbContext>, IImprovedRecordRepository<TEntity>
        where TEntity : Domain.Entities.ImprovedEntity
        where TDbContext : ImprovedDbContext
    {
        public ImprovedRecordRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        protected void SetEntityState(TEntity entity, EntityState entityState)
        {

            _dbContext.ChangeTracker.Entries<TEntity>().Any(p => p.SetEntityState(entityState));
        }

        public virtual void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            SetEntityState(entity, EntityState.Added);
        }

        public virtual void Delete(TEntity entity)
        {

            _dbContext.Set<TEntity>().Remove(entity);
            SetEntityState(entity, EntityState.Deleted);
        }
        public virtual void Edit(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            SetEntityState(entity, EntityState.Modified);
        }

        public virtual void Delete(long id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            SetEntityState(entity, EntityState.Deleted);
        }

        public virtual void Delete(string id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            SetEntityState(entity, EntityState.Deleted);
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            SetEntityState(entity, EntityState.Deleted);
        }

        public virtual void Delete(short id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            SetEntityState(entity, EntityState.Deleted);
        }

        public virtual void BulkDelete(IEnumerable<TEntity> entities)
        {
            entities = entities.Select(p => { SetEntityState(p, EntityState.Deleted); return p; });
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void BulkInsert(IEnumerable<TEntity> entities)
        {
            entities = entities.Select(p => { SetEntityState(p, EntityState.Added); return p; });
            _dbContext.Set<TEntity>().AddRange(entities);
        }
    }

    public abstract class ImprovedRecordRepository<TEntity, TDbContext, TQueryViewModel> : ImprovedRecordRepository<TEntity, TDbContext>, IImprovedRecordRepository<TEntity, TQueryViewModel>
       where TEntity : Domain.Entities.ImprovedEntity
       where TDbContext : ImprovedDbContext
        where TQueryViewModel : ImprovedQueryViewModel
    {
        public ImprovedRecordRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        public virtual IEnumerable<TQueryViewModel> ListViewModel()
        {
            return _dbContext.Set<TEntity>().ProjectTo<TQueryViewModel>().ToList();
        }
    }

}
