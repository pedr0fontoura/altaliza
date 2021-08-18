using System.ComponentModel.DataAnnotations;

namespace Altaliza.Application.Dtos
{
    public class UpdateVehicleRequestDto
    {
        [Required(ErrorMessage = "O id da categoria do veículo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id da categoria deve ser válido")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O nome do veículo é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome do veículo deve ter entre 3 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome do veículo deve ter entre 3 e 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O estoque do veículo é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque do veículo deve ser um valor positivo")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "A url da imagem do veículo é obrigatória")]
        [MinLength(3, ErrorMessage = "A url da imagem do veículo deve ter entre 3 e 256 caracteres")]
        [MaxLength(256, ErrorMessage = "A url da imagem do veículo deve ter entre 3 e 256 caracteres")]
        public string Image { get; set; }

        [Required(ErrorMessage = "O preço do aluguel de 1 dia é obrigatório")]
        [Range(0, float.MaxValue, ErrorMessage = "O preço de aluguel deve ser um valor positivo")]
        public float Rent1Day { get; set; }

        [Required(ErrorMessage = "O preço do aluguel de 7 dias é obrigatório")]
        [Range(0, float.MaxValue, ErrorMessage = "O preço de aluguel deve ser um valor positivo")]
        public float Rent7Day { get; set; }

        [Required(ErrorMessage = "O preço do aluguel de 15 dias é obrigatório")]
        [Range(0, float.MaxValue, ErrorMessage = "O preço de aluguel deve ser um valor positivo")]
        public float Rent15Day { get; set; }
    }
}
