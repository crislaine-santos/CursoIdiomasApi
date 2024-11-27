using CursoIdiomasApi.Data;
using CursoIdiomasApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CursoIdiomasApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public AlunosController(ApiDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }

            return await _context.Alunos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }

           var aluno = await _context.Alunos.FindAsync(id);           

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Aluno>> PostAluno(AlunoDto alunoDto)
        {
            if (_context.Alunos == null)
            {
              return Problem("Erro ao criar um aluno, Contate o suporte!");
            }

             if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var aluno = new Aluno
            {
                Nome = alunoDto.Nome,
                Cpf = alunoDto.Cpf,
                Email = alunoDto.Email
            };

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id) return BadRequest();

            if(!ModelState.IsValid) return ValidationProblem(ModelState);

            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if(_context.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }        
    }
}
