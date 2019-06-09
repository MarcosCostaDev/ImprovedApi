using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TestCodeFirst.Domain.Entities;
using TestCodeFirst.Domain.Repositories;
using TestCodeFirst.Infra.Contexts;

namespace TestCodeFirst.Infra.Repositories
{
    public class OneRepository : ImprovedRecordRepository<One, ExempleForeignKeyContext>, IOneRepository
    {
        public OneRepository(ExempleForeignKeyContext dbContext) : base(dbContext)
        {
        }
    }
}
