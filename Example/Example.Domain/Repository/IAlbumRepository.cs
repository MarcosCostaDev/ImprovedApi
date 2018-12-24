using Example.Domain.Entities;
using ImprovedApi.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Example.Domain.Repository
{
  
    public interface IAlbumRepository : IImprovedRecordRepository<Album>
    {
        IEnumerable<Album> GetAlbumsByArtist(int artistId);
    }
}