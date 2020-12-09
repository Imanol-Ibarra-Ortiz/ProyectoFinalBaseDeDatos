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
    public partial class MenuRestaurante : Form
    {
        //Lista usada de tipo menu tilizada para
        List<Datos.Menu> listaM = new List<Datos.Menu>();

        int indice = 0;
        int dtp = 0;

        //lista de tipo menu para obtener los datos del menu en el inidice seleccionado
        //List<Datos.Menu> menu = new List<Datos.Menu>();

        List<Datos.Empleados> empleado = new List<Datos.Empleados>();

        //Lista pedidos usada para obtener el pedido con ib del mas resiente 
        List<Datos.Pedidos> pedidos = new List<Datos.Pedidos>();

        //Lista detallespedidos usada para optener si el idMenu ya exiate en la tabla detallespedidos
        List<Datos.DetallesPedido> detallespedidos = new List<Datos.DetallesPedido>();

        public MenuRestaurante()
        {
            InitializeComponent();
            
        }

        public MenuRestaurante(int idE)
        {
            InitializeComponent();
            dgvMenu.DataSource = Negocios.MenuBD.ConsultaTodos();
            listaM = Negocios.MenuBD.ConsultaTodos();
            this.lblFecha.Text = DateTime.Now.ToLongDateString();

            if (FormLogin.bandera == 1)
            {
                pnlAgregar.Visible = true;
            }
            CargarIdEmp(FormLogin.indiceUsuario);

        }

        List<Datos.Empleados> empleados = new List<Datos.Empleados>();

        int IdE;
        public void CargarIdEmp(int idEmp)
        {
            empleados = Negocios.EmpleadosBD.ConsultaTodos();
            IdE = empleados[idEmp].idEmpleado;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAgregarMenu agregarmenu = new FormAgregarMenu();
            agregarmenu.Show();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Negocios.MenuBD.Eliminar(listaM[indice].idMenu);
            listaM = Negocios.MenuBD.ConsultaTodos();
            dgvMenu.DataSource = listaM;
        }

        private void DgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = int.Parse(dgvMenu.CurrentCellAddress.Y.ToString());
        }

        private void BtnPedido_Click(object sender, EventArgs e)
        {
            //lista de tipo menu para obtener los datos del menu en el inidice seleccionado
            cbMesa.Enabled = false;
            btnRegresar.Enabled = false;
            btnTerminar.Enabled = true;
            listaM = Negocios.MenuBD.ConsultaTodos();
            empleado = Negocios.EmpleadosBD.ConsultaTodos();

            Datos.Pedidos Agpedidos = new Datos.Pedidos();
            Datos.DetallesPedido detallesPedido = new Datos.DetallesPedido();
            DateTime hoy = DateTime.Now;
            if (dtp == 0)
            {
                // Agrega los datos a la tabla Pedidos
                Agpedidos.idPedidos = 0;
                Agpedidos.Mesa = Convert.ToInt32(cbMesa.Text);
                Agpedidos.Fecha = hoy.ToString("yyyy-MM-dd");
                Agpedidos.idEmpleado = empleado[FormLogin.indiceUsuario].idEmpleado;

                Negocios.PedidosBD.AgregarPedido(Agpedidos);
                MessageBox.Show("Nuevo elemento agregado a pedidos");

                // Agrega los datos a la tabla DetallesPedidos
                pedidos = Negocios.PedidosBD.ConsultaTodos();
                Console.WriteLine("id actual: " + pedidos[pedidos.Count - 1].idPedidos);
                detallesPedido.idPedidos = pedidos[pedidos.Count - 1].idPedidos;
                detallesPedido.idMenu = listaM[indice].idMenu;
                detallesPedido.Cantidad = Convert.ToInt32(txtCantidad.Text);
                Negocios.DetallesPedidoBD.AgregarDetallesPedido(detallesPedido);
                MessageBox.Show("Nuevo elemento agregado a detalles pedidos");
                /**/
                Datos.Menu menu = new Datos.Menu();
                menu.idMenu = listaM[indice].idMenu;
                menu.Nombre = listaM[indice].Nombre;
                menu.Precio = listaM[indice].Precio;
                menu.Tipo = listaM[indice].Tipo;
                menu.Raciones = listaM[indice].Raciones - Convert.ToInt32(txtCantidad.Text);
                Console.WriteLine("Raciones: "+ (listaM[indice].Raciones - Convert.ToInt32(txtCantidad.Text)));
                menu.Clasificacion = listaM[indice].Clasificacion;
                Negocios.MenuBD.ActualizarR(menu);
                listaM = Negocios.MenuBD.ConsultaTodos();
                dgvMenu.DataSource = listaM;

                dtp++;
            }
            else
            {
                // Agrega los datos a la tabla DetallesPedidos
                pedidos = Negocios.PedidosBD.ConsultaTodos();
                detallespedidos = Negocios.DetallesPedidoBD.ConsultaTodos();
                int cont = -1;
                for (int i = 0; i < detallespedidos.Count; i++)
                {
                    if (listaM[indice].idMenu == detallespedidos[i].idMenu
                        && pedidos[pedidos.Count - 1].idPedidos == detallespedidos[i].idPedidos)
                    {
                        cont = i;
                    }
                }

                Console.WriteLine("existe: " + cont);
                if (cont != -1)
                {
                    Datos.DetallesPedido detalles = new Datos.DetallesPedido();
                    detalles.idPedidos = pedidos[pedidos.Count - 1].idPedidos;
                    detalles.idMenu = listaM[indice].idMenu;
                    Console.Write("Actualizacion pedido: " + detallespedidos[cont].Cantidad + "+" + Convert.ToInt32(txtCantidad.Text));
                    detalles.Cantidad = detallespedidos[cont].Cantidad + Convert.ToInt32(txtCantidad.Text);
                    Negocios.DetallesPedidoBD.Actualizar(detalles);
                    MessageBox.Show("Producto Actualizado");

                    /**/
                    Datos.Menu menu = new Datos.Menu();
                    menu.idMenu = listaM[indice].idMenu;
                    menu.Nombre = listaM[indice].Nombre;
                    menu.Precio = listaM[indice].Precio;
                    menu.Tipo = listaM[indice].Tipo;
                    menu.Raciones = listaM[indice].Raciones - Convert.ToInt32(txtCantidad.Text);
                    Console.WriteLine("Raciones: " + (listaM[indice].Raciones - Convert.ToInt32(txtCantidad.Text)));
                    menu.Clasificacion = listaM[indice].Clasificacion;
                    Negocios.MenuBD.ActualizarR(menu);
                    listaM = Negocios.MenuBD.ConsultaTodos();
                    dgvMenu.DataSource = listaM;

                }
                else
                {
                    Console.WriteLine("id actual 2: " + pedidos[pedidos.Count - 1].idPedidos);
                    detallesPedido.idPedidos = pedidos[pedidos.Count - 1].idPedidos;
                    detallesPedido.idMenu = listaM[indice].idMenu;
                    detallesPedido.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    Negocios.DetallesPedidoBD.AgregarDetallesPedido(detallesPedido);
                    MessageBox.Show("Nuevo elemento agregado a detalles pedidos");

                    /**/
                    Datos.Menu menu = new Datos.Menu();
                    menu.idMenu = listaM[indice].idMenu;
                    menu.Nombre = listaM[indice].Nombre;
                    menu.Precio = listaM[indice].Precio;
                    menu.Tipo = listaM[indice].Tipo;
                    menu.Raciones = listaM[indice].Raciones - Convert.ToInt32(txtCantidad.Text);
                    Console.WriteLine("Raciones: " + (listaM[indice].Raciones - Convert.ToInt32(txtCantidad.Text)));
                    menu.Clasificacion = listaM[indice].Clasificacion;
                    Negocios.MenuBD.ActualizarR(menu);
                    listaM = Negocios.MenuBD.ConsultaTodos();
                    dgvMenu.DataSource = listaM;
                }

            }

        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicio = new FormInicio(FormLogin.indiceUsuario);
            inicio.Show();
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            cbMesa.Enabled = true;
            btnRegresar.Enabled = true;
            btnTerminar.Enabled = false;
            dtp = 0;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEditarMenu editarmenu = new FormEditarMenu(indice);
            editarmenu.Show();
        }

        private void CbMesa_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
