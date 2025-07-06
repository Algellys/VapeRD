namespace TiendaVapes.AdminUI
{
    partial class frmCotizaciones
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
            dgvCotizaciones = new DataGridView();
            btnRefrescar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCotizaciones).BeginInit();
            SuspendLayout();
            // 
            // dgvCotizaciones
            // 
            dgvCotizaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCotizaciones.Location = new Point(53, 47);
            dgvCotizaciones.Name = "dgvCotizaciones";
            dgvCotizaciones.RowHeadersWidth = 51;
            dgvCotizaciones.Size = new Size(681, 206);
            dgvCotizaciones.TabIndex = 0;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(225, 297);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(325, 79);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "Actualizar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // frmCotizaciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefrescar);
            Controls.Add(dgvCotizaciones);
            Name = "frmCotizaciones";
            Text = "frmCotizaciones";
            ((System.ComponentModel.ISupportInitialize)dgvCotizaciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCotizaciones;
        private Button btnRefrescar;
    }
}