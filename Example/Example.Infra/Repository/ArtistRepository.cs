using Example.Domain.Entities;
using Example.Domain.Repository;
using Example.Infra.Context;
using ImprovedApi.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Infra.Repository
{
    public class ArtistRepository : ImprovedRecordRepository<Artist, ExampleContext>, IArtistRepository
    {
        public ArtistRepository(ExampleContext dbContext) : base(dbContext)
        {
        }

        public Artist GetByName(string name)
        {
            return _dbContext.Artist.FirstOrDefault(p => p.Name == name);
        }
    }
}
