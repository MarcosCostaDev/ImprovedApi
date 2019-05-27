using ImprovedApi.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TestForeignKey.Domain.Entities;

namespace TestForeignKey.Domain.Repositories
{
    public interface IOneRepository : IImprovedRecordRepository<One>
    {
    }
}
