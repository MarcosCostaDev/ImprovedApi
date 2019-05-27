using ImprovedApi.Infra.Repositories;
using System.Linq;
using TestForeignKey.Domain.Entities;
using TestForeignKey.Domain.Repositories;
using TestForeignKey.Infra.Contexts;

namespace TestForeignKey.Infra.Repositories
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
