using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public interface IPersonaServices
    {
        Task<List<PersonaResponse>> GetPersonas();

        Task<PersonaResponse> GetPersona(int id);

        Task<bool> CreatePersona(PersonaRequest personaRequest);

        Task<bool> UpdatePersona(PersonaRequest personaRequest);

        Task<bool> DeletePersona(PersonaRequest personaRequest);
    }
}
