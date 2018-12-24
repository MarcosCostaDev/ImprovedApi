using Flunt.Validations;
using ImprovedApi.Domain.Entities;
using System.Diagnostics;

namespace Example.Domain.Entities
{

    public class Artist : ImprovedEntity
    {
        public Artist(string name)
        {
            var contract = new Contract();
            contract.IsNotNullOrEmpty(name, "Name", "Name must be informed!");
            AddNotifications(contract);
            Name = name;
        }

        public int ArtistId { get; private set; }

        public string Name { get; private set; }
    }
}
