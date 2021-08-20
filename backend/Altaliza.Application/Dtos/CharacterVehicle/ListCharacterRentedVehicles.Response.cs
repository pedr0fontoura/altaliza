using System;
using Altaliza.Domain.Entities;

namespace Altaliza.Application.Dtos
{
    public class ListCharacterRentedVehiclesResponse
    {
        public int Id { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
