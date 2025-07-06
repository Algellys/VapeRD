using System.Windows.Forms;

namespace TiendaVapes.AdminUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            var frm = new frmProductos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            var frm = new frmUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            var frm = new frmClientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            var frm = new frmFacturas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            var frm = new frmServicios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnCuentasPorCobrar_Click(object sender, EventArgs e)
        {
            var frm = new frmCuentasPorCobrar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnVerCotizaciones_Click(object sender, EventArgs e)
        {
            var frm = new frmCotizaciones();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
