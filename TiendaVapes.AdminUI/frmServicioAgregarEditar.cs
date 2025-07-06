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
    public partial class frmServicioAgregarEditar : Form
    {
        private string connectionString = @"Data Source=DESKTOP-HGTU4PK\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;TrustServerCertificate=True;";
        private int? servicioId;

        public frmServicioAgregarEditar(int? id = null)
        {
            InitializeComponent();
            servicioId = id;

            if (servicioId.HasValue)
                CargarServicio();
        }

        private void CargarServicio()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerServicioPorId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ServicioId", servicioId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["Nombre"].ToString();
                                txtPrecio.Text = reader["Precio"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar servicio: " + ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            decimal precio = decimal.Parse(txtPrecio.Text);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = servicioId.HasValue ? "ActualizarServicio" : "InsertarServicio";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Precio", precio);

                        if (servicioId.HasValue)
                            cmd.Parameters.AddWithValue("@ServicioId", servicioId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Servicio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar servicio: " + ex.Message);
            }
        }
    }
}
