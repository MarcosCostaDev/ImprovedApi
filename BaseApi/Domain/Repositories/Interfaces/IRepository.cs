using BaseApi.Infra.Contexts;

namespace BaseApi.Domain.Repositories.Interfaces
{
    public interface IRepository
    {
        BaseDbContext GetContext();
    }
}
