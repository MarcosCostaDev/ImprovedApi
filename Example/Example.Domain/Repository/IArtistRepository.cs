using Example.Domain.Entities;
using ImprovedApi.Domain.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Example.Domain.Repository
{
   
    public interface IArtistRepository : IImprovedRecordRepository<Artist>
    {
        Artist GetByName(string name);       
    }
}
