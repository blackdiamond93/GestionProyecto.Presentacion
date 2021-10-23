using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public interface IRolServices
    {
        Task<List<RolResponse>> GetCategorias();

        Task<bool> CreateCategoria(RolRequest rolRequest);

        Task<bool> UpdateCategoria(RolRequest rolRequest);

        Task<bool> DeleteCategoria(RolRequest rolRequest);
    }
}
