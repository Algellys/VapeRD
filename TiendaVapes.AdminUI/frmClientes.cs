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
    public partial class frmClientes : Form
    {
        private string connectionString = @"Data Source=DESKTOP-HGTU4PK\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;TrustServerCertificate=True;";

        public frmClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerClientes";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvClientes.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new frmClienteAgregarEditar();
            frm.ShowDialog();
            CargarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteId"].Value);
                var frm = new frmClienteAgregarEditar(id);
                frm.ShowDialog();
                CargarClientes();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteId"].Value);
                var confirm = MessageBox.Show("¿Seguro que deseas eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "EliminarCliente";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ClienteId", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        CargarClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                    }
                }
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }
    }
}
