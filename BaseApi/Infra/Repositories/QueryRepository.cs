using AutoMapper.QueryableExtensions;
using BaseApi.Domain.Repositories.Interfaces;
using BaseApi.Domain.ViewModels;
using BaseApi.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaseApi.Infra.Repositories
{
    public abstract class QueryRepository<TEntity, TDbContext> : IQueryRepository<TEntity>
        where TEntity : Domain.Entities.Entity
        where TDbContext : BaseDbContext
    {

        protected readonly TDbContext _dbContext;
        public QueryRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(long id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(short id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(string id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual BaseDbContext GetContext()
        {
            return _dbContext;
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }


        public virtual IEnumerable<TEntity> ListTracked()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

    }

    public abstract class QueryRepository<TEntity, TDbContext, TViewModel> : QueryRepository<TEntity, TDbContext>, IQueryRepository<TEntity, TViewModel>
        where TEntity : Domain.Entities.Entity
        where TViewModel : QueryViewModel
        where TDbContext : BaseDbContext
    {
        public QueryRepository(TDbContext dbContext) : base(dbContext)
        {
        }
        IEnumerable<TViewModel> IQueryRepository<TEntity, TViewModel>.ListViewModel()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ProjectTo<TViewModel>().ToList();
        }

    }
}
