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
    public partial class FormPedidos : Form
    {
        List<Datos.PedidosDatos> listaPD = new List<Datos.PedidosDatos>();
        int indice = 0;
        public FormPedidos()
        {
            InitializeComponent();
            dgvPedidos.DataSource = Negocios.PedidosBD.ConsultaDatos();
            listaPD = Negocios.PedidosBD.ConsultaDatos();
        }

        private void DgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = int.Parse(dgvPedidos.CurrentCellAddress.Y.ToString());
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Negocios.PedidosBD.Eliminar(listaPD[indice].idMenu,listaPD[indice].idPedidos);
            listaPD = Negocios.PedidosBD.ConsultaDatos();
            dgvPedidos.DataSource = listaPD;
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicio = new FormInicio(FormLogin.indiceUsuario);
            inicio.Show();
        }
    }
}
