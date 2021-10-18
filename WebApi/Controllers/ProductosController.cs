using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProductosController : ApiController
    {
        private static readonly IDao<Producto> dao = DaoProducto.ObtenerDao();
        // GET: api/Productos
        public IEnumerable<Producto> Get()
        {
            IEnumerable<Producto> productos = dao.ObtenerTodos();
            foreach(var p in productos)
            {
                p.Categoria.Productos = null;
            }
            return productos;
        }

        // GET: api/Productos/5
        public IHttpActionResult Get(long id)
        {
            Producto producto = dao.ObtenerPorId(id);
            if(producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        // POST: api/Productos
        public IHttpActionResult Post([FromBody]Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            producto = dao.Insertar(producto);
            return Content(HttpStatusCode.Created, producto);
        }

        // PUT: api/Productos/5
        public IHttpActionResult Put(long id, [FromBody]Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != producto.Id)
            {
                return BadRequest();
            }
            producto = dao.Modificar(producto);
            return Ok(producto);
        }

        // DELETE: api/Productos/5
        public IHttpActionResult Delete(long id)
        {
            Producto producto = dao.ObtenerPorId(id);
            if(producto == null)
            {
                return NotFound();
            }
            dao.Borrar(id);
            return StatusCode(HttpStatusCode.NoContent);

        }
    }
}
