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
    public partial class FormAgregarEmpleado : Form
    {
        public FormAgregarEmpleado()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtPasswd.Text.Equals(txtConfirmarPasswd.Text))
            {
                if (txtNombreUsuario.Text != "" && txtNombre.Text != "" && txtApellidos.Text != ""
                    && txtTel.Text != "" && txtSueldo.Text != "" && (rbtSi.Checked == true | rbtNo.Checked == true) )
                {
                    Datos.Empleados empleados = new Datos.Empleados();
                    empleados.idEmpleado = 0;
                    empleados.NombreUsuario = txtNombreUsuario.Text;
                    empleados.Nombre = txtNombre.Text;
                    empleados.Apellidos = txtApellidos.Text;
                    empleados.Telefono =  txtTel.Text;
                    empleados.Password = txtPasswd.Text;
                    if (rbtSi.Checked==true)
                    {
                        empleados.Gerente = "T";
                    }
                    else
                    {
                        empleados.Gerente = "F";
                    }
                    empleados.SueldoSemanal = Convert.ToInt32(txtSueldo.Text);
                    Negocios.EmpleadosBD.agregarE(empleados);
                    MessageBox.Show("Se a registrado Correctamente");
                    this.Hide();
                    FormLogin login = new FormLogin();
                    login.Show();
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            this.Hide();
            login.Show();
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
