using ImprovedApi.Domain.ViewModels;
using ImprovedApi.Infra.Contexts;
using System;
using System.Collections.Generic;

namespace ImprovedApi.Domain.Repositories.Interfaces
{
    public interface IImprovedQueryRepository<TEntity> : IImprovedRepository
        where TEntity : Entities.ImprovedEntity

    {
        IEnumerable<TEntity> List();

        IEnumerable<TEntity> ListPaged(int page, int pageSize);
        IEnumerable<TEntity> ListTracked();

        TEntity GetById(string id);
        TEntity GetById(short id);
        TEntity GetById(int id);
        TEntity GetById(long id);

    }


    public interface IImprovedQueryRepository<TEntity, TQueryViewModel> : IImprovedQueryRepository<TEntity>
        where TEntity : Entities.ImprovedEntity
        where TQueryViewModel : ImprovedQueryViewModel

    {
        IEnumerable<TQueryViewModel> ListViewModel();
    }
}
