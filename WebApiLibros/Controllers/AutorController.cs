using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Contexto;
using WebApiLibros.Entidades;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public AutorController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET /api/autor
        [HttpGet]
        public List<Autor> Get()
        {
            return _context.Autores.ToList();
        }

        // GET /api/autor/id
        [HttpGet("{id}", Name = "ObtenerAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var resultado = _context.Autores.FirstOrDefault(x => x.Id == id);
            if (resultado == null)
            {
                return NotFound();
            }
            return resultado;
        }

        // POST /api/autor
        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new
            {
                id = autor.Id
            }, autor);
        }


        // PUT /api/autor
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value)
        {
            if (id != value.Id)
            {
                BadRequest();
            }
            _context.Entry(value).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }


        // DELETE /api/autor
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var resultado = _context.Autores.FirstOrDefault(x => x.Id ==
            id);
            if (resultado == null)
            {
                return NotFound();
            }
            _context.Autores.Remove(resultado);
            _context.SaveChanges();
            return resultado;
        }



    }
}
