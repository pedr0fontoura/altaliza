using System.ComponentModel.DataAnnotations;

namespace Altaliza.Application.Requests
{
    public class UpdateVehicleCategoryRequest
    {
        [Required(ErrorMessage = "O nome da categoria � obrigat�rio")]
        [MinLength(3, ErrorMessage = "O nome da categoria deve ter entre 3 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome da categoria deve ter entre 3 e 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descri��o da categoria � obrigat�ria")]
        [MinLength(3, ErrorMessage = "A descri��o da categoria deve ter entre 3 e 500 caracteres")]
        [MaxLength(100, ErrorMessage = "A descri��o da categoria deve ter entre 3 e 500 caracteres")]
        public string Description { get; set; }
    }
}
