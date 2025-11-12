namespace ProyectoSubasta.Views
{
    partial class ListaSubastasView
    {
        private System.Windows.Forms.DataGridView dgvSubastas;
        private System.Windows.Forms.Button btn_IngresarSubasta;
        private System.Windows.Forms.Label labelTitulo;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            dgvSubastas = new System.Windows.Forms.DataGridView();
            btn_IngresarSubasta = new System.Windows.Forms.Button();
            labelTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).BeginInit();
            SuspendLayout();
            // 
            // dgvSubastas
            // 
            dgvSubastas.AllowUserToAddRows = false;
            dgvSubastas.AllowUserToDeleteRows = false;
            dgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubastas.Location = new System.Drawing.Point(12, 47);
            dgvSubastas.MultiSelect = false;
            dgvSubastas.Name = "dgvSubastas";
            dgvSubastas.RowHeadersWidth = 51;
            dgvSubastas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.Size = new System.Drawing.Size(1008, 409);
            dgvSubastas.TabIndex = 0;
            // 
            // btn_IngresarSubasta
            // 
            btn_IngresarSubasta.Location = new System.Drawing.Point(12, 462);
            btn_IngresarSubasta.Name = "btn_IngresarSubasta";
            btn_IngresarSubasta.Size = new System.Drawing.Size(167, 48);
            btn_IngresarSubasta.TabIndex = 1;
            btn_IngresarSubasta.Text = "Ingresar a la Subasta";
            btn_IngresarSubasta.UseVisualStyleBackColor = true;
            btn_IngresarSubasta.Click += btn_IngresarSubasta_Click;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Location = new System.Drawing.Point(425, 9);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(183, 20);
            labelTitulo.TabIndex = 4;
            labelTitulo.Text = "Lista de todas las subastas";
            // 
            // ListaSubastasView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1115, 547);
            Controls.Add(labelTitulo);
            Controls.Add(btn_IngresarSubasta);
            Controls.Add(dgvSubastas);
            Name = "ListaSubastasView";
            Text = "ListaSubastasView";
            Load += ListaSubastasView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}