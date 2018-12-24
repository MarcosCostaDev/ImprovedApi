using Example.Domain.Entities;
using Example.Domain.Repository;
using Example.Infra.Context;
using ImprovedApi.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Infra.Repository
{
    public class AlbumRepository : ImprovedRecordRepository<Album, ExampleContext>, IAlbumRepository
    {
        public AlbumRepository(ExampleContext dbContext) : base(dbContext)
        {
        }
    }
}
