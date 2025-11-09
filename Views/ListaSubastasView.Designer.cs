namespace ProyectoSubasta.Views
{
    partial class ListaSubastasView
    {
        private System.Windows.Forms.DataGridView dgvSubastas;
        private System.Windows.Forms.Button btn_IngresarSubasta;
        private System.Windows.Forms.Button btn_eliminar;
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
            btn_eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).BeginInit();
            SuspendLayout();
            // 
            // dgvSubastas
            // 
            dgvSubastas.AllowUserToAddRows = false;
            dgvSubastas.AllowUserToDeleteRows = false;
            dgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubastas.Location = new System.Drawing.Point(5, 3);
            dgvSubastas.MultiSelect = false;
            dgvSubastas.Name = "dgvSubastas";
            dgvSubastas.RowHeadersWidth = 51;
            dgvSubastas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.Size = new System.Drawing.Size(1008, 409);
            dgvSubastas.TabIndex = 0;
            // 
            // btn_IngresarSubasta
            // 
            btn_IngresarSubasta.Location = new System.Drawing.Point(5, 418);
            btn_IngresarSubasta.Name = "btn_IngresarSubasta";
            btn_IngresarSubasta.Size = new System.Drawing.Size(167, 48);
            btn_IngresarSubasta.TabIndex = 1;
            btn_IngresarSubasta.Text = "Ingresar a Subasta";
            btn_IngresarSubasta.UseVisualStyleBackColor = true;
            btn_IngresarSubasta.Click += btn_AbrirSubasta_Click;
            // 
            // btn_eliminar
            // 
            btn_eliminar.Location = new System.Drawing.Point(913, 418);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new System.Drawing.Size(94, 48);
            btn_eliminar.TabIndex = 3;
            btn_eliminar.Text = "Eliminar Subasta";
            btn_eliminar.UseVisualStyleBackColor = true;
            btn_eliminar.Click += btn_EliminarSubasta_Click;
            // 
            // ListaSubastasView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1019, 631);
            Controls.Add(btn_eliminar);
            Controls.Add(btn_IngresarSubasta);
            Controls.Add(dgvSubastas);
            Name = "ListaSubastasView";
            Text = "ListaSubastasView";
            Load += ListaSubastasView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}