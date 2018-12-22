using BaseApi.Domain.ViewModels;

namespace BaseApi.Domain.Repositories.Interfaces
{
    public interface IRecordRepository<TEntity> : IQueryRepository<TEntity>
        where TEntity : Entities.Entity
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        void Delete(long id);
        void Delete(string id);
        void Delete(int id);
        void Delete(short id);

    }

    public interface IRecordRepository<TEntity, TQueryViewModel> : IRecordRepository<TEntity>, IQueryRepository<TEntity, TQueryViewModel>
        where TEntity : Entities.Entity
        where TQueryViewModel : QueryViewModel
    {

    }


}
