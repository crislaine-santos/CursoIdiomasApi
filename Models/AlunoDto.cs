using System.ComponentModel.DataAnnotations;

namespace CursoIdiomasApi.Models
{
    public class AlunoDto
    {
        public string? Nome { get; set; }
        public int Cpf { get; set; }

        [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
        public string? Email { get; set; }
    }
}
