using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoFinalBaseDeDatos.Negocios
{
    class MenuBD
    {
        /// <summary>
        /// Metodo para consultar todos los datos de la tabla Menu
        /// </summary>
        /// <returns>Retorna una lista de tipo menu con los datos de la tabla</returns>
        public static List<Datos.Menu> ConsultaTodos()
        {
            List<Datos.Menu> Lista = new List<Datos.Menu>();
            String sql = "call SeleccionarMenu();";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Datos.Menu menu = new Datos.Menu();
                    menu.idMenu = reader.GetInt32(0);
                    menu.Nombre = reader.GetString(1);
                    menu.Precio = reader.GetInt32(2);
                    menu.Tipo = reader.GetString(3);
                    menu.Raciones = reader.GetInt32(4);
                    menu.Clasificacion = reader.GetString(5);
                    Lista.Add(menu);
                }
                tran.Commit();
            }
            catch {
                tran.Rollback();
                Console.WriteLine("Algo salio mal en la transaccion");
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
        /// Metodo para agregar datos a la tabla Menu de la base de datos
        /// </summary>
        /// <param name="menu">Variable de tipo menu con los datos que se agregaran a la tabla</param>
        public static void agregarM(Datos.Menu menu)
        {
            String sql = "call prAgregarMenu(@idMenu,@Nombre,@Precio,@Tipo,@Raciones,@Clasificacion);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@idMenu", menu.idMenu);
                comando.Parameters.AddWithValue("@Nombre", menu.Nombre);
                comando.Parameters.AddWithValue("@Precio", menu.Precio);
                comando.Parameters.AddWithValue("@Tipo", menu.Tipo);
                comando.Parameters.AddWithValue("@Raciones", menu.Raciones);
                comando.Parameters.AddWithValue("@Clasificacion", menu.Clasificacion);
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
        /// metodo para eliminar de la tabla menu en la base de datos
        /// </summary>
        /// <param name="Id">Variable utilizada para indicar que se eliminara de la tabla 
        /// menu</param>
        public static void Eliminar(int Id)
        {
            String sql = "call prEliminarMenu(@Id);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@Id", Id);
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
        /// Metodo para actualizar los datos de la tabla menu en la base de datos
        /// </summary>
        /// <param name="menu">Varible de tipo menu con los datos actualizados</param>
        public static void Actualizar(Datos.Menu menu)
        {
            String sql = "call prmodificarMenu(@idMenu,@Nombre,@Precio,@Tipo,@Raciones,@Clasificacion);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@idMenu", menu.idMenu);
                comando.Parameters.AddWithValue("@Nombre", menu.Nombre);
                comando.Parameters.AddWithValue("@Precio", menu.Precio);
                comando.Parameters.AddWithValue("@Tipo", menu.Tipo);
                comando.Parameters.AddWithValue("@Raciones", menu.Raciones);
                comando.Parameters.AddWithValue("@Clasificacion", menu.Clasificacion);
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
        /// Metodo que actualiza el numero de raciones del menu en la base de datos
        /// </summary>
        /// <param name="menu">Variable de tipo menu con la actualizacion de las raciones</param>
        public static void ActualizarR(Datos.Menu menu)
        {
            String sql = "call prmodificarRacionesMenu(@idMenu,@Raciones);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@idMenu", menu.idMenu);
                comando.Parameters.AddWithValue("@Nombre", menu.Nombre);
                comando.Parameters.AddWithValue("@Precio", menu.Precio);
                comando.Parameters.AddWithValue("@Tipo", menu.Tipo);
                comando.Parameters.AddWithValue("@Raciones", menu.Raciones);
                comando.Parameters.AddWithValue("@Clasificacion", menu.Clasificacion);
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
