using System;
using Altaliza.Domain.Entities;

namespace Altaliza.Application.ViewModels
{
    public class CharacterVehicleViewModel
    {
        public int Id { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
