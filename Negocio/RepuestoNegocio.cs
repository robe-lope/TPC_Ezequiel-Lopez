using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RepuestoNegocio
    {
        public List<Repuesto> Listar()
        {
            List<Repuesto> lista = new List<Repuesto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"SELECT r.*, m.Nombre AS NombreMarca, c.Descripcion AS DescCategoria
                                       FROM Repuestos r
                                       INNER JOIN MarcasRepuesto m ON r.IdMarca = m.IdMarca
                                       INNER JOIN CategoriasRepuesto c ON r.IdCategoria = c.IdCategoria
                                       WHERE r.Activo = 1
                                       ORDER BY r.Descripcion ASC");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Repuesto aux = new Repuesto();
                    aux.IdRepuesto = (int)datos.Lector["IdRepuesto"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];
                    aux.PrecioVenta = (decimal)datos.Lector["PrecioVenta"];
                    aux.StockActual = (int)datos.Lector["StockActual"];
                    aux.StockMinimo = (int)datos.Lector["StockMinimo"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Marca = new MarcaRepuesto();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["NombreMarca"];
                    aux.Categoria = new CategoriaRepuesto();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["DescCategoria"];
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

        public void Agregar(Repuesto r)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"INSERT INTO Repuestos (Codigo, Descripcion, IdMarca, IdCategoria,
                                       PrecioCompra, PrecioVenta, StockActual, StockMinimo)
                                       VALUES (@cod, @desc, @marca, @cat, @pc, @pv, @sa, @sm)");
                datos.SetearParametro("@cod", r.Codigo);
                datos.SetearParametro("@desc", r.Descripcion);
                datos.SetearParametro("@marca", r.Marca.IdMarca);
                datos.SetearParametro("@cat", r.Categoria.IdCategoria);
                datos.SetearParametro("@pc", r.PrecioCompra);
                datos.SetearParametro("@pv", r.PrecioVenta);
                datos.SetearParametro("@sa", r.StockActual);
                datos.SetearParametro("@sm", r.StockMinimo);
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

        public void Modificar(Repuesto r)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"UPDATE Repuestos SET Codigo=@cod, Descripcion=@desc,
                                       IdMarca=@marca, IdCategoria=@cat, PrecioCompra=@pc,
                                       PrecioVenta=@pv, StockActual=@sa, StockMinimo=@sm
                                       WHERE IdRepuesto=@id");
                datos.SetearParametro("@cod", r.Codigo);
                datos.SetearParametro("@desc", r.Descripcion);
                datos.SetearParametro("@marca", r.Marca.IdMarca);
                datos.SetearParametro("@cat", r.Categoria.IdCategoria);
                datos.SetearParametro("@pc", r.PrecioCompra);
                datos.SetearParametro("@pv", r.PrecioVenta);
                datos.SetearParametro("@sa", r.StockActual);
                datos.SetearParametro("@sm", r.StockMinimo);
                datos.SetearParametro("@id", r.IdRepuesto);
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
                datos.SetearConsulta("UPDATE Repuestos SET Activo=0 WHERE IdRepuesto=@id");
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
