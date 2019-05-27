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
    public class ManyRepository : ImprovedRecordRepository<Many, ExempleForeignKeyContext>, IManyRepository
    {
        public ManyRepository(ExempleForeignKeyContext dbContext) : base(dbContext)
        {
        }
    }
}
