using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DaoCategoria : IDao<Categoria>
    {
        #region Singleton
        private DaoCategoria() { }
        private static readonly DaoCategoria dao = new DaoCategoria();
        public static DaoCategoria ObtenerDao()
        {
            return dao;
        }
        #endregion
        public void Borrar(long id)
        {
            using (var db = new EntityDataModel())
            {
                db.Categorias.Remove(db.Categorias.Find(id));
                db.SaveChanges();
            }
        }

        public Categoria Insertar(Categoria categoria)
        {
            using (var db = new EntityDataModel())
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return categoria;
            }
        }

        public Categoria Modificar(Categoria categoria)
        {
            using (var db = new EntityDataModel())
            {
                db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return categoria;
            }            
        }

        public Categoria ObtenerPorId(long id)
        {
            using (var db = new EntityDataModel())
            {
                return db.Categorias.Include("Productos").FirstOrDefault(p => p.Id == id);
            }
        }

        public IEnumerable<Categoria> ObtenerTodos()
        {
            using(var db = new EntityDataModel())
            {
                return db.Categorias.ToList();
            }                
        }
    }
}
