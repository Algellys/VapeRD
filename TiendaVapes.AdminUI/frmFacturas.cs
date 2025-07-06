using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaVapes.AdminUI
{
    public partial class frmFacturas : Form
    {
        private string connectionString = @"Data Source=DESKTOP-HGTU4PK\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;TrustServerCertificate=True;";

        public frmFacturas()
        {
            InitializeComponent();
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerFacturas";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvFacturas.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar facturas: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new frmFacturaAgregarEditar();
            frm.ShowDialog();
            CargarFacturas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvFacturas.CurrentRow.Cells["FacturaId"].Value);
                var frm = new frmFacturaAgregarEditar(id);
                frm.ShowDialog();
                CargarFacturas();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvFacturas.CurrentRow.Cells["FacturaId"].Value);
                var confirm = MessageBox.Show("¿Seguro que deseas eliminar esta factura?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "EliminarFactura";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@FacturaId", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        CargarFacturas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar factura: " + ex.Message);
                    }
                }
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }
    }
}
