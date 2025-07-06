namespace TiendaVapes.AdminUI
{
    partial class frmServicioAgregarEditar
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
            txtPrecio = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(161, 195);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(153, 27);
            txtPrecio.TabIndex = 10;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(161, 117);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(153, 27);
            txtNombre.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 195);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 8;
            label2.Text = "Precio";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 113);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 7;
            label1.Text = "Nombre";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(187, 265);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // frmServicioAgregarEditar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 387);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Name = "frmServicioAgregarEditar";
            Text = "frmServicioAgregarEditar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrecio;
        private TextBox txtNombre;
        private Label label2;
        private Label label1;
        private Button btnGuardar;
    }
}