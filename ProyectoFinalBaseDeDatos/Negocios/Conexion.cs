using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoFinalBaseDeDatos.Negocios
{
    class Conexion
    {
        /// <summary>
        /// Se encarga de establecer la conexion con nuestra base de datos
        /// </summary>
        /// <returns>Retorna la conexion a la conexion a la base de datos </returns>
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=RESTAURANTE; Uid=root; pwd=totoro; port=3306");
            bool sucess = false;
            try
            {
                conexion.Open();
                sucess = true;
                Console.WriteLine("Connection OK");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Connection failed: \n" + ex.Message);
            }
            return conexion;
        }
    }
}
