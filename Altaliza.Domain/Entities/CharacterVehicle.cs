using System;

namespace Altaliza.Domain.Entities
{
    public class CharacterVehicle : BaseEntity
    {
        public int CharacterId { get; set; }

        public int VehicleCategoryId { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
