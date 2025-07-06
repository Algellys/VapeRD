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
    public partial class frmCotizaciones : Form
    {
        private string connectionString = @"Data Source=DESKTOP-HGTU4PK\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;TrustServerCertificate=True;";

        public frmCotizaciones()
        {
            InitializeComponent();
            CargarCotizaciones();
        }

        private void CargarCotizaciones()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerCotizaciones";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvCotizaciones.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cotizaciones: " + ex.Message);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarCotizaciones();
        }
    }
}
