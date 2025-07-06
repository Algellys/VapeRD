namespace TiendaVapes.AdminUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProductos = new Button();
            panel1 = new Panel();
            btnCuentasPorCobrar = new Button();
            btnVerCotizaciones = new Button();
            btnServicios = new Button();
            btnFacturas = new Button();
            btnClientes = new Button();
            btnUsuarios = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnProductos
            // 
            btnProductos.Location = new Point(3, 3);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(248, 43);
            btnProductos.TabIndex = 0;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCuentasPorCobrar);
            panel1.Controls.Add(btnVerCotizaciones);
            panel1.Controls.Add(btnServicios);
            panel1.Controls.Add(btnFacturas);
            panel1.Controls.Add(btnClientes);
            panel1.Controls.Add(btnUsuarios);
            panel1.Controls.Add(btnProductos);
            panel1.Location = new Point(12, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(251, 429);
            panel1.TabIndex = 1;
            // 
            // btnCuentasPorCobrar
            // 
            btnCuentasPorCobrar.Location = new Point(3, 297);
            btnCuentasPorCobrar.Name = "btnCuentasPorCobrar";
            btnCuentasPorCobrar.Size = new Size(248, 43);
            btnCuentasPorCobrar.TabIndex = 6;
            btnCuentasPorCobrar.Text = "Ver Cuentas Por Cobrar\r\n";
            btnCuentasPorCobrar.UseVisualStyleBackColor = true;
            btnCuentasPorCobrar.Click += btnCuentasPorCobrar_Click;
            // 
            // btnVerCotizaciones
            // 
            btnVerCotizaciones.Location = new Point(3, 248);
            btnVerCotizaciones.Name = "btnVerCotizaciones";
            btnVerCotizaciones.Size = new Size(248, 43);
            btnVerCotizaciones.TabIndex = 5;
            btnVerCotizaciones.Text = "Ver Cotizaciones";
            btnVerCotizaciones.UseVisualStyleBackColor = true;
            btnVerCotizaciones.Click += btnVerCotizaciones_Click;
            // 
            // btnServicios
            // 
            btnServicios.Location = new Point(3, 199);
            btnServicios.Name = "btnServicios";
            btnServicios.Size = new Size(248, 43);
            btnServicios.TabIndex = 4;
            btnServicios.Text = "Servicios";
            btnServicios.UseVisualStyleBackColor = true;
            btnServicios.Click += btnServicios_Click;
            // 
            // btnFacturas
            // 
            btnFacturas.Location = new Point(3, 150);
            btnFacturas.Name = "btnFacturas";
            btnFacturas.Size = new Size(248, 43);
            btnFacturas.TabIndex = 3;
            btnFacturas.Text = "Facturas";
            btnFacturas.UseVisualStyleBackColor = true;
            btnFacturas.Click += btnFacturas_Click;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(3, 101);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(248, 43);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(3, 52);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(248, 43);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "MainForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnProductos;
        private Panel panel1;
        private Button btnUsuarios;
        private Button btnClientes;
        private Button btnFacturas;
        private Button btnServicios;
        private Button btnVerCotizaciones;
        private Button btnCuentasPorCobrar;
    }
}