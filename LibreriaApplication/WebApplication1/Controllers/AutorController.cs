using Libreria.Context;
using Libreria.Modelos;
using Libreria.Repositorios.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AutorController : ControllerBase
    {        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        // Autores

        [HttpGet("getAutores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            return Ok(await _autorRepository.GetAllAsync());
        }

        [HttpGet("getAutor/{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _autorRepository.GetByIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        [HttpPost("postAutor")]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            await _autorRepository.InsertAsync(autor);
            return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
        }

        [HttpPut("putAutor/{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            try
            {
                await _autorRepository.UpdateAsync(autor);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("deleteAutor/{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            try
            {
                await _autorRepository.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

    
    }
}

