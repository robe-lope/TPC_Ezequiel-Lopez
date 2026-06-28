using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class OrdenDeTrabajoNegocio
    {
        public List<OrdenDeTrabajo> Listar()
        {
            List<OrdenDeTrabajo> lista = new List<OrdenDeTrabajo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    SELECT o.*, 
                           e.Descripcion AS DescEstado,
                           v.Patente, v.Marca AS MarcaVehiculo, v.Modelo,
                           c.Nombre AS NombreCliente, c.Apellido AS ApellidoCliente, c.Email AS EmailCliente,
                           m.Nombre AS NombreMecanico, m.Apellido AS ApellidoMecanico
                    FROM OrdenesDeTrabajo o
                    INNER JOIN EstadosOT e ON o.IdEstado = e.IdEstado
                    INNER JOIN Vehiculos v ON o.IdVehiculo = v.IdVehiculo
                    INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                    INNER JOIN Usuarios m ON o.IdMecanico = m.IdUsuario
                    ORDER BY o.FechaIngreso DESC");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                    lista.Add(MapearOT(datos));
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public List<OrdenDeTrabajo> ListarPorMecanico(int idMecanico)
        {
            List<OrdenDeTrabajo> lista = new List<OrdenDeTrabajo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    SELECT o.*, 
                           e.Descripcion AS DescEstado,
                           v.Patente, v.Marca AS MarcaVehiculo, v.Modelo,
                           c.Nombre AS NombreCliente, c.Apellido AS ApellidoCliente, c.Email AS EmailCliente,
                           m.Nombre AS NombreMecanico, m.Apellido AS ApellidoMecanico
                    FROM OrdenesDeTrabajo o
                    INNER JOIN EstadosOT e ON o.IdEstado = e.IdEstado
                    INNER JOIN Vehiculos v ON o.IdVehiculo = v.IdVehiculo
                    INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                    INNER JOIN Usuarios m ON o.IdMecanico = m.IdUsuario
                    WHERE o.IdMecanico = @idMecanico
                    ORDER BY o.FechaIngreso DESC");
                datos.SetearParametro("@idMecanico", idMecanico);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                    lista.Add(MapearOT(datos));
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public OrdenDeTrabajo GetById(int idOrden)
        {
            OrdenDeTrabajo ot = null;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    SELECT o.*, 
                           e.Descripcion AS DescEstado,
                           v.Patente, v.Marca AS MarcaVehiculo, v.Modelo,
                           c.Nombre AS NombreCliente, c.Apellido AS ApellidoCliente, c.Email AS EmailCliente,
                           m.Nombre AS NombreMecanico, m.Apellido AS ApellidoMecanico
                    FROM OrdenesDeTrabajo o
                    INNER JOIN EstadosOT e ON o.IdEstado = e.IdEstado
                    INNER JOIN Vehiculos v ON o.IdVehiculo = v.IdVehiculo
                    INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                    INNER JOIN Usuarios m ON o.IdMecanico = m.IdUsuario
                    WHERE o.IdOrden = @id");
                datos.SetearParametro("@id", idOrden);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                    ot = MapearOT(datos);
                return ot;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public int Agregar(OrdenDeTrabajo ot)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    INSERT INTO OrdenesDeTrabajo 
                        (FechaIngreso, FechaEstimada, Descripcion, KilometrajeIngreso, IdEstado, IdVehiculo, IdMecanico, IdUsuarioCreador)
                    VALUES 
                        (@fecha, @fechaEst, @desc, @km, 1, @vehiculo, @mecanico, @creador);
                    SELECT SCOPE_IDENTITY();");
                datos.SetearParametro("@fecha", ot.FechaIngreso);
                datos.SetearParametro("@fechaEst", ot.FechaEstimada.HasValue ? (object)ot.FechaEstimada.Value : DBNull.Value);
                datos.SetearParametro("@desc", ot.Descripcion);
                datos.SetearParametro("@km", ot.KilometrajeIngreso);
                datos.SetearParametro("@vehiculo", ot.Vehiculo.IdVehiculo);
                datos.SetearParametro("@mecanico", ot.Mecanico.IdUsuario);
                datos.SetearParametro("@creador", ot.UsuarioCreador.IdUsuario);
                return datos.EjecutarAccionScalar();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public void CambiarEstado(int idOrden, int idEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE OrdenesDeTrabajo SET IdEstado=@estado WHERE IdOrden=@id");
                datos.SetearParametro("@estado", idEstado);
                datos.SetearParametro("@id", idOrden);
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }
        public void Reabrir(int idOrden)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"UPDATE OrdenesDeTrabajo 
                               SET IdEstado=2, FechaCierre=NULL 
                               WHERE IdOrden=@id");
                datos.SetearParametro("@id", idOrden);
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public void Cerrar(int idOrden)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"UPDATE OrdenesDeTrabajo 
                                       SET IdEstado=4, FechaCierre=@fecha 
                                       WHERE IdOrden=@id");
                datos.SetearParametro("@fecha", DateTime.Now);
                datos.SetearParametro("@id", idOrden);
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public void AgregarLinea(LineaOT linea)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    INSERT INTO LineasOT (IdOrden, TipoLinea, IdServicio, IdRepuesto, Cantidad, PrecioUnitario)
                    VALUES (@orden, @tipo, @servicio, @repuesto, @cantidad, @precio)");
                datos.SetearParametro("@orden", linea.IdOrden);
                datos.SetearParametro("@tipo", linea.TipoLinea);
                datos.SetearParametro("@servicio", linea.Servicio != null ? (object)linea.Servicio.IdServicio : DBNull.Value);
                datos.SetearParametro("@repuesto", linea.Repuesto != null ? (object)linea.Repuesto.IdRepuesto : DBNull.Value);
                datos.SetearParametro("@cantidad", linea.Cantidad);
                datos.SetearParametro("@precio", linea.PrecioUnitario);
                datos.EjecutarAccion();

                // Si es repuesto, descontamos cant del stock
                // TODO: El que devuelva
                if (linea.TipoLinea == "Repuesto" && linea.Repuesto != null)
                {
                    datos = new AccesoDatos();
                    datos.SetearConsulta("UPDATE Repuestos SET StockActual = StockActual - @cantidad WHERE IdRepuesto = @id");
                    datos.SetearParametro("@cantidad", linea.Cantidad);
                    datos.SetearParametro("@id", linea.Repuesto.IdRepuesto);
                    datos.EjecutarAccion();
                }
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }
        public void EliminarLinea(int idLinea)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearProcedimiento("sp_EliminarLineaOT");
                datos.SetearParametro("@idLinea", idLinea);
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public List<LineaOT> ListarLineas(int idOrden)
        {
            List<LineaOT> lista = new List<LineaOT>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    SELECT l.*, 
                           s.Descripcion AS DescServicio,
                           r.Descripcion AS DescRepuesto, r.Codigo
                    FROM LineasOT l
                    LEFT JOIN Servicios s ON l.IdServicio = s.IdServicio
                    LEFT JOIN Repuestos r ON l.IdRepuesto = r.IdRepuesto
                    WHERE l.IdOrden = @idOrden");
                datos.SetearParametro("@idOrden", idOrden);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    LineaOT linea = new LineaOT();
                    linea.IdLinea = (int)datos.Lector["IdLinea"];
                    linea.IdOrden = (int)datos.Lector["IdOrden"];
                    linea.TipoLinea = (string)datos.Lector["TipoLinea"];
                    linea.Cantidad = (int)datos.Lector["Cantidad"];
                    linea.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];

                    if (linea.TipoLinea == "Servicio")
                    {
                        linea.Servicio = new Servicio();
                        linea.Servicio.IdServicio = (int)datos.Lector["IdServicio"];
                        linea.Servicio.Descripcion = (string)datos.Lector["DescServicio"];
                    }
                    else
                    {
                        linea.Repuesto = new Repuesto();
                        linea.Repuesto.IdRepuesto = (int)datos.Lector["IdRepuesto"];
                        linea.Repuesto.Descripcion = (string)datos.Lector["DescRepuesto"];
                        linea.Repuesto.Codigo = (string)datos.Lector["Codigo"];
                    }
                    lista.Add(linea);
                }
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        private OrdenDeTrabajo MapearOT(AccesoDatos datos)
        {
            OrdenDeTrabajo ot = new OrdenDeTrabajo();
            ot.IdOrden = (int)datos.Lector["IdOrden"];
            ot.FechaIngreso = (DateTime)datos.Lector["FechaIngreso"];
            ot.FechaEstimada = datos.Lector["FechaEstimada"] is DBNull ? (DateTime?)null : (DateTime)datos.Lector["FechaEstimada"];
            ot.FechaCierre = datos.Lector["FechaCierre"] is DBNull ? (DateTime?)null : (DateTime)datos.Lector["FechaCierre"];
            ot.Descripcion = (string)datos.Lector["Descripcion"];
            ot.KilometrajeIngreso = (int)datos.Lector["KilometrajeIngreso"];
            ot.Estado = new EstadoOT
            {
                IdEstado = (int)datos.Lector["IdEstado"],
                Descripcion = (string)datos.Lector["DescEstado"]
            };
            ot.Vehiculo = new Vehiculo
            {
                IdVehiculo = (int)datos.Lector["IdVehiculo"],
                Patente = (string)datos.Lector["Patente"],
                Marca = (string)datos.Lector["MarcaVehiculo"],
                Modelo = (string)datos.Lector["Modelo"]
            };
            ot.Vehiculo.Cliente = new Cliente
            {
                Nombre = (string)datos.Lector["NombreCliente"],
                Apellido = (string)datos.Lector["ApellidoCliente"],
                Email = (string)datos.Lector["EmailCliente"]
            };
            ot.Mecanico = new Usuario
            {
                IdUsuario = (int)datos.Lector["IdMecanico"],
                Nombre = (string)datos.Lector["NombreMecanico"],
                Apellido = (string)datos.Lector["ApellidoMecanico"]
            };
            return ot;
        }
        public List<OrdenDeTrabajo> Filtrar(int idEstado)
        {
            List<OrdenDeTrabajo> lista = new List<OrdenDeTrabajo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
            SELECT o.*, 
                   e.Descripcion AS DescEstado,
                   v.Patente, v.Marca AS MarcaVehiculo, v.Modelo,
                   c.Nombre AS NombreCliente, c.Apellido AS ApellidoCliente, c.Email AS EmailCliente,
                   m.Nombre AS NombreMecanico, m.Apellido AS ApellidoMecanico
            FROM OrdenesDeTrabajo o
            INNER JOIN EstadosOT e ON o.IdEstado = e.IdEstado
            INNER JOIN Vehiculos v ON o.IdVehiculo = v.IdVehiculo
            INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
            INNER JOIN Usuarios m ON o.IdMecanico = m.IdUsuario
            WHERE o.IdEstado = @idEstado
            ORDER BY o.FechaIngreso DESC");
                datos.SetearParametro("@idEstado", idEstado);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                    lista.Add(MapearOT(datos));
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }
    }
}
