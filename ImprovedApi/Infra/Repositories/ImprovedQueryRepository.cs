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
        protected bool _useDbQuery { get; set; } = false;

        public ImprovedQueryRepository(TDbContext dbContext, bool useDbQuery = false)
        {
            _dbContext = dbContext;
            _useDbQuery = useDbQuery;
        }

   
        public virtual TEntity GetById(int id)
        {
            return _useDbQuery ? _dbContext.Query<TEntity>().FirstOrDefault() : _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(long id)
        {
            return _useDbQuery ? _dbContext.Query<TEntity>().FirstOrDefault() : _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(short id)
        {
            return _useDbQuery ? _dbContext.Query<TEntity>().FirstOrDefault() : _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(string id)
        {
            return _useDbQuery ? _dbContext.Query<TEntity>().FirstOrDefault() : _dbContext.Set<TEntity>().Find(id);
        }

        public virtual ImprovedDbContext GetContext()
        {
            return _dbContext;
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _useDbQuery ? _dbContext.Query<TEntity>().AsNoTracking().ToList() : _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> ListPaged(int page, int pageSize)
        {
            return _useDbQuery ? _dbContext.Query<TEntity>().AsNoTracking().GetPaged(page, pageSize).Results : _dbContext.Set<TEntity>().AsQueryable().GetPaged(page, pageSize).Results;
        }

        public virtual IEnumerable<TEntity> ListTracked()
        {
            return _useDbQuery ? _dbContext.Query<TEntity>().ToList() : _dbContext.Set<TEntity>().ToList();
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
            return _useDbQuery ? _dbContext.Query<TEntity>().AsNoTracking().ProjectTo<TViewModel>().ToList() : _dbContext.Set<TEntity>().AsNoTracking().ProjectTo<TViewModel>().ToList();
        }

    }
}
