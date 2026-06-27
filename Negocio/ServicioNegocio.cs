using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Negocio
{
    public class ServicioNegocio
    {
        public List<Servicio> Listar()
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"SELECT s.*, t.Descripcion AS DescTipo
                                       FROM Servicios s
                                       INNER JOIN TiposServicio t ON s.IdTipoServicio = t.IdTipoServicio
                                       WHERE s.Activo = 1");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Servicio aux = new Servicio();
                    aux.IdServicio = (int)datos.Lector["IdServicio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.PrecioBase = (decimal)datos.Lector["PrecioBase"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.TipoServicio = new TipoServicio();
                    aux.TipoServicio.IdTipoServicio = (int)datos.Lector["IdTipoServicio"];
                    aux.TipoServicio.Descripcion = (string)datos.Lector["DescTipo"];
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

        public void Agregar(Servicio s)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO Servicios (Descripcion, PrecioBase, IdTipoServicio) " +
                                     "VALUES (@desc, @precio, @tipo)");
                datos.SetearParametro("@desc", s.Descripcion);
                datos.SetearParametro("@precio", s.PrecioBase);
                datos.SetearParametro("@tipo", s.TipoServicio.IdTipoServicio);
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

        public void Modificar(Servicio s)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Servicios SET Descripcion=@desc, PrecioBase=@precio, " +
                                     "IdTipoServicio=@tipo WHERE IdServicio=@id");
                datos.SetearParametro("@desc", s.Descripcion);
                datos.SetearParametro("@precio", s.PrecioBase);
                datos.SetearParametro("@tipo", s.TipoServicio.IdTipoServicio);
                datos.SetearParametro("@id", s.IdServicio);
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
                datos.SetearConsulta("UPDATE Servicios SET Activo=0 WHERE IdServicio=@id");
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
    }
}
