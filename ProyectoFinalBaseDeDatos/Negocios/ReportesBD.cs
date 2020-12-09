using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoFinalBaseDeDatos.Negocios
{
    class ReportesBD
    {
        /// <summary>
        /// Metodo para generar un reporte de ventas por empleado
        /// </summary>
        /// <param name="Anio">Es el año del que se rwquiere generar el reporte</param>
        /// <param name="Mes">Es el mes del cual se requiere el reporte</param>
        /// <returns></returns>
        public static List<Datos.Reporte1> ConsultarR1(string Anio, string Mes)
        {
            List<Datos.Reporte1> Lista = new List<Datos.Reporte1>();
            String sql = "call ReporteDeVentasPorEmpleado(@Anio, @Mes);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            comando.Parameters.AddWithValue("@Anio", Anio);
            comando.Parameters.AddWithValue("@Mes", Mes);
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Datos.Reporte1 reportes = new Datos.Reporte1();
                    reportes.idEmpleado = reader.GetInt32(0);
                    reportes.NombreUsuario = reader.GetString(1);
                    reportes.Empleado = reader.GetString(2);
                    reportes.Cantidad = reader.GetInt32(3);
                    reportes.Monto = reader.GetInt32(4);
                    Lista.Add(reportes);
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
        /// Metodo para generar el reporte de ventas por periodo en un rango de tiempo
        /// </summary>
        /// <param name="FechaI">Fecha a partir de la cual se requiere el reporte</param>
        /// <param name="FechaF">Fecha hasta la cual se requiere el reporte</param>
        /// <returns></returns>
        public static List<Datos.Reporte2> ConsultarR2(string FechaI, string FechaF)
        {
            List<Datos.Reporte2> Lista = new List<Datos.Reporte2>();
            String sql = "call ReporteDeVentasPorPeriodo(@FechaI, @FechaF);";
            MySqlCommand comando = new MySqlCommand(sql, Conexion.ObtenerConexion());
            MySqlTransaction tran = Conexion.ObtenerConexion().BeginTransaction();
            comando.Parameters.AddWithValue("@FechaI", FechaI);
            comando.Parameters.AddWithValue("@FechaF", FechaF);
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Datos.Reporte2 reportes = new Datos.Reporte2();
                    reportes.idPedidos = reader.GetInt32(0);
                    reportes.Fecha = reader.GetString(1);
                    reportes.Monto = reader.GetString(2);
                    reportes.Empleado = reader.GetString(3);
                    
                    Lista.Add(reportes);
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
    }
}
