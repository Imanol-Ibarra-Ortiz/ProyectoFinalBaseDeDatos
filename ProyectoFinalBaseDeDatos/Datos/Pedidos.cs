using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBaseDeDatos.Datos
{
    class Pedidos
    {
        public int idPedidos { get; set; }
        public int Mesa { get; set; }
        public string Fecha { get; set; }
        public int idEmpleado { get; set; }
        public Pedidos() { }
    }
}
