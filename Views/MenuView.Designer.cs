namespace ProyectoSubasta.Views
{
    partial class MenuView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.Button btnVerSubastas;
        private System.Windows.Forms.Button btnMisSubastasPostor;
        private System.Windows.Forms.Button btnCrearSubasta;
        private System.Windows.Forms.Button btnMisSubastasSubastador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel_contenedor = new System.Windows.Forms.Panel();
            btnVerSubastas = new System.Windows.Forms.Button();
            btnMisSubastasPostor = new System.Windows.Forms.Button();
            btnCrearSubasta = new System.Windows.Forms.Button();
            btnMisSubastasSubastador = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // panel_contenedor
            // 
            panel_contenedor.Location = new System.Drawing.Point(6, 87);
            panel_contenedor.Name = "panel_contenedor";
            panel_contenedor.Size = new System.Drawing.Size(1193, 549);
            panel_contenedor.TabIndex = 0;
            // 
            // btnVerSubastas
            // 
            btnVerSubastas.Location = new System.Drawing.Point(3, 12);
            btnVerSubastas.Name = "btnVerSubastas";
            btnVerSubastas.Size = new System.Drawing.Size(122, 58);
            btnVerSubastas.TabIndex = 1;
            btnVerSubastas.Text = "Ver Todas Las Subastas";
            btnVerSubastas.UseVisualStyleBackColor = true;
            btnVerSubastas.Click += btnVerSubastas_Click;
            // 
            // btnMisSubastasPostor
            // 
            btnMisSubastasPostor.Location = new System.Drawing.Point(1078, 16);
            btnMisSubastasPostor.Name = "btnMisSubastasPostor";
            btnMisSubastasPostor.Size = new System.Drawing.Size(121, 58);
            btnMisSubastasPostor.TabIndex = 2;
            btnMisSubastasPostor.Text = "Mis Subastas";
            btnMisSubastasPostor.UseVisualStyleBackColor = true;
            btnMisSubastasPostor.Click += btnMisSubastasPostor_Click;
            // 
            // btnCrearSubasta
            // 
            btnCrearSubasta.Location = new System.Drawing.Point(309, 12);
            btnCrearSubasta.Name = "btnCrearSubasta";
            btnCrearSubasta.Size = new System.Drawing.Size(124, 62);
            btnCrearSubasta.TabIndex = 3;
            btnCrearSubasta.Text = "Crear Subasta";
            btnCrearSubasta.UseVisualStyleBackColor = true;
            btnCrearSubasta.Click += btnCrearSubasta_Click;
            // 
            // btnMisSubastasSubastador
            // 
            btnMisSubastasSubastador.Location = new System.Drawing.Point(636, 16);
            btnMisSubastasSubastador.Name = "btnMisSubastasSubastador";
            btnMisSubastasSubastador.Size = new System.Drawing.Size(148, 58);
            btnMisSubastasSubastador.TabIndex = 4;
            btnMisSubastasSubastador.Text = "Mis Subastas";
            btnMisSubastasSubastador.UseVisualStyleBackColor = true;
            // 
            // MenuView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1211, 634);
            Controls.Add(btnMisSubastasSubastador);
            Controls.Add(btnCrearSubasta);
            Controls.Add(btnVerSubastas);
            Controls.Add(btnMisSubastasPostor);
            Controls.Add(panel_contenedor);
            Name = "MenuView";
            Text = "MenuView";
            Load += MenuView_Load;
            ResumeLayout(false);
        }
    }
}