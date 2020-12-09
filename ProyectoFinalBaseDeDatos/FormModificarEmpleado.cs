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
    public partial class FormModificarEmpleado : Form
    {
        public FormModificarEmpleado()
        {
            InitializeComponent();
        }

        public FormModificarEmpleado(int clave)
        {
            InitializeComponent();
            Cargar(clave);
        }

        List<Datos.Empleados> empleado = new List<Datos.Empleados>();
        int Id;

        public void Cargar(int Clave)
        {
            empleado = Negocios.EmpleadosBD.ConsultaTodos();
            Id = empleado[Clave].idEmpleado;
            txtNombreUsuario.Text = empleado[Clave].NombreUsuario;
            txtNombre.Text = empleado[Clave].Nombre;
            txtApellidos.Text = empleado[Clave].Apellidos;
            txtTel.Text = empleado[Clave].Telefono;
            txtPasswd.Text = empleado[Clave].Password;
            txtConfirmarPasswd.Text = empleado[Clave].Password;
            if (empleado[Clave].Gerente.Equals("T"))
            {
                rbtSi.Checked = true;
            }
            else
            {
                rbtNo.Checked = false;
            }
            txtSueldo.Text = "" + empleado[Clave].SueldoSemanal;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEmpleados frmEmpleados = new FormEmpleados();
            frmEmpleados.Show();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (txtPasswd.Text.Equals(txtConfirmarPasswd.Text))
            {
                if (txtNombreUsuario.Text != "" && txtNombre.Text != "" && txtApellidos.Text != ""
                    && txtTel.Text != "" && txtSueldo.Text != "" && (rbtSi.Checked == true | rbtNo.Checked == true))
                {
                    Datos.Empleados empleados = new Datos.Empleados();
                    empleados.idEmpleado = Id;
                    empleados.NombreUsuario = txtNombreUsuario.Text;
                    empleados.Nombre = txtNombre.Text;
                    empleados.Apellidos = txtApellidos.Text;
                    empleados.Telefono = txtTel.Text;
                    empleados.Password = txtPasswd.Text;
                    if (rbtSi.Checked == true)
                    {
                        empleados.Gerente = "T";
                    }
                    else
                    {
                        empleados.Gerente = "F";
                    }
                    empleados.SueldoSemanal = Convert.ToInt32(txtSueldo.Text);
                    Negocios.EmpleadosBD.Actualizar(empleados);
                    MessageBox.Show("Se a modificado Correctamente");
                    this.Hide();
                    FormEmpleados frmEmpleados = new FormEmpleados();
                    frmEmpleados.Show();
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }

            }
            else
            {
                MessageBox.Show("La contraseña no coinside");
            }
        }

        private void TxtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTel.MaxLength = 10;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se permiten Numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se permiten Numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
