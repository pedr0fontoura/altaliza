using System;

namespace Altaliza.Domain.Entities
{
    public class CharacterVehicle : BaseEntity
    {
        public Character Character { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
