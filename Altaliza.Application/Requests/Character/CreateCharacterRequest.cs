using System.ComponentModel.DataAnnotations;

namespace Altaliza.Domain.Dtos
{
    public class CreateCharacterRequest
    {
        [Required(ErrorMessage = "O nome do personagem � obrigat�rio.")]
        [MinLength(0, ErrorMessage = "O nome do personagem n�o deve ser vazio.")]
        [MaxLength(50, ErrorMessage = "O nome do personagem deve ter no m�ximo 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O valor da carteira do personagem � obrigat�rio.")]
        [Range(0, float.MaxValue, ErrorMessage = "O valor da carteira n�o deve ser negativo.")]
        public float Wallet { get; set; }
    }
}