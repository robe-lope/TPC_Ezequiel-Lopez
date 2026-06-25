using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PerfilNegocio
    {
        public List<Perfil> Listar()
        {
            List<Perfil> lista = new List<Perfil>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT * FROM Perfiles WHERE Activo = 1");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Perfil aux = new Perfil();
                    aux.IdPerfil = (int)datos.Lector["IdPerfil"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
