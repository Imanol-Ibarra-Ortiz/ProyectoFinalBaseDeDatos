using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBaseDeDatos.Datos
{
    class DetallesPedido
    {
        public int idPedidos { get; set; }
        public int idMenu { get; set; }
        public int Cantidad { get; set; }
        public DetallesPedido() { }
    }
}
