using AutoMapper.QueryableExtensions;
using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCodeFirst.Domain.Entities;
using TestCodeFirst.Domain.Repositories;
using TestCodeFirst.Domain.ViewModels;
using TestCodeFirst.Infra.Contexts;

namespace TestCodeFirst.Infra.Repositories
{
    public class ManyRepository : ImprovedRecordRepository<Many, ExempleForeignKeyContext>, IManyRepository
    {
        public ManyRepository(ExempleForeignKeyContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ManyQueryViewModel> ListCustomMany()
        {
            return _dbContext.Many.ProjectTo<ManyQueryViewModel>().ToList();
        }
    }
}
