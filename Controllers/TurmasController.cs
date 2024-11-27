using CursoIdiomasApi.Data;
using CursoIdiomasApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CursoIdiomasApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/turmas")]
    public class TurmasController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public TurmasController(ApiDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }

            return await _context.Turmas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Turma>> PostAluno(Turma turma)
        {
            if (_context.Turmas == null)
            {
                return Problem("Erro ao criar uma Turma, Contate o suporte!");
            }

            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTurma), new { id = turma.Id }, turma);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

    