using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DaoProducto : IDaoProducto
    {
        #region Singleton
        private DaoProducto() { }
        private static readonly DaoProducto dao = new DaoProducto();
        public static DaoProducto ObtenerDao()
        {
            return dao;
        }
        #endregion
        public void Borrar(long id)
        {
            using (var db = new EntityDataModel())
            {
                db.Productos.Remove(db.Productos.Find(id));
                db.SaveChanges();
            }
        }

        public Producto Insertar(Producto producto)
        {
            using (var db = new EntityDataModel())
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return producto;
            }
        }

        public Producto Modificar(Producto producto)
        {
            using (var db = new EntityDataModel())
            {
                if (producto.CategoriaId != producto.Categoria?.Id)
                {
                    producto.Categoria = db.Categorias.Find(producto.CategoriaId);
                }

                db.Entry(producto.Categoria).State = System.Data.Entity.EntityState.Unchanged;



                db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return producto;
            }            
        }

        public Producto ObtenerPorId(long id)
        {
            using (var db = new EntityDataModel())
            {
                return db.Productos.Include("Categoria").FirstOrDefault(p => p.Id == id);
            }
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            using(var db = new EntityDataModel())
            {
                return db.Productos.Include("Categoria").ToList();
            }                
        }

        public IEnumerable<Producto> ObtenerPorNombre(string nombre)
        {
            using (var db = new EntityDataModel())
            {
                return db.Productos.Include("Categoria").Where(p => p.Nombre.Contains(nombre)).ToList();
            }
        }

     
    }
}
