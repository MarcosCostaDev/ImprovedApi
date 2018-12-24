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
    public abstract class ImprovedQueryRepository<TEntity, TDbContext> : IImprovedQueryRepository<TEntity>
        where TEntity : Domain.Entities.ImprovedEntity
        where TDbContext : ImprovedDbContext
    {

        protected readonly TDbContext _dbContext;
        public ImprovedQueryRepository(TDbContext dbContext)
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

        public virtual ImprovedDbContext GetContext()
        {
            return _dbContext;
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> ListPaged(int page, int pageSize)
        {
            return _dbContext.Set<TEntity>().AsQueryable().GetPaged(page, pageSize).Results;
        }

        public virtual IEnumerable<TEntity> ListTracked()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

    }

    public abstract class ImprovedQueryRepository<TEntity, TDbContext, TViewModel> : ImprovedQueryRepository<TEntity, TDbContext>, IImprovedQueryRepository<TEntity, TViewModel>
        where TEntity : Domain.Entities.ImprovedEntity
        where TViewModel : ImprovedQueryViewModel
        where TDbContext : ImprovedDbContext
    {
        public ImprovedQueryRepository(TDbContext dbContext) : base(dbContext)
        {
        }
        IEnumerable<TViewModel> IImprovedQueryRepository<TEntity, TViewModel>.ListViewModel()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ProjectTo<TViewModel>().ToList();
        }

    }
}
