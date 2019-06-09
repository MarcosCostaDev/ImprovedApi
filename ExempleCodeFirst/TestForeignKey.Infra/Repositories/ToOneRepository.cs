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
    public class ToOneRepository : ImprovedRecordRepository<ToOne, ExempleForeignKeyContext>, IToOneRepository
    {
        public ToOneRepository(ExempleForeignKeyContext dbContext) : base(dbContext)
        {
        }
    }
}
