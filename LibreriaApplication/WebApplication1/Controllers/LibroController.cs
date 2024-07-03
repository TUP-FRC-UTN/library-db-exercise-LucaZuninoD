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
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;
       

        public LibroController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
          
        }

        // GET: api/Libreria/Libros
        [HttpGet("getLibros")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            return Ok(await _libroRepository.GetAllAsync());
        }

        // GET: api/Libreria/Libros/5
        [HttpGet("getLibro/{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro  = await _libroRepository.GetByIdAsync(id);
            if(libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        // POST: api/Libreria/Libros
        [HttpPost("postLibro")]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _libroRepository.InsertAsync(libro);
            return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
        }

        // PUT: api/Libreria/Libros/5
        [HttpPut("putLibro/{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if(libro.Id != id)
            {
                return BadRequest();
            }

            try
            {
                await _libroRepository.UpdateAsync(libro);
            }
            catch(KeyNotFoundException) 
            {
                return NotFound();            
            }

            return NoContent();
        }

        // DELETE: api/Libreria/Libros/5
        [HttpDelete("deleteLibro/{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            try
            {
                await _libroRepository.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

