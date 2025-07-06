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
    public partial class frmFacturaAgregarEditar : Form
    {
        private string connectionString = @"Data Source=DESKTOP-HGTU4PK\SQLEXPRESS02;Initial Catalog=BDCore;Integrated Security=True;TrustServerCertificate=True;";
        private int? facturaId;

        public frmFacturaAgregarEditar(int? id = null)
        {
            InitializeComponent();
            facturaId = id;
            CargarClientes();

            if (facturaId.HasValue)
                CargarFactura();
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
                            cmbCliente.DataSource = dt;
                            cmbCliente.DisplayMember = "Nombre";
                            cmbCliente.ValueMember = "ClienteId";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
        private void CargarFactura()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "ObtenerFacturaPorId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacturaId", facturaId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmbCliente.SelectedValue = Convert.ToInt32(reader["ClienteId"]);
                                txtTotal.Text = reader["Total"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar factura: " + ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(cmbCliente.SelectedValue);
            decimal total = decimal.Parse(txtTotal.Text);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = facturaId.HasValue ? "ActualizarFactura" : "InsertarFactura";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                        cmd.Parameters.AddWithValue("@Total", total);

                        if (facturaId.HasValue)
                            cmd.Parameters.AddWithValue("@FacturaId", facturaId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Factura guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar factura: " + ex.Message);
            }
        }
    }
}
