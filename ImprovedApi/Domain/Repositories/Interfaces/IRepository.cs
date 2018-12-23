using ImprovedApi.Infra.Contexts;

namespace ImprovedApi.Domain.Repositories.Interfaces
{
    public interface IRepository
    {
        ImprovedDbContext GetContext();
    }
}
