using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TestForeignKey.Domain.Entities;
using TestForeignKey.Domain.ViewModels;

namespace TestForeignKey.Domain.Repositories
{
    public interface IToOneRepository : IImprovedRecordRepository<ToOne>
    {
    }
}
