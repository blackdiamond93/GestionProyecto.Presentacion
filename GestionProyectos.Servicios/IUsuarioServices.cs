using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public interface IUsuarioServices
    {
        Task<bool> CreateUsuario(UsuarioRequest usuario);
        Task<UsuariosResponse> Login(UsuarioRequest usuario);

        Task<bool> ResetPass(PassRequest passRequest);
        Task<List<UsuariosResponse>> GetUsers();

        Task<bool> EditUsuario(UsuarioRequest usuario);

        Task<List<UsuariosResponse>> GetClient();
        Task<List<UsuariosResponse>> GetVendor();

    }
}
