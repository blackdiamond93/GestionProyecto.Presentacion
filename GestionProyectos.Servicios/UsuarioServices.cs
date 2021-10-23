using GestionProyecto.Datos.Models;
using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using GestionProyecto.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly DBGestionContext _conn;
        
        public UsuarioServices(DBGestionContext conn)
        {
            _conn = conn;
        }
        public async Task<bool> CreateUsuario(UsuarioRequest usuario)
        {
            using (_conn)
            {
                Usuario user = new Usuario();
                user.Usuario1 = usuario.Usuario;
                user.Pass = Encrypt.GetSHA256(usuario.Password);
                user.IdRol = usuario.Rol;
                await _conn.Usuarios.AddAsync(user);
                if (await _conn.SaveChangesAsync()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> EditUsuario(UsuarioRequest usuario)
        {
            using (_conn)
            {
                Usuario user = new Usuario();
                user.Usuario1 = usuario.Usuario;
                user.Pass = Encrypt.GetSHA256(usuario.Password);
                user.IdRol = usuario.Rol;
                  _conn.Entry(user).State = EntityState.Modified;
                if ( await _conn.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<List<UsuariosResponse>> GetClient()
        {
            using (_conn)
            {
                var list = await(from u in _conn.Usuarios
                                 join p in _conn.Personas on u.IdUsuario equals p.IdUsuario
                                 join r in _conn.Rols on u.IdRol equals r.IdRol
                                 where u.Estado == true & r.IdRol==2
                                 select new UsuariosResponse
                                 {
                                     Id = u.IdUsuario,
                                     Nombre = p.Nombre,
                                     Usuarios = u.Usuario1,
                                     Rols = r.Descripcion
                                 }
                            ).ToListAsync();
                return list;
            }
        }

        public async Task<List<UsuariosResponse>> GetUsers()
        {
            using (_conn)
            {
                var list = await (from u in _conn.Usuarios
                            join p in _conn.Personas on u.IdUsuario equals p.IdUsuario
                            join r in _conn.Rols on u.IdRol equals r.IdRol
                            where u.Estado ==true
                            select new UsuariosResponse
                            {
                                Id = u.IdUsuario,
                                Nombre =p.Nombre,
                                Usuarios = u.Usuario1,
                                Rols = r.Descripcion
                            }
                            ).ToListAsync();
                return list;
            }
        }

        public async Task<List<UsuariosResponse>> GetVendor()
        {
            using (_conn)
            {
                var list = await(from u in _conn.Usuarios
                                 join p in _conn.Personas on u.IdUsuario equals p.IdUsuario
                                 join r in _conn.Rols on u.IdRol equals r.IdRol
                                 where u.Estado == true & u.IdRol == 1 | u.IdRol==3
                                 select new UsuariosResponse
                                 {
                                     Id = u.IdUsuario,
                                     Nombre = p.Nombre,
                                     Usuarios = u.Usuario1,
                                     Rols = r.Descripcion
                                 }
                            ).ToListAsync();
                return list;
            }
        }

        public async Task<UsuariosResponse> Login(UsuarioRequest usuario)
        {
            
            using (_conn)
            {
                string pass = Encrypt.GetSHA256(usuario.Password);
                var user = await (from u in _conn.Usuarios
                                  join r in _conn.Rols on u.IdRol equals r.IdRol
                                  where u.Usuario1 == usuario.Usuario && u.Pass == pass && u.Estado==true
                                  select new UsuariosResponse
                                  {
                                      Id = u.IdUsuario,
                                      Usuarios = u.Usuario1,
                                      Rols = r.Descripcion,
                                  }).FirstOrDefaultAsync();
                if (user!=null)
                {
                    
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> ResetPass(PassRequest passRequest)
        {
            using (_conn)
            {
                string pass = Encrypt.GetSHA256(passRequest.pass);
                var user = await _conn.Usuarios.FindAsync(passRequest.id);
                user.Pass = pass;
                _conn.Entry(user).State = EntityState.Modified;
                if ( await _conn.SaveChangesAsync()<0)
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
