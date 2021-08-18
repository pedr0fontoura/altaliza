using System.ComponentModel.DataAnnotations;
using Altaliza.Domain.Enums;

namespace Altaliza.Application.Dtos
{
    public class RenewCharacterVehicleRequestDto
    {
        [Required(ErrorMessage = "O tempo de aluguel � obrigat�rio")]
        public RentTime RentTime { get; set; }
    }
}
