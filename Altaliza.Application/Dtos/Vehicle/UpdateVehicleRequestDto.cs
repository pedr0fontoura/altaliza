using System.ComponentModel.DataAnnotations;

namespace Altaliza.Application.Dtos
{
    public class UpdateVehicleRequestDto
    {
        [Required(ErrorMessage = "O id da categoria do ve�culo � obrigat�rio")]
        [Range(1, int.MaxValue, ErrorMessage = "O id da categoria deve ser v�lido")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O nome do ve�culo � obrigat�rio")]
        [MinLength(3, ErrorMessage = "O nome do ve�culo deve ter entre 3 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome do ve�culo deve ter entre 3 e 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O estoque do ve�culo � obrigat�rio")]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque do ve�culo deve ser um valor positivo")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "A url da imagem do ve�culo � obrigat�ria")]
        [MinLength(3, ErrorMessage = "A url da imagem do ve�culo deve ter entre 3 e 256 caracteres")]
        [MaxLength(256, ErrorMessage = "A url da imagem do ve�culo deve ter entre 3 e 256 caracteres")]
        public string Image { get; set; }

        [Required(ErrorMessage = "O pre�o do aluguel de 1 dia � obrigat�rio")]
        [Range(0, float.MaxValue, ErrorMessage = "O pre�o de aluguel deve ser um valor positivo")]
        public float Rent1Day { get; set; }

        [Required(ErrorMessage = "O pre�o do aluguel de 7 dias � obrigat�rio")]
        [Range(0, float.MaxValue, ErrorMessage = "O pre�o de aluguel deve ser um valor positivo")]
        public float Rent7Day { get; set; }

        [Required(ErrorMessage = "O pre�o do aluguel de 15 dias � obrigat�rio")]
        [Range(0, float.MaxValue, ErrorMessage = "O pre�o de aluguel deve ser um valor positivo")]
        public float Rent15Day { get; set; }
    }
}
