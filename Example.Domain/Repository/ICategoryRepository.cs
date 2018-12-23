using Example.Domain.Entities;
using ImprovedApi.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Repository
{
    public interface ICategoryRepository : IRecordRepository<Category>
    {
    }
}
