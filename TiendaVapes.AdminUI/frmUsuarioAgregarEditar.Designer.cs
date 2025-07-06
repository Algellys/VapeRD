namespace TiendaVapes.AdminUI
{
    partial class frmUsuarioAgregarEditar
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
            txtNombre = new TextBox();
            txtClave = new TextBox();
            cmbPerfil = new ComboBox();
            btnGuardar = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(115, 72);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(115, 105);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(125, 27);
            txtClave.TabIndex = 1;
            // 
            // cmbPerfil
            // 
            cmbPerfil.FormattingEnabled = true;
            cmbPerfil.Location = new Point(45, 154);
            cmbPerfil.Name = "cmbPerfil";
            cmbPerfil.Size = new Size(282, 28);
            cmbPerfil.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(95, 224);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(164, 53);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 72);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 108);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 5;
            label2.Text = "Clave";
            // 
            // frmUsuarioAgregarEditar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 354);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(cmbPerfil);
            Controls.Add(txtClave);
            Controls.Add(txtNombre);
            Name = "frmUsuarioAgregarEditar";
            Text = "frmUsuarioAgregarEditar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtClave;
        private ComboBox cmbPerfil;
        private Button btnGuardar;
        private Label label1;
        private Label label2;
    }
}