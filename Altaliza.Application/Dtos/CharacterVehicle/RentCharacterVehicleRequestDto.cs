using System.ComponentModel.DataAnnotations;
using Altaliza.Domain.Enums;

namespace Altaliza.Application.Dtos
{
    public class RentCharacterVehicleRequestDto
    {
        [Required(ErrorMessage = "O id do personagem � obrigat�rio")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do personagem deve ser v�lido")]
        public int CharacterId { get; set; }

        [Required(ErrorMessage = "O id do ve�culo � obrigat�rio")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do ve�culo deve ser v�lido")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "O tempo de aluguel � obrigat�rio")]
        public RentTime RentTime { get; set; }
    }
}
