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
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        //Resive el inice donde se encuentra el usuario que ingreso secion
        public FormInicio(int clave)
        {
            
            InitializeComponent();
            //Si el usuario es gerente puede ingresar a funciones extra
            if (FormLogin.bandera == 1)
            {
                pnlAdmin.Visible = true;
            }
            //Cargar como su nombre lo indica carga el nombre e id del usuario en la ventana
            Cargar(clave);
        }

        //lista para extaer los datos del usuario
        List<Datos.Empleados> empleados = new List<Datos.Empleados>();

        public void Cargar(int Clave)
        {
            empleados = Negocios.EmpleadosBD.ConsultaTodos();
            lblNombre.Text = empleados[Clave].Nombre + " " + empleados[Clave].Apellidos;
            lblID.Text = ""+empleados[Clave].idEmpleado;
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            //Habre la ventana Empleados
            this.Hide();
            FormEmpleados formempleados = new FormEmpleados();
            formempleados.Show();
            
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            //Habre la ventana Menu
            this.Hide();
            MenuRestaurante menu = new MenuRestaurante(FormLogin.indiceUsuario);
            menu.Show();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormReportes reportes = new FormReportes();
            reportes.Show();
        }

        private void BtnPedidos_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPedidos pedidos = new FormPedidos();
            pedidos.Show();
        }
    }
}
