using System.ComponentModel.DataAnnotations;

namespace Altaliza.Application.Requests
{
    public class UpdateVehicleCategoryRequest
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome da categoria deve ter entre 3 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome da categoria deve ter entre 3 e 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição da categoria é obrigatória")]
        [MinLength(3, ErrorMessage = "A descrição da categoria deve ter entre 3 e 500 caracteres")]
        [MaxLength(100, ErrorMessage = "A descrição da categoria deve ter entre 3 e 500 caracteres")]
        public string Description { get; set; }
    }
}
