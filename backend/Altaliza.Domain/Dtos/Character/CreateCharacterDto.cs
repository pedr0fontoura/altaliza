using System.ComponentModel.DataAnnotations;

namespace Altaliza.Domain.Dtos
{
    public class CreateCharacterDto
    {
        [Required(ErrorMessage = "O nome do personagem é obrigatório.")]
        [MinLength(0, ErrorMessage = "O nome do personagem não deve ser vazio.")]
        [MaxLength(50, ErrorMessage = "O nome do personagem deve ter no máximo 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O valor da carteira do personagem é obrigatório.")]
        [Range(0, float.MaxValue, ErrorMessage = "O valor da carteira não deve ser negativo.")]
        public float Wallet { get; set; }
    }
}
