using System.ComponentModel.DataAnnotations;

namespace CursoIdiomasApi.Models
{
    public class Turma
    {
        [Key]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nivel { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }

    }
}
