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
    public partial class FormEmpleados : Form
    {
        List<Datos.Empleados> listaE = new List<Datos.Empleados>();
        int indice = 0;

        public FormEmpleados()
        {
            InitializeComponent();
            dgvEmpleados.DataSource = Negocios.EmpleadosBD.ConsultaTodos();
            listaE = Negocios.EmpleadosBD.ConsultaTodos();

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormModificarEmpleado editarEmpleado = new FormModificarEmpleado(indice);
            editarEmpleado.Show();
        }

        private void DgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = int.Parse(dgvEmpleados.CurrentCellAddress.Y.ToString());
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Negocios.EmpleadosBD.Eliminar(listaE[indice].idEmpleado);
            listaE = Negocios.EmpleadosBD.ConsultaTodos();
            dgvEmpleados.DataSource = listaE;
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicio = new FormInicio(FormLogin.indiceUsuario);
            inicio.Show();
        }
    }
}
