namespace TiendaVapes.AdminUI
{
    partial class frmFacturaAgregarEditar
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
            cmbCliente = new ComboBox();
            txtTotal = new TextBox();
            btnGuardar = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(84, 67);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(148, 28);
            cmbCliente.TabIndex = 0;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(106, 120);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(104, 27);
            txtTotal.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(84, 190);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(148, 36);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 121);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 3;
            label1.Text = "Total";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 70);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 4;
            label2.Text = "Cliente";
            // 
            // frmFacturaAgregarEditar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 283);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(txtTotal);
            Controls.Add(cmbCliente);
            Name = "frmFacturaAgregarEditar";
            Text = "frmFacturaAgregarEditar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCliente;
        private TextBox txtTotal;
        private Button btnGuardar;
        private Label label1;
        private Label label2;
    }
}