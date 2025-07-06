using Microsoft.Data.SqlClient;
using System;
using System.Data;

using System.Windows.Forms;

namespace TiendaVapes.AdminUI
{
    public partial class LoginForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-HGTU4PK\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;TrustServerCertificate=True;";




        public LoginForm()
        {
            InitializeComponent();
        }


        private bool ValidarLogin(string usuario, string clave)
        {
            bool valido = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT PerfilId FROM Usuarios WHERE Nombre = @Nombre AND Clave = @Clave";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", usuario);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int perfilId = Convert.ToInt32(result);

                        // Suponiendo que PerfilId 1 es Administrador
                        if (perfilId == 1)
                        {
                            valido = true;
                        }
                    }
                }
            }

            return valido;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (ValidarLogin(usuario, clave))
            {
                MessageBox.Show("Login exitoso. Bienvenido administrador.", "Acceso permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre el formulario principal
                this.Hide();
                var mainForm = new MainForm();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas o no tiene permisos de administrador.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
