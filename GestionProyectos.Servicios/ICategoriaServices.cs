using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public interface ICategoriaServices
    {
        Task<List<CategoriaResponse>> GetCategorias();

        Task<bool> CreateCategoria(CategoriaRequest categoria);

        Task<bool> UpdateCategoria(CategoriaRequest categoria);

        Task<bool> DeleteCategoria(CategoriaRequest categoria);



    }
}
