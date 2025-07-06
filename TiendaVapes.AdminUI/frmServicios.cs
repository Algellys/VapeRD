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
    public partial class frmServicios : Form
    {
        private string connectionString = @"Data Source=DESKTOP-HGTU4PK\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;TrustServerCertificate=True;";

        public frmServicios()
        {
            InitializeComponent();
            CargarServicios();
        }

        private void CargarServicios()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerServicios";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvServicios.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar servicios: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new frmServicioAgregarEditar();
            frm.ShowDialog();
            CargarServicios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvServicios.CurrentRow.Cells["ServicioId"].Value);
                var frm = new frmServicioAgregarEditar(id);
                frm.ShowDialog();
                CargarServicios();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvServicios.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvServicios.CurrentRow.Cells["ServicioId"].Value);
                var confirm = MessageBox.Show("¿Seguro que deseas eliminar este servicio?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "EliminarServicio";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ServicioId", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        CargarServicios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar servicio: " + ex.Message);
                    }
                }
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarServicios();
        }
    }
}
