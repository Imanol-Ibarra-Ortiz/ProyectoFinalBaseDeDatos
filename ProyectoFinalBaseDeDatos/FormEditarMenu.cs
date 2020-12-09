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
    public partial class FormEditarMenu : Form
    {
        public FormEditarMenu()
        {
            InitializeComponent();
        }

        public FormEditarMenu(int clave)
        {
            InitializeComponent();
            Cargar(clave);
        }

        List<Datos.Menu> menu = new List<Datos.Menu>();
        int Id;

        public void Cargar(int Clave)
        {
            menu = Negocios.MenuBD.ConsultaTodos();
            Id = menu[Clave].idMenu;
            txtNombre.Text = menu[Clave].Nombre;
            txtPrecio.Text = "" + menu[Clave].Precio;
            cbxTipo.Text = menu[Clave].Tipo;
            txtRaciones.Text = "" + menu[Clave].Raciones;
            cbxClasificacion.Text = menu[Clave].Clasificacion;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtPrecio.Text != "" && cbxTipo.Text != ""
                && txtRaciones.Text != "" && cbxClasificacion.Text != "")
            {
                Datos.Menu menu = new Datos.Menu();
                menu.idMenu = Id;
                menu.Nombre = txtNombre.Text;
                menu.Precio = Convert.ToInt32(txtPrecio.Text);
                menu.Tipo = cbxTipo.Text;
                menu.Raciones = Convert.ToInt32(txtRaciones.Text);
                menu.Clasificacion = cbxClasificacion.Text;
                Negocios.MenuBD.Actualizar(menu);
                MessageBox.Show("Producto Actualizado");
                this.Hide();
                MenuRestaurante frmMenu = new MenuRestaurante(FormLogin.indiceUsuario);
                frmMenu.Show();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }


        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuRestaurante frmMenu = new MenuRestaurante(FormLogin.indiceUsuario);
            frmMenu.Show();
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

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se permiten Numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtRaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se permiten Numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void CbxTipo_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void CbxClasificacion_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
