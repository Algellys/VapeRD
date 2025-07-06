namespace TiendaVapes.AdminUI
{
    partial class frmClienteAgregarEditar
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
            btnGuardar = new Button();
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            txtDocumento = new TextBox();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(113, 252);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(122, 41);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 105);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 161);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 2;
            label2.Text = "Documento";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(174, 109);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(141, 27);
            txtNombre.TabIndex = 3;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(174, 154);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(141, 27);
            txtDocumento.TabIndex = 4;
            // 
            // frmClienteAgregarEditar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 318);
            Controls.Add(txtDocumento);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Name = "frmClienteAgregarEditar";
            Text = "frmClienteAgregarEditar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private TextBox txtDocumento;
    }
}