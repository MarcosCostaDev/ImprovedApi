using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TestCodeFirst.Domain.Entities;
using TestCodeFirst.Domain.ViewModels;

namespace TestCodeFirst.Domain.Repositories
{
    public interface IManyRepository : IImprovedRecordRepository<Many>
    {
        IEnumerable<ManyQueryViewModel> ListCustomMany();
    }
}
