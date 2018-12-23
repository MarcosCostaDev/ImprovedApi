using Example.Domain.Entities;
using ImprovedApi.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ImprovedApi.Infra.Repositories;
using Example.Infra.Context;
using Example.Domain.Repository;

namespace Example.Infra.Repository
{
    public class CategoryRepository : RecordRepository<Category, ExampleContext>, ICategoryRepository
    {
        public CategoryRepository(ExampleContext dbContext) : base(dbContext)
        {
        }
    }
}
