using Example.Domain.Entities;
using ImprovedApi.Domain.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Example.Domain.Repository
{
  
    public interface IAlbumRepository : IImprovedRecordRepository<Album>
    {

    }
}