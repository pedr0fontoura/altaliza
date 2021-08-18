using System.ComponentModel.DataAnnotations;

namespace Altaliza.Domain.Dtos
{
    public class DeleteVehicleCategoryDto
    {
        [Required(ErrorMessage = "O id da categoria é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id da categoria deve ser válido")]
        public int Id { get; set; }

        // Here we could have something like if we want our delete method to be more secure

        // [Required(ErrorMessage = "Confirme o nome da categoria para removê-la")]
        // public string Name { get; set; }
    }
}
