using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public interface IProductoServices
    {
        Task<List<ProductoResponse>> GetProductos();
        Task<List<ProductoResponse>> GetProductosForCategori();

        Task<List<ProductoResponse>> GetServices();

        Task<ProductoResponse> GetProducto(int id);

        Task<bool> CreateProducto(ProductoRequest productoRequest);

        Task<bool> UpdateProducto(ProductoRequest productoRequest);

        Task<bool> DeleteProducto(ProductoRequest productoRequest);
    }
}
