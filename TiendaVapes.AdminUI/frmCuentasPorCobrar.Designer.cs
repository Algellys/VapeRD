namespace TiendaVapes.AdminUI
{
    partial class frmCuentasPorCobrar
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
            btnRefrescar = new Button();
            dgvCuentasPorCobrar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCuentasPorCobrar).BeginInit();
            SuspendLayout();
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(232, 311);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(325, 79);
            btnRefrescar.TabIndex = 3;
            btnRefrescar.Text = "Actualizar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // dgvCuentasPorCobrar
            // 
            dgvCuentasPorCobrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentasPorCobrar.Location = new Point(60, 61);
            dgvCuentasPorCobrar.Name = "dgvCuentasPorCobrar";
            dgvCuentasPorCobrar.RowHeadersWidth = 51;
            dgvCuentasPorCobrar.Size = new Size(681, 206);
            dgvCuentasPorCobrar.TabIndex = 2;
            // 
            // frmCuentasPorCobrar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefrescar);
            Controls.Add(dgvCuentasPorCobrar);
            Name = "frmCuentasPorCobrar";
            Text = "frmCuentasPorCobrar";
            ((System.ComponentModel.ISupportInitialize)dgvCuentasPorCobrar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefrescar;
        private DataGridView dgvCuentasPorCobrar;
    }
}