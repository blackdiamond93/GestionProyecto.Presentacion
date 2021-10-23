using GestionProyecto.Datos.Models;
using GestionProyecto.Models.Request;
using GestionProyecto.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyectos.Servicios
{
    public class FacturaServices : IFacturaServices
    {
        private readonly DBGestionContext _conn;
        public FacturaServices( DBGestionContext conn)
        {
            _conn = conn;
        }

        public async Task<bool> CreateDatalles(DetalleRequest facturaRequest)
        {

            using (_conn)
            {
                DetalleFactura detalle = new DetalleFactura();
                detalle.IdFactura = facturaRequest.IdFactura;
                detalle.IdProducto = facturaRequest.IdProducto;
                detalle.Cantidad = facturaRequest.Cantidad;
                detalle.Precio = facturaRequest.Precio;
                _conn.DetalleFacturas.Add(detalle);
                await _conn.SaveChangesAsync();
                if (detalle!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
                    
            
        }

        public async Task<int> CreateFactura(FacturaRequest facturaRequest)
        {
            using (_conn)
            {
                Factura factura = new Factura();
                factura.IdUsuario = facturaRequest.IdUsuario;
                factura.IdCliente = facturaRequest.IdCliente;
                factura.Fecha = facturaRequest.Fecha;
                factura.Total = facturaRequest.Total;
                factura.Iva = facturaRequest.Iva;
                factura.Descuento = facturaRequest.Descuento;
                _conn.Facturas.Add(factura);
                await _conn.SaveChangesAsync();
                
                if (factura!=null )
                {
                    return factura.IdFactura;
                }
                else
                {
                    return 0;
                }
            }
        }

        public async Task<bool> DeleteFactura(int id)
        {
            using (_conn)
            {
                Factura factura = _conn.Facturas.Find(id);
                factura.Estado = false;
                _conn.Entry(factura).State = EntityState.Modified;
                await _conn.SaveChangesAsync();
               
                if (factura != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> EditFactura(FacturaRequest facturaRequest)
        {
            using (_conn)
            {
                Factura factura = _conn.Facturas.Find(facturaRequest.IdFactura);
                factura.IdUsuario = facturaRequest.IdUsuario;
                factura.IdCliente = facturaRequest.IdCliente;
                factura.Fecha = facturaRequest.Fecha;
                factura.Total = facturaRequest.Total;
                factura.Iva = facturaRequest.Iva;
                factura.Descuento = facturaRequest.Descuento;
                _conn.Facturas.Add(factura);
                await _conn.SaveChangesAsync();
                
                
                if (factura != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<List<DetalleResponse>> GetDetalles(int id)
        {
            using (_conn)
            {
                var list = await (from f in _conn.DetalleFacturas
                                join p in _conn.Productos on f.IdProducto equals p.IdProducto
                                 select new DetalleResponse
                                 {
                                    IdDetalle = f.IdDetalle,
                                    Cantidad = f.Cantidad,
                                    Producto = p.Nombre,
                                    Precio = f.Precio
                                 }).ToListAsync();
                return list;
            }
        }

        public async Task<List<FacturaResponse>> GetFacturas()
        {
            using (_conn)
            {
                var list = await (from f in _conn.Facturas
                                  join u in _conn.Usuarios on f.IdUsuario equals u.IdUsuario
                                  join p in _conn.Personas on f.IdCliente equals p.IdUsuario
                                  select new FacturaResponse
                                  {
                                      IdFactura = f.IdFactura,
                                      Usuarios = u.Usuario1,
                                      Clientes = p.Nombre,
                                      Fecha = f.Fecha,
                                      Descuento = f.Descuento,
                                      Iva = f.Iva,
                                      Total = f.Total,
                                      Estado = f.Estado.Value
                                  }).ToListAsync();
                return list;
            }
        }
    }
}
