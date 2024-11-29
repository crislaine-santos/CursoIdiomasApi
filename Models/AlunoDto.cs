using System.ComponentModel.DataAnnotations;

namespace CursoIdiomasApi.Models
{
    public class AlunoDto
    {
        public string? Nome { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string? Cpf { get; set; }

        [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
        public string? Email { get; set; }
        public int TurmaId { get; set; }
    }
}
