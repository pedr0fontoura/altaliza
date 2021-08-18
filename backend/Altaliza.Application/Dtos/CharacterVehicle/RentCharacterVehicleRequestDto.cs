using System.ComponentModel.DataAnnotations;
using Altaliza.Domain.Enums;

namespace Altaliza.Application.Dtos
{
    public class RentCharacterVehicleRequestDto
    {
        [Required(ErrorMessage = "O id do personagem é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do personagem deve ser válido")]
        public int CharacterId { get; set; }

        [Required(ErrorMessage = "O id do veículo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do veículo deve ser válido")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "O tempo de aluguel é obrigatório")]
        public RentTime RentTime { get; set; }
    }
}
