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
    public partial class frmUsuarioAgregarEditar : Form
    {
        private string connectionString = @"Data Source=DESKTOP-HGTU4PK\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;TrustServerCertificate=True;";
        private int? usuarioId;

        public frmUsuarioAgregarEditar(int? id = null)
        {
            InitializeComponent();
            usuarioId = id;
            CargarPerfiles();

            if (usuarioId.HasValue)
                CargarUsuario();
        }
        private void CargarPerfiles()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerPerfiles";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            cmbPerfil.DataSource = dt;
                            cmbPerfil.DisplayMember = "Nombre";
                            cmbPerfil.ValueMember = "PerfilId";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar perfiles: " + ex.Message);
            }
        }
        private void CargarUsuario()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerUsuarioPorId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["Nombre"].ToString();
                                txtClave.Text = reader["Clave"].ToString();
                                cmbPerfil.SelectedValue = Convert.ToInt32(reader["PerfilId"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuario: " + ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string clave = txtClave.Text.Trim();
            int perfilId = Convert.ToInt32(cmbPerfil.SelectedValue);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = usuarioId.HasValue ? "ActualizarUsuario" : "InsertarUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Clave", clave);
                        cmd.Parameters.AddWithValue("@PerfilId", perfilId);

                        if (usuarioId.HasValue)
                            cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message);
            }
        }
    }
}
