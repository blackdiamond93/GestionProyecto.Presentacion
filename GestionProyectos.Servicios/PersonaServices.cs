using GestionProyecto.Datos.Models;
using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public class PersonaServices : IPersonaServices
    {
        private readonly DBGestionContext _conn;
        public PersonaServices(DBGestionContext conn)
        {
            _conn = conn;
        }
        public async Task<bool> CreatePersona(PersonaRequest personaRequest)
        {
            using (_conn)
            {
                Persona persona = new Persona();
                persona.Nombre = personaRequest.Nombre;
                persona.Apellido = personaRequest.Apellido;
                persona.Direcccion = personaRequest.Direccion;
                persona.Sexo = personaRequest.Sexo;
                persona.IdUsuario = personaRequest.IdUsuario;
                await _conn.Personas.AddAsync(persona);
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

        public async Task<bool> DeletePersona(PersonaRequest personaRequest)
        {
            using (_conn)
            {
                var persona = await _conn.Personas.FindAsync(personaRequest.IdUsuario);
                persona.Nombre = personaRequest.Nombre;
                persona.Apellido = personaRequest.Apellido;
                persona.Direcccion = personaRequest.Direccion;
                persona.Sexo = personaRequest.Sexo;
                persona.IdUsuario = personaRequest.IdUsuario;
                _conn.Entry(persona).State = EntityState.Modified;
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

        public async Task<PersonaResponse> GetPersona(int id)
        {
            using (_conn)
            {
                var persona = await (from p in _conn.Personas
                                     join u in _conn.Usuarios on p.IdUsuario equals u.IdUsuario
                                     where p.IdUsuario==id
                                     select new PersonaResponse
                                     {
                                         IdPersona = p.IdPersona,
                                         usuario = u.Usuario1,
                                         Nombre = p.Nombre,
                                         Apellido = p.Apellido,
                                         Direcccion = p.Direcccion,
                                         Sexo = p.Sexo

                                     }).FirstOrDefaultAsync();

                return persona;
            }
        }

        public async Task<List<PersonaResponse>> GetPersonas()
        {
            using (_conn)
            {
                var persona = await(from p in _conn.Personas
                                    join u in _conn.Usuarios on p.IdUsuario equals u.IdUsuario
                                       select new PersonaResponse
                                       {
                                          IdPersona = p.IdPersona,
                                          usuario=u.Usuario1,
                                          Nombre=p.Nombre,
                                          Apellido = p.Apellido,
                                          Direcccion = p.Direcccion,
                                          Sexo = p.Sexo

                                       }).ToListAsync();

                return persona;
            }
        }

        public async Task<bool> UpdatePersona(PersonaRequest personaRequest)
        {
            using (_conn)
            {
                var persona = await _conn.Personas.FindAsync(personaRequest.IdUsuario);
                if (persona!=null)
                {
                    persona.Nombre = personaRequest.Nombre;
                    persona.Apellido = personaRequest.Apellido;
                    persona.Direcccion = personaRequest.Direccion;
                    persona.Sexo = personaRequest.Sexo;
                    persona.IdUsuario = personaRequest.IdUsuario;
                    _conn.Entry(persona).State = EntityState.Modified;
                    if (_conn.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
