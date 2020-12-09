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
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnMostrarR1_Click(object sender, EventArgs e)
        {
            List<Datos.Reporte1> listaR = new List<Datos.Reporte1>();
            dgvReportes.DataSource = Negocios.ReportesBD.ConsultarR1(txtAnioR1.Text, txtMesR1.Text);
            Console.WriteLine("Reportes: "+listaR.Count);
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicio = new FormInicio(FormLogin.indiceUsuario);
            inicio.Show();
        }

        private void BtnMostrarR2_Click(object sender, EventArgs e)
        {
            List<Datos.Reporte2> listaR = new List<Datos.Reporte2>();
            string fechai = Convert.ToDateTime((dtpInicialR2.Text)).ToString("yyyy-MM-dd");
            string fechaf = Convert.ToDateTime((dtpFinalR2.Text)).ToString("yyyy-MM-dd");
            Console.WriteLine("fecha inicio: " + fechai);
            Console.WriteLine("fecha inicio: " + fechaf);
            dgvReportes.DataSource = Negocios.ReportesBD.ConsultarR2(fechai, fechaf);
            
        }
    }
}
