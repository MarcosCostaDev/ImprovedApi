using ImprovedApi.Domain.ViewModels;
using ImprovedApi.Infra.Contexts;
using System;
using System.Collections.Generic;

namespace ImprovedApi.Domain.Repositories.Interfaces
{
    public interface IQueryRepository<TEntity> : IRepository
        where TEntity : Entities.Entity

    {
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> ListTracked();

        TEntity GetById(string id);
        TEntity GetById(short id);
        TEntity GetById(int id);
        TEntity GetById(long id);

    }


    public interface IQueryRepository<TEntity, TQueryViewModel> : IQueryRepository<TEntity>
        where TEntity : Entities.Entity
        where TQueryViewModel : QueryViewModel

    {
        IEnumerable<TQueryViewModel> ListViewModel();
    }
}
