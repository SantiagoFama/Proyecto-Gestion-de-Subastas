namespace ProyectoSubasta.Views
{
    partial class CrearUserView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;

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
            txtDni = new System.Windows.Forms.TextBox();
            txtNombre = new System.Windows.Forms.TextBox();
            txtApellido = new System.Windows.Forms.TextBox();
            btnAgregar = new System.Windows.Forms.Button();
            btnEliminar = new System.Windows.Forms.Button();
            lblDni = new System.Windows.Forms.Label();
            lblNombre = new System.Windows.Forms.Label();
            lblApellido = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            dgvUsuarios = new System.Windows.Forms.DataGridView();
            btnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // txtDni
            // 
            txtDni.Location = new System.Drawing.Point(91, 16);
            txtDni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "DNI";
            txtDni.Size = new System.Drawing.Size(228, 27);
            txtDni.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new System.Drawing.Point(91, 55);
            txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new System.Drawing.Size(228, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.Location = new System.Drawing.Point(91, 93);
            txtApellido.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new System.Drawing.Size(228, 27);
            txtApellido.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new System.Drawing.Point(352, 15);
            btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new System.Drawing.Size(103, 31);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new System.Drawing.Point(352, 137);
            btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(103, 31);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new System.Drawing.Point(14, 20);
            lblDni.Name = "lblDni";
            lblDni.Size = new System.Drawing.Size(35, 20);
            lblDni.TabIndex = 7;
            lblDni.Text = "DNI";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(14, 59);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(64, 20);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new System.Drawing.Point(14, 96);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new System.Drawing.Size(66, 20);
            lblApellido.TabIndex = 9;
            lblApellido.Text = "Apellido";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(91, 137);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(228, 28);
            comboBox1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 137);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 20);
            label1.TabIndex = 11;
            label1.Text = "Rol";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new System.Drawing.Point(12, 229);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new System.Drawing.Size(443, 257);
            dgvUsuarios.TabIndex = 12;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new System.Drawing.Point(352, 74);
            btnIngresar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new System.Drawing.Size(103, 31);
            btnIngresar.TabIndex = 13;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // CrearUserView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 521);
            Controls.Add(btnIngresar);
            Controls.Add(dgvUsuarios);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblDni);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtDni);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "CrearUserView";
            Text = "Crear Usuario";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnIngresar;
    }
}