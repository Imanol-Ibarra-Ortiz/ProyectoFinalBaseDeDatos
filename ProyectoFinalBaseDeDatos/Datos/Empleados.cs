﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBaseDeDatos.Datos
{
    public class Empleados
    {
        public int idEmpleado { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Gerente { get; set; }
        public double SueldoSemanal { get; set; }
        public Empleados() { }


    }
}
