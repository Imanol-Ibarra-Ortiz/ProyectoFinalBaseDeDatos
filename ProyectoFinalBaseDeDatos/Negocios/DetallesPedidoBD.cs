using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoFinalBaseDeDatos.Negocios
{
    class DetallesPedidoBD
    {
        /// <summary>
        /// Este metodo nos permite agregar alementos a la tabla detallesPedidos en la 
        /// base de datos.
        /// </summary>
        /// <param name="detallespedidos">Lista de tipo detallesPedos que contiene los datos a agregar</param>
        public static void AgregarDetallesPedido(Datos.DetallesPedido detallespedidos)
        {
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                String sql = "call prAgregarDetallesPedido(@idPedidos,@idMenu,@Cantidad);";
                MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@idPedidos", detallespedidos.idPedidos);
                comando.Parameters.AddWithValue("@idMenu", detallespedidos.idMenu);
                comando.Parameters.AddWithValue("@Cantidad", detallespedidos.Cantidad);
                comando.ExecuteNonQuery();
                tran.Commit();
                comando.Dispose();
            }
            catch (Exception exc)
            {
                tran.Rollback();
                Console.WriteLine("Algo salio mal en la transaccion");
            }

        }
        /// <summary>
        /// Metodo que nos permite consultar todos los datos de la tabla detallesPedidos de nuestra
        /// base de datos
        /// </summary>
        /// <returns>Retorna una lista de tipo detallesPedidos</returns>
        public static List<Datos.DetallesPedido> ConsultaTodos()
        {
            List<Datos.DetallesPedido> Lista = new List<Datos.DetallesPedido>();
            String sql = "call SeleccionarDetallesPedido();";
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Datos.DetallesPedido pedidoD = new Datos.DetallesPedido();
                    pedidoD.idPedidos = reader.GetInt32(0);
                    pedidoD.idMenu = reader.GetInt32(1);
                    pedidoD.Cantidad = reader.GetInt32(2);
                    Lista.Add(pedidoD);
                }
                tran.Commit();
            }
            catch {
                Console.WriteLine("Algo salio mal en la transaccion");
                tran.Rollback();
            }
            finally
            {
                comando.Dispose();
                Conexion.ObtenerConexion().Close();
                Conexion.ObtenerConexion().Dispose();
            }
            return Lista;
        }
        /// <summary>
        /// Nos permite actualizar la cantidad de algun de productos ordenados en la tabla 
        /// detallesPedidos
        /// </summary>
        /// <param name="detalles">Lista de tipo detallesPedido que contiene los datos que 
        /// remplaran los actuales a exepcion del idPedidos y idCantidad que permianeceran igual</param>
        public static void Actualizar(Datos.DetallesPedido detalles)
        {
            String sql = "call prUpdateDetallesPedido(@Cantidad,@IdMenu,@idPedidos);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@idPedidos", detalles.idPedidos);
                comando.Parameters.AddWithValue("@idMenu", detalles.idMenu);
                comando.Parameters.AddWithValue("@Cantidad", detalles.Cantidad);
                comando.ExecuteNonQuery();
                tran.Commit();
                comando.Dispose();
                
            }
            catch (Exception)
            {
                tran.Rollback();
                Console.WriteLine("Algo salio mal en la transaccion");
            }
        }

    }
}
