using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TestForeignKey.Domain.Entities;
using TestForeignKey.Domain.Repositories;
using TestForeignKey.Infra.Contexts;

namespace TestForeignKey.Infra.Repositories
{
    public class ToOneRepository : ImprovedRecordRepository<ToOne, ExempleForeignKeyContext>, IToOneRepository
    {
        public ToOneRepository(ExempleForeignKeyContext dbContext) : base(dbContext)
        {
        }
    }
}
