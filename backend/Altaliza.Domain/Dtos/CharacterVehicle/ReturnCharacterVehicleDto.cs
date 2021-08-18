using System.ComponentModel.DataAnnotations;

namespace Altaliza.Domain.Dtos
{
    public class ReturnCharacterVehicleDto
    {
        [Required(ErrorMessage = "O id do personagem é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do personagem deve ser válido")]
        public int CharacterId { get; set; }

        [Required(ErrorMessage = "O id do veículo de personagem é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do veículo de personagem deve ser válido")]
        public int CharacterVehicleId { get; set; }
    }
}
