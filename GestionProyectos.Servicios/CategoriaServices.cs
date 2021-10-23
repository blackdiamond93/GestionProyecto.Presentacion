using GestionProyecto.Datos.Models;
using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly DBGestionContext _conn;
        public CategoriaServices(DBGestionContext conn)
        {
            _conn = conn;
        }
        public async Task<bool> CreateCategoria(CategoriaRequest categoria)
        {
            using (_conn)
            {
                Categorium categorium = new Categorium();
                categorium.Descripcion = categoria.Descripcion;
                await _conn.Categoria.AddAsync(categorium);
                if (_conn.SaveChanges() >0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteCategoria(CategoriaRequest categoria)
        {
            //este codigo se actulizara para el borrado logico 
            using (_conn)
            {
                var categorium = await _conn.Categoria.FindAsync(categoria.Id);
                categorium.Descripcion = categoria.Descripcion;
                _conn.Entry(categorium).State = EntityState.Modified;
                if (_conn.SaveChanges() >0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

       
        public async Task<List<CategoriaResponse>> GetCategorias()
        {
            using (_conn)
            {
                var categorium = await (from c in _conn.Categoria
                                  where c.Estado == true
                                  select new CategoriaResponse
                                  {
                                      Id = c.IdCategoria,
                                      Descripcion = c.Descripcion

                                  }).ToListAsync();

                return categorium;
            }
        }

        public async Task<bool> UpdateCategoria(CategoriaRequest categoria)
        {
            using (_conn)
            {
                var categorium = await _conn.Categoria.FindAsync(categoria.Id);
                categorium.Descripcion = categoria.Descripcion;
                _conn.Entry(categorium).State = EntityState.Modified;
                if (_conn.SaveChanges() >0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
