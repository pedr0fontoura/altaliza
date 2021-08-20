using System.Collections.Generic;

namespace Altaliza.Domain.Entities
{
    public class VehicleCategory : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
