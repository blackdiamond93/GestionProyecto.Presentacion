using GestionProyecto.Datos.Models;
using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public class RolServices : IRolServices
    {
        private readonly DBGestionContext _conn;
        public RolServices(DBGestionContext conn)
        {
            _conn = conn;
        }
        public async Task<bool> CreateCategoria(RolRequest rolRequest)
        {
            using (_conn)
            {
                Rol rol = new Rol();
                rol.Descripcion = rolRequest.Descripcion;
                await _conn.Rols.AddAsync(rol);
                if (_conn.SaveChanges() <0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteCategoria(RolRequest rolRequest)
        {
            //Codigo mientras se actualiza
            using (_conn)
            {
                var rol = await _conn.Rols.FindAsync(rolRequest.Id);
                rol.Descripcion = rolRequest.Descripcion;
                _conn.Entry(rol).State = EntityState.Modified;
                if (_conn.SaveChanges() <0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<List<RolResponse>> GetCategorias()
        {
            using (_conn)
            {
                var rols = await(from c in _conn.Rols
                                 where c.Estado ==true
                                       select new RolResponse
                                       {
                                           Id = c.IdRol,
                                           Descripcion = c.Descripcion

                                       }).ToListAsync();

                return rols;
            }
        }

        public async Task<bool> UpdateCategoria(RolRequest rolRequest)
        {
            using (_conn)
            {
                var rol = await _conn.Rols.FindAsync(rolRequest.Id);
                rol.Descripcion = rolRequest.Descripcion;
                _conn.Entry(rol).State = EntityState.Modified;
                if (_conn.SaveChanges() <0)
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
