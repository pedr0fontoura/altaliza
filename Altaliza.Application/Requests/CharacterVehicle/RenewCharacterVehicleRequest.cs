using System.ComponentModel.DataAnnotations;
using Altaliza.Domain.Enums;

namespace Altaliza.Application.Requests
{
    public class RenewCharacterVehicleRequest
    {
        [Required(ErrorMessage = "O tempo de aluguel é obrigatório")]
        public RentTime RentTime { get; set; }
    }
}
