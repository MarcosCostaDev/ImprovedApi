using Flunt.Validations;
using ImprovedApi.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics;

namespace Example.Domain.Entities
{

    public class Artist : ImprovedEntity
    {
        public Artist(string name)
        {
            Update(name);
        }

        public void Update(string name)
        {
            var contract = new Contract();
            contract.IsNotNullOrEmpty(name, "Name", "Name must be informed!");
            AddNotifications(contract);
            Name = name;
        }

        public int ArtistId { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<Album> Albums { get; private set; }
    }
}
