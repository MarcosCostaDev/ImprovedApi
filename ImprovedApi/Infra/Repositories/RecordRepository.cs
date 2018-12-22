
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
    public abstract class RecordRepository<TEntity, TDbContext> : QueryRepository<TEntity, TDbContext>, IRecordRepository<TEntity>
        where TEntity : Domain.Entities.Entity
        where TDbContext : BaseDbContext
    {
        public RecordRepository(TDbContext dbContext) : base(dbContext)
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
    }

    public abstract class RecordRepository<TEntity, TDbContext, TQueryViewModel> : RecordRepository<TEntity, TDbContext>, IRecordRepository<TEntity, TQueryViewModel>
       where TEntity : Domain.Entities.Entity
       where TDbContext : BaseDbContext
        where TQueryViewModel : QueryViewModel
    {
        public RecordRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        public virtual IEnumerable<TQueryViewModel> ListViewModel()
        {
            return _dbContext.Set<TEntity>().ProjectTo<TQueryViewModel>().ToList();
        }
    }

}
