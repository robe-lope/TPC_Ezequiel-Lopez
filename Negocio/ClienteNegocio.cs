using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT * FROM Clientes WHERE Activo = 1");
                datos.EjecutarLectura();    
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public Cliente GetById(int id)
        {
            Cliente cliente = null;
            var ad = new AccesoDatos();
            ad.SetearConsulta("SELECT * FROM Clientes WHERE IdCliente = @id");
            ad.SetearParametro("@id", id);
            ad.EjecutarLectura();
            if (ad.Lector.Read())
            {
                cliente.IdCliente = (int)ad.Lector["IdCliente"];
                cliente.Nombre = (string)ad.Lector["Nombre"];
                cliente.Apellido = (string)ad.Lector["Apellido"];
                cliente.DNI = (string)ad.Lector["DNI"];
                cliente.Telefono = (string)ad.Lector["Telefono"];
                cliente.Email = (string)ad.Lector["Email"];
                cliente.Direccion = (string)ad.Lector["Direccion"];
                cliente.Activo = (bool)ad.Lector["Activo"];

            }
                
            ad.CerrarConexion();
            return cliente;
        }

        public void Agregar(Cliente c)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO Clientes (Nombre, Apellido, DNI, Telefono, Email, Direccion) " +
                                     "VALUES (@nombre, @apellido, @dni, @tel, @email, @dir)");
                datos.SetearParametro("@nombre", c.Nombre);
                datos.SetearParametro("@apellido", c.Apellido);
                datos.SetearParametro("@dni", c.DNI);
                datos.SetearParametro("@tel", c.Telefono ?? "");
                datos.SetearParametro("@email", c.Email ?? "");
                datos.SetearParametro("@dir", c.Direccion ?? "");
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(Cliente c)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Clientes SET Nombre=@nombre, Apellido=@apellido, DNI=@dni, " +
                                     "Telefono=@tel, Email=@email, Direccion=@dir WHERE IdCliente=@id");
                datos.SetearParametro("@nombre", c.Nombre);
                datos.SetearParametro("@apellido", c.Apellido);
                datos.SetearParametro("@dni", c.DNI);
                datos.SetearParametro("@tel", c.Telefono ?? "");
                datos.SetearParametro("@email", c.Email ?? "");
                datos.SetearParametro("@dir", c.Direccion ?? "");
                datos.SetearParametro("@id", c.IdCliente);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Clientes SET Activo=0 WHERE IdCliente=@id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Cliente> Buscar(string busqueda)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"SELECT * FROM Clientes 
                               WHERE Activo = 1 AND (
                               Nombre    LIKE @busqueda OR 
                               Apellido  LIKE @busqueda OR 
                               DNI       LIKE @busqueda)");
                datos.SetearParametro("@busqueda", "%" + busqueda + "%");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
        }


    }
}
