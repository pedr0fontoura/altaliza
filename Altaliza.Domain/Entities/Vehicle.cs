using System.Collections.Generic;

namespace Altaliza.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public VehicleCategory Category { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public float Rent1Day { get; set; }

        public float Rent7Day { get; set; }

        public float Rent15Day { get; set; }

        public List<CharacterVehicle> CharactersVehicles { get; set; }
    }
}
