namespace ProyectoSubasta.Views
{
    partial class SubastasPostor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSubastas;
        private System.Windows.Forms.Button btnSalirSubasta;
        private System.Windows.Forms.Button btnVerDetalle;

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
            btnVerDetalle = new System.Windows.Forms.Button();
            btnSalirSubasta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).BeginInit();
            SuspendLayout();
            // 
            // dgvSubastas
            // 
            dgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubastas.Location = new System.Drawing.Point(12, 6);
            dgvSubastas.Name = "dgvSubastas";
            dgvSubastas.RowHeadersWidth = 51;
            dgvSubastas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.Size = new System.Drawing.Size(935, 478);
            dgvSubastas.TabIndex = 6;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new System.Drawing.Point(12, 490);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new System.Drawing.Size(157, 50);
            btnVerDetalle.TabIndex = 1;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnSalirSubasta
            // 
            btnSalirSubasta.Location = new System.Drawing.Point(776, 490);
            btnSalirSubasta.Name = "btnSalirSubasta";
            btnSalirSubasta.Size = new System.Drawing.Size(171, 50);
            btnSalirSubasta.TabIndex = 5;
            btnSalirSubasta.Text = "Salir de la Subasta";
            btnSalirSubasta.UseVisualStyleBackColor = true;
            btnSalirSubasta.Click += btnSalirSubasta_Click;
            // 
            // SubastasPostor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1048, 598);
            Controls.Add(dgvSubastas);
            Controls.Add(btnSalirSubasta);
            Controls.Add(btnVerDetalle);
            Name = "SubastasPostor";
            Text = "SubastaView";
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}