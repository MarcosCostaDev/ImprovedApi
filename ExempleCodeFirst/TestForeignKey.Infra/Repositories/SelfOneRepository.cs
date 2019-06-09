using ImprovedApi.Infra.Repositories;
using System.Linq;
using TestCodeFirst.Domain.Entities;
using TestCodeFirst.Domain.Repositories;
using TestCodeFirst.Infra.Contexts;

namespace TestCodeFirst.Infra.Repositories
{
    public class SelfOneRepository : ImprovedRecordRepository<SelfOne, ExempleForeignKeyContext>, ISelfOneRepository
    {
        public SelfOneRepository(ExempleForeignKeyContext dbContext) : base(dbContext)
        {
        }

        public SelfOne Last()
        {
            return _dbContext.SelfOne
                .OrderByDescending(p => p.SelfOneID)
                       .FirstOrDefault();
        }
    }
}
