namespace ProyectoSubasta.Views
{
    partial class SubastasSubastador
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
            dgvSubastas = new System.Windows.Forms.DataGridView();
            btnFinalizar = new System.Windows.Forms.Button();
            btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).BeginInit();
            SuspendLayout();
            // 
            // dgvSubastas
            // 
            dgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubastas.Location = new System.Drawing.Point(2, 2);
            dgvSubastas.Name = "dgvSubastas";
            dgvSubastas.RowHeadersWidth = 51;
            dgvSubastas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.Size = new System.Drawing.Size(937, 477);
            dgvSubastas.TabIndex = 7;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new System.Drawing.Point(2, 485);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new System.Drawing.Size(175, 56);
            btnFinalizar.TabIndex = 8;
            btnFinalizar.Text = "Finalizar Subasta";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new System.Drawing.Point(770, 485);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(169, 56);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Subasta";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // SubastasSubastador
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(942, 597);
            Controls.Add(btnEliminar);
            Controls.Add(btnFinalizar);
            Controls.Add(dgvSubastas);
            Name = "SubastasSubastador";
            Text = "SubastasSubastador";
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubastas;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnEliminar;
    }
}