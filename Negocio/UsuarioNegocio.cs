using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"SELECT u.*, p.Descripcion AS DescPerfil 
                                       FROM Usuarios u
                                       INNER JOIN Perfiles p ON u.IdPerfil = p.IdPerfil
                                       WHERE u.Activo = 1");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Username = (string)datos.Lector["Username"];
                    aux.Password = (string)datos.Lector["Password"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Perfil = new Perfil();
                    aux.Perfil.IdPerfil = (int)datos.Lector["IdPerfil"];
                    aux.Perfil.Descripcion = (string)datos.Lector["DescPerfil"];
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

        public Usuario Login(string username, string password)
        {
            Usuario usuario = null;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"SELECT u.*, p.Descripcion AS DescPerfil 
                                       FROM Usuarios u
                                       INNER JOIN Perfiles p ON u.IdPerfil = p.IdPerfil
                                       WHERE u.Username = @user AND u.Password = @pass AND u.Activo = 1");
                datos.SetearParametro("@user", username);
                datos.SetearParametro("@pass", password);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Username = (string)datos.Lector["Username"];
                    usuario.Activo = (bool)datos.Lector["Activo"];
                    usuario.Perfil = new Perfil();
                    usuario.Perfil.IdPerfil = (int)datos.Lector["IdPerfil"];
                    usuario.Perfil.Descripcion = (string)datos.Lector["DescPerfil"];
                }
                return usuario;
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

        public void Agregar(Usuario u)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"INSERT INTO Usuarios (Nombre, Apellido, Email, Username, Password, IdPerfil)
                                       VALUES (@nombre, @apellido, @email, @user, @pass, @perfil)");
                datos.SetearParametro("@nombre", u.Nombre);
                datos.SetearParametro("@apellido", u.Apellido);
                datos.SetearParametro("@email", u.Email);
                datos.SetearParametro("@user", u.Username);
                datos.SetearParametro("@pass", u.Password);
                datos.SetearParametro("@perfil", u.Perfil.IdPerfil);
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

        public void Modificar(Usuario u)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"UPDATE Usuarios SET Nombre=@nombre, Apellido=@apellido, 
                                       Email=@email, Username=@user, IdPerfil=@perfil 
                                       WHERE IdUsuario=@id");
                datos.SetearParametro("@nombre", u.Nombre);
                datos.SetearParametro("@apellido", u.Apellido);
                datos.SetearParametro("@email", u.Email);
                datos.SetearParametro("@user", u.Username);
                datos.SetearParametro("@perfil", u.Perfil.IdPerfil);
                datos.SetearParametro("@id", u.IdUsuario);
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
                datos.SetearConsulta("UPDATE Usuarios SET Activo=0 WHERE IdUsuario=@id");
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

        public List<Usuario> ListarMecanicos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"SELECT u.*, p.Descripcion AS DescPerfil 
                                       FROM Usuarios u
                                       INNER JOIN Perfiles p ON u.IdPerfil = p.IdPerfil
                                       WHERE p.Descripcion = 'Mecanico' AND u.Activo = 1");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Username = (string)datos.Lector["Username"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Perfil = new Perfil();
                    aux.Perfil.IdPerfil = (int)datos.Lector["IdPerfil"];
                    aux.Perfil.Descripcion = (string)datos.Lector["DescPerfil"];
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
    }
}
