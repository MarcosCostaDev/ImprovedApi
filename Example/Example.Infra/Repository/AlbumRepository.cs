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
    public class AlbumRepository : ImprovedRecordRepository<Album, ExampleContext>, IAlbumRepository
    {
        public AlbumRepository(ExampleContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Album> GetAlbumsByArtist(int artistId)
        {
           return _dbContext.Album.Where(p => p.ArtistId == artistId).ToList();
        }
    }
}
