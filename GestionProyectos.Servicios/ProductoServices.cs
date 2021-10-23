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
    public class ProductoServices : IProductoServices
    {
        private readonly DBGestionContext _conn;
        public ProductoServices(DBGestionContext conn)
        {
            _conn = conn;
        }
        public async Task<bool> CreateProducto(ProductoRequest productoRequest)
        {
            using (_conn)
            {
                Producto producto = new Producto();
                producto.IdCategoria = productoRequest.IdCategoria;
                producto.Nombre = productoRequest.Nombre;
                producto.Descripcion = productoRequest.Descripcion;
                await _conn.Productos.AddAsync(producto);
                if (_conn.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteProducto(ProductoRequest productoRequest)
        {
            using (_conn)
            {
                var producto = await _conn.Productos.FindAsync(productoRequest.IdProducto);
                producto.IdCategoria = productoRequest.IdCategoria;
                producto.Nombre = productoRequest.Nombre;
                producto.Descripcion = productoRequest.Descripcion;
                _conn.Entry(producto).State = EntityState.Modified;
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

        public async Task<ProductoResponse> GetProducto(int id)
        {
            using (_conn)
            {
                var productos = await(from p in _conn.Productos
                                      join c in _conn.Categoria on p.IdCategoria equals c.IdCategoria
                                      join r in _conn.Precios on p.IdProducto equals r.IdProducto
                                      where p.Estado == true & p.IdProducto ==id
                                      select new ProductoResponse
                                      {
                                          IdProducto = p.IdProducto,
                                          Nombre = p.Nombre,
                                          Categoria = c.Descripcion,
                                          Descripcion = p.Descripcion,
                                          Precio = (r.Precio1.Value + Iva.GetIva(r.Precio1.Value))

                                      }).FirstOrDefaultAsync();

                return productos;
            }
        }

        public async Task<List<ProductoResponse>> GetProductos()
        {
            using (_conn)
            {
                var productos = await (from p in _conn.Productos
                                       join c in _conn.Categoria on p.IdCategoria equals  c.IdCategoria
                                       join r in _conn.Precios on p.IdProducto equals r.IdProducto 
                                       where p.Estado ==true 
                                        select new ProductoResponse
                                        {
                                           IdProducto = p.IdProducto,
                                           Nombre = p.Nombre,
                                           Categoria = c.Descripcion,
                                           Descripcion = p.Descripcion,
                                           Precio = (r.Precio1.Value+ Iva.GetIva(r.Precio1.Value))
                                          
                                        }).ToListAsync();

                return productos;
            }
        }

        public async Task<List<ProductoResponse>> GetProductosForCategori()
        {
            using (_conn)
            {
                var productos = await(from p in _conn.Productos
                                      join c in _conn.Categoria on p.IdCategoria equals c.IdCategoria
                                      where p.Estado == true & p.IdCategoria == 1 | p.IdCategoria == 2
                                      join r in _conn.Precios on p.IdProducto equals r.IdProducto
                                      select new ProductoResponse
                                      {
                                          IdProducto = p.IdProducto,
                                          Nombre = p.Nombre,
                                          Categoria = c.Descripcion,
                                          Descripcion = p.Descripcion,
                                          Precio = (r.Precio1.Value + Iva.GetIva(r.Precio1.Value))
                                      }).ToListAsync();

                return productos;
            }
        }

        public async Task<List<ProductoResponse>> GetServices()
        {
            using (_conn)
            {
                var productos = await(from p in _conn.Productos
                                      join c in _conn.Categoria on p.IdCategoria equals c.IdCategoria
                                      where p.Estado == true & p.IdCategoria == 3
                                      join r in _conn.Precios on p.IdProducto equals r.IdProducto
                                      select new ProductoResponse
                                      {
                                          IdProducto = p.IdProducto,
                                          Nombre = p.Nombre,
                                          Categoria = c.Descripcion,
                                          Descripcion = p.Descripcion,
                                          Precio = (r.Precio1.Value + Iva.GetIva(r.Precio1.Value))
                                      }).ToListAsync();

                return productos;
            }
        }

        public async Task<bool> UpdateProducto(ProductoRequest productoRequest)
        {
            using (_conn)
            {
                var producto = await _conn.Productos.FindAsync(productoRequest.IdProducto);
                producto.IdCategoria = productoRequest.IdCategoria;
                producto.Nombre = productoRequest.Nombre;
                producto.Descripcion = productoRequest.Descripcion;
                _conn.Entry(producto).State = EntityState.Modified;
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
