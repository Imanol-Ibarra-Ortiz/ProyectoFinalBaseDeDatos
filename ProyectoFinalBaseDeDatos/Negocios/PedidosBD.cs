using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoFinalBaseDeDatos.Negocios
{
    class PedidosBD
    {
        /// <summary>
        /// Metodo para agregar a un pedido en la tabla pedidos de la base de datos 
        /// </summary>
        /// <param name="pedidos">Variable de tipo pedido con los datos que se agregaran</param>
        public static void AgregarPedido(Datos.Pedidos pedidos)
        {
            String sql = "call prAgregarPedido(@idPedidos,@Mesa,@Fecha,@idEmpleado);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@idPedidos", pedidos.idPedidos);
                comando.Parameters.AddWithValue("@Mesa", pedidos.Mesa);
                comando.Parameters.AddWithValue("@Fecha", pedidos.Fecha);
                comando.Parameters.AddWithValue("@idEmpleado", pedidos.idEmpleado);
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
        /// <summary>
        /// Metodo para consultar todos los pedidos de la base de datos
        /// </summary>
        /// <returns>Retorna una lista de tipo Pedidos con los datos de la base de 
        /// datos en la tabla pedido</returns>
        public static List<Datos.Pedidos> ConsultaTodos()
        {
            List<Datos.Pedidos> Lista = new List<Datos.Pedidos>();
            String sql = "call SeleccionarPedidos();";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Datos.Pedidos pedidos = new Datos.Pedidos();
                    pedidos.idPedidos = reader.GetInt32(0);
                    pedidos.Mesa = reader.GetInt32(1);
                    pedidos.Fecha = reader.GetString(2);
                    pedidos.idEmpleado = reader.GetInt32(3);
                    Lista.Add(pedidos);
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
        /// Metodo que consulta los datos del pedido como, lo que se ordeno y en que cantidades
        /// para cada mesa el identificador de la orden el empleado etc.
        /// </summary>
        /// <returns>Lita de tipo PedidosDatos con los datos de los pedidod</returns>
        public static List<Datos.PedidosDatos> ConsultaDatos()
        {
            List<Datos.PedidosDatos> Lista = new List<Datos.PedidosDatos>();
            String sql = "call pedidosDatos();";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Datos.PedidosDatos pedidosdatos = new Datos.PedidosDatos();
                    pedidosdatos.idPedidos = reader.GetInt32(0);
                    pedidosdatos.idEmpleado = reader.GetInt32(1);
                    pedidosdatos.idMenu = reader.GetInt32(2);
                    pedidosdatos.Empleado = reader.GetString(3);
                    pedidosdatos.Mesa = reader.GetInt32(4);
                    pedidosdatos.Fecha = reader.GetString(5);
                    pedidosdatos.Nombre_Pedido = reader.GetString(6);
                    pedidosdatos.Tipo = reader.GetString(7);
                    pedidosdatos.Clasificacion = reader.GetString(8);
                    pedidosdatos.Precio = reader.GetInt32(9);
                    pedidosdatos.Cantidad = reader.GetInt32(10);
                    pedidosdatos.Total_Nombre_Pedido = reader.GetString(11);
                    Lista.Add(pedidosdatos);
                }
                tran.Commit();
            }
            catch
            {
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
        /// metodo para eliminar un pedido en la base de datos
        /// </summary>
        /// <param name="Id">Variable utilizada para indicar que pedido se eliminara </param>
        public static void Eliminar(int IdMENU, int idPEDIDO)
        {
            String sql = "call eliminarPedidos(@IdMENU, @idPEDIDO);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@IdMENU", IdMENU);
                comando.Parameters.AddWithValue("@idPEDIDO", idPEDIDO);
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
