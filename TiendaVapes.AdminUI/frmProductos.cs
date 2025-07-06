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
    public partial class frmProductos : Form
    {
        private string connectionString = "Data Source=DESKTOP-HGTU4PK\\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True;";



        public frmProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerProductos"; // SP que retorna todos los productos

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvProductos.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new frmProductoAgregarEditar();
            frm.ShowDialog();
            CargarProductos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["ProductoId"].Value);
                var frm = new frmProductoAgregarEditar(id); // constructor con id para edición
                frm.ShowDialog();
                CargarProductos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["ProductoId"].Value);
                var confirm = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "EliminarProducto";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ProductoId", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar producto: " + ex.Message);
                    }
                }
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }
    }
}

