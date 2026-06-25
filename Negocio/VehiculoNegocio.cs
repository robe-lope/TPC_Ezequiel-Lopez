using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VehiculoNegocio
    {
        public List<Vehiculo> Listar()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"SELECT v.*, c.Nombre AS NombreCliente, c.Apellido AS ApellidoCliente
                                       FROM Vehiculos v
                                       INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                                       WHERE v.Activo = 1");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(Mapear(datos));
                }
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public List<Vehiculo> ListarPorCliente(int idCliente)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"SELECT v.*, c.Nombre AS NombreCliente, c.Apellido AS ApellidoCliente
                                       FROM Vehiculos v
                                       INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                                       WHERE v.IdCliente = @idCliente AND v.Activo = 1");
                datos.SetearParametro("@idCliente", idCliente);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(Mapear(datos));
                }
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public void Agregar(Vehiculo v)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"INSERT INTO Vehiculos (Patente, Marca, Modelo, Anio, Color, Kilometraje, IdCliente)
                                       VALUES (@patente, @marca, @modelo, @anio, @color, @km, @idCliente)");
                datos.SetearParametro("@patente", v.Patente);
                datos.SetearParametro("@marca", v.Marca);
                datos.SetearParametro("@modelo", v.Modelo);
                datos.SetearParametro("@anio", v.Anio);
                datos.SetearParametro("@color", v.Color ?? "");
                datos.SetearParametro("@km", v.Kilometraje);
                datos.SetearParametro("@idCliente", v.Cliente.IdCliente);
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public void Modificar(Vehiculo v)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"UPDATE Vehiculos SET Patente=@patente, Marca=@marca, Modelo=@modelo,
                                       Anio=@anio, Color=@color, Kilometraje=@km WHERE IdVehiculo=@id");
                datos.SetearParametro("@patente", v.Patente);
                datos.SetearParametro("@marca", v.Marca);
                datos.SetearParametro("@modelo", v.Modelo);
                datos.SetearParametro("@anio", v.Anio);
                datos.SetearParametro("@color", v.Color ?? "");
                datos.SetearParametro("@km", v.Kilometraje);
                datos.SetearParametro("@id", v.IdVehiculo);
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Vehiculos SET Activo=0 WHERE IdVehiculo=@id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }

        private Vehiculo Mapear(AccesoDatos datos)
        {
            Vehiculo v = new Vehiculo();
            v.IdVehiculo = (int)datos.Lector["IdVehiculo"];
            v.Patente = (string)datos.Lector["Patente"];
            v.Marca = (string)datos.Lector["Marca"];
            v.Modelo = (string)datos.Lector["Modelo"];
            v.Anio = (int)datos.Lector["Anio"];
            v.Color = (string)datos.Lector["Color"];
            v.Kilometraje = (int)datos.Lector["Kilometraje"];
            v.Activo = (bool)datos.Lector["Activo"];
            v.Cliente = new Cliente();
            v.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
            v.Cliente.Nombre = (string)datos.Lector["NombreCliente"];
            v.Cliente.Apellido = (string)datos.Lector["ApellidoCliente"];
            return v;
        }
    }
}
