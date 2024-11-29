using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CursoIdiomasApi.Models
{
    public class Aluno
    {
        [Key]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]        
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
        public string? Email { get; set; }

        public virtual int TurmaId { get; set; }

        [JsonIgnore]
        public virtual Turma Turma { get; set; }

    }
}