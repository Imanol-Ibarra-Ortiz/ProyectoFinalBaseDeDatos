using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBaseDeDatos.Datos
{
    class Menu
    {
        public int idMenu { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Tipo { get; set; }
        public int Raciones { get; set; }
        public string Clasificacion { get; set; }
        public Menu() { }
    }
}
