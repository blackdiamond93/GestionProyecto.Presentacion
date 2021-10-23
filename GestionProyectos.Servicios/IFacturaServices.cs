using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public interface IFacturaServices
    {
        Task<List<FacturaResponse>> GetFacturas();
        Task<List<DetalleResponse>> GetDetalles(int id);

        Task<int> CreateFactura(FacturaRequest facturaRequest);
        Task<bool> CreateDatalles(DetalleRequest facturaRequest);

        Task<bool> EditFactura(FacturaRequest facturaRequest);
        Task<bool> DeleteFactura(int id);
        

    }
}
