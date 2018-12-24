using Flunt.Validations;
using ImprovedApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Example.Domain.Entities
{
    public class Album : ImprovedEntity
    {
        public Album(string title, int artistId)
        {
            var contract = new Contract();
            contract.IsNotNullOrEmpty(title, "Title", "Title must be informed!");
            contract.IsLowerOrEqualsThan(artistId, 0, "ArtistId", "ArtistId must be informed!");
            AddNotifications(contract);
            Title = title;
            ArtistId = artistId;
        }

        public int AlbumId { get; private set; }

        
        public string Title { get; private set; }

        
        public int ArtistId { get; private set; }

        
        public Artist Artist { get; private set; }
    }
}