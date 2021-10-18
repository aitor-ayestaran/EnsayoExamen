using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class CategoriasController : ApiController
    {
        private static readonly IDao<Categoria> dao = DaoCategoria.ObtenerDao();
        // GET: api/Categorias
        public IEnumerable<Categoria> Get()
        {
            return dao.ObtenerTodos();       
        }

        // GET: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult Get(long id)
        {
            Categoria categoria = dao.ObtenerPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        // POST: api/Categorias
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult Post([FromBody]Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            categoria = dao.Insertar(categoria);
            return Content(HttpStatusCode.Created, categoria);
        }

        // PUT: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult Put(long id, [FromBody]Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }
            categoria = dao.Modificar(categoria);
            return Ok(categoria);
        }

        // DELETE: api/Categorias/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult Delete(long id)
        {
            Categoria categoria = dao.ObtenerPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            dao.Borrar(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
