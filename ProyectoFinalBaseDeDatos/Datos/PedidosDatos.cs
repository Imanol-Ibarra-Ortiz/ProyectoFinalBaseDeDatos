using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBaseDeDatos.Datos
{
    class PedidosDatos
    {
        public int idPedidos { get; set; }
        public int idEmpleado { get; set; }
        public int idMenu { get; set; }
        public string Empleado { get; set; }
        public int Mesa { get; set; }
        public string Fecha { get; set; }
        public string Nombre_Pedido { get; set; }
        public string Tipo { get; set; }
        public string Clasificacion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public string Total_Nombre_Pedido { get; set; }
        public PedidosDatos() { }
    }
}
