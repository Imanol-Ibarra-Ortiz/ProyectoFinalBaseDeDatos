using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBaseDeDatos
{
    public partial class FormLogin : Form
    {
        // bandera se usa para detectar si el usuario es gerente 
        public static int bandera = 0;
        public static int indiceUsuario = -1;
        public FormLogin()
        {
            InitializeComponent();
            indiceUsuario = -1;
            bandera = 0;
        }

        private void BtnInisiarSecion_Click(object sender, EventArgs e)
        {
            //Lista de usuarios para obtener el indice del usuario actual
            List<Datos.Empleados> empleados = new List<Datos.Empleados>();
            empleados = Negocios.EmpleadosBD.ConsultaTodos();
            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].NombreUsuario == txtNombreUsuario.Text)
                {
                    indiceUsuario = i;
                }
            }
            // if para validar si el contraseña y nombre de usuario es correcto
            if (Negocios.EmpleadosBD.iniciarSesion(txtNombreUsuario.Text, txtPassword.Text) == true && indiceUsuario!=-1)
            {

                // if para validar que el usurio sea gerente
                if (empleados[indiceUsuario].Gerente.Equals("T"))
                {
                    bandera = 1;
                }
                
               /**se cierra el form actual y se llama el de inicio adicionalmente se le envia
               el indice donde se encuentra*/
                this.Hide();
                FormInicio inicio = new FormInicio(indiceUsuario);
                inicio.Show();


            }
            //si el nombre de usuario o contraseña es incorrecto lo notifica
            else
            {
                MessageBox.Show("Usuario o contraseña erroneos");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAgregarEmpleado agregarEmpleado = new FormAgregarEmpleado();
            agregarEmpleado.Show();
        }
    }
}
