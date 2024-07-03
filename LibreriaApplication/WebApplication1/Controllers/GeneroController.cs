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
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        // GET: api/Genero/Generos
        [HttpGet("getGeneros")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
            var generos = await _generoRepository.GetAllAsync();
            return Ok(generos);
        }

        [HttpGet("getGenero/{id}")]
        public async Task<ActionResult<Genero>> GetGenero(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            return Ok(genero);
        }

        // POST: api/Genero/Generos
        // Controlador GeneroController
        [HttpPost("postGenero")]
        public async Task<ActionResult<Genero>> PostGenero(Genero genero)
        {
            try
            {
                // Insertar el genero en la base de datos
                await _generoRepository.InsertAsync(genero);

                // Devolver el objeto genero con el Id generado
                return CreatedAtAction(nameof(GetGenero), new { id = genero.Id }, genero);
            }
            catch (Exception ex)
            {
                // Manejar errores adecuadamente en la práctica
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("deleteGenero/{id}")]
        public async Task<IActionResult> DeleteGenero(int id)
        {
            try
            {
                await _generoRepository.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

