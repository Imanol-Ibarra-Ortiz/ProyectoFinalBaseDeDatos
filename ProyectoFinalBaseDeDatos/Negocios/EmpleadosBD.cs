using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace ProyectoFinalBaseDeDatos.Negocios
{
    class EmpleadosBD
    {
        /// <summary>
        /// Metodo que valida la contraseña y password introducido esten en la base de datos
        /// en la tabla empleado
        /// </summary>
        /// <param name="Usuario">Es la variable del nombre de usuario</param>
        /// <param name="Contraseña">Es la varible de la contraseña</param>
        /// <returns></returns>
        public static Boolean iniciarSesion(string Usuario, string Contraseña)
        {
            if (Usuario != "" && Contraseña != "")
            {
                String sql = "select NombreUsuario, Passwords from empleado where NombreUsuario=@NombreUsuario and Passwords=@Passwords";
                MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@NombreUsuario", Usuario);
                SHA1 sha256 = SHA1.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha256.ComputeHash(encoding.GetBytes(Contraseña));

                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                comando.Parameters.AddWithValue("@Passwords", sb.ToString());
                MySqlDataReader reader = comando.ExecuteReader();
                Console.WriteLine("Connection: " + reader);
                if (reader.Read() == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Metodo que devuelve una lista de tipo empleado con los datos de los empleados
        /// encontrados en la base de datos en la tabla empleados
        /// </summary>
        /// <returns>Retorna una lista de empleados</returns>
        public static List<Datos.Empleados> ConsultaTodos()
        {  
            List<Datos.Empleados> Lista = new List<Datos.Empleados> ();
            String sql = "call SeleccionarEmpleado();";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Datos.Empleados empleados = new Datos.Empleados();
                    empleados.idEmpleado = reader.GetInt32(0);
                    empleados.NombreUsuario = reader.GetString(1);
                    empleados.Nombre = reader.GetString(2);
                    empleados.Apellidos = reader.GetString(3);
                    empleados.Password = reader.GetString(4);
                    empleados.Telefono = reader.GetString(5);
                    empleados.Gerente = reader.GetString(6);
                    empleados.SueldoSemanal = reader.GetInt32(7);
                    Lista.Add(empleados);
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
        /// Metodo que elimina el empleado por medio del idEmpleado de la base de datos en la 
        /// tabla empleado
        /// </summary>
        /// <param name="Id">Varible que contiene el idEmpleado que se eliminara</param>
        public static void Eliminar(int Id)
        {
            String sql = "call prEliminarEmpleado(@Id);";
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
        /// Metodo que agrega un empleado a la base de datos en la tabla empleado,
        /// resive una variable de tipo empleado con los datos a insertar
        /// </summary>
        /// <param name="empleados">variable de tipo empleado con los datos del empleado</param>
        public static void agregarE(Datos.Empleados empleados)
        {
            String sql = "call prAgregarEmpleado(@idEmpleado,@NombreUsuario,@Nombre,@Apellidos,@Passwords,@Telefono,@Gerente,@SueldoSemanal);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@idEmpleado", empleados.idEmpleado);
                comando.Parameters.AddWithValue("@NombreUsuario", empleados.NombreUsuario);
                comando.Parameters.AddWithValue("@Nombre", empleados.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", empleados.Apellidos);
                comando.Parameters.AddWithValue("@Passwords", empleados.Password);
                comando.Parameters.AddWithValue("@Telefono", empleados.Telefono);
                comando.Parameters.AddWithValue("@Gerente", empleados.Gerente);
                comando.Parameters.AddWithValue("@SueldoSemanal", empleados.SueldoSemanal);
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
        /// Metodo que nos permite actualizar los datos de un empleado en la base de datos
        /// de la tabla empleado
        /// </summary>
        /// <param name="empleados">Variable de tipo empleado que contiene los nuevos datos
        /// del empleado</param>
        public static void Actualizar(Datos.Empleados empleados)
        {
            String sql = "call prModificarEmpleado(@idEmpleado,@NombreUsuario,@Nombre,@Apellidos,@Passwords,@Telefono,@Gerente,@SueldoSemanal);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            try
            {
                comando.Parameters.AddWithValue("@idEmpleado", empleados.idEmpleado);
                comando.Parameters.AddWithValue("@NombreUsuario", empleados.NombreUsuario);
                comando.Parameters.AddWithValue("@Nombre", empleados.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", empleados.Apellidos);
                comando.Parameters.AddWithValue("@Passwords", empleados.Password);
                comando.Parameters.AddWithValue("@Telefono", empleados.Telefono);
                comando.Parameters.AddWithValue("@Gerente", empleados.Gerente);
                comando.Parameters.AddWithValue("@SueldoSemanal", empleados.SueldoSemanal);
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
