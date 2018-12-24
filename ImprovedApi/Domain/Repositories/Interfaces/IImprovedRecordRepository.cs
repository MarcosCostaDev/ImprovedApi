using ImprovedApi.Domain.ViewModels;

namespace ImprovedApi.Domain.Repositories.Interfaces
{
    public interface IImprovedRecordRepository<TEntity> : IImprovedQueryRepository<TEntity>
        where TEntity : Entities.ImprovedEntity
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        void Delete(long id);
        void Delete(string id);
        void Delete(int id);
        void Delete(short id);

    }

    public interface IImprovedRecordRepository<TEntity, TQueryViewModel> : IImprovedRecordRepository<TEntity>, IImprovedQueryRepository<TEntity, TQueryViewModel>
        where TEntity : Entities.ImprovedEntity
        where TQueryViewModel : ImprovedQueryViewModel
    {

    }


}
