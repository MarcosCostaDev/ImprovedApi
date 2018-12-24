using ImprovedApi.Infra.Contexts;

namespace ImprovedApi.Domain.Repositories.Interfaces
{
    public interface IImprovedRepository
    {
        ImprovedDbContext GetContext();
    }
}
