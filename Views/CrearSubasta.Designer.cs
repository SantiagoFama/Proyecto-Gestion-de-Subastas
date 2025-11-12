namespace ProyectoSubasta.Views
{
    partial class CrearSubasta
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox boxSubastadores;
        private System.Windows.Forms.NumericUpDown num_PrecioInicial;
        private System.Windows.Forms.NumericUpDown num_PrecioPuja;
        private System.Windows.Forms.DateTimePicker date_Fecha;
        private System.Windows.Forms.DateTimePicker date_Hora;
        private System.Windows.Forms.TextBox text_Articulo;
        private System.Windows.Forms.Button btn_Crear;
        private System.Windows.Forms.NumericUpDown numDuracion;

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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            boxSubastadores = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            num_PrecioInicial = new System.Windows.Forms.NumericUpDown();
            num_PrecioPuja = new System.Windows.Forms.NumericUpDown();
            date_Fecha = new System.Windows.Forms.DateTimePicker();
            label6 = new System.Windows.Forms.Label();
            date_Hora = new System.Windows.Forms.DateTimePicker();
            text_Articulo = new System.Windows.Forms.TextBox();
            btn_Crear = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            numDuracion = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)num_PrecioInicial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_PrecioPuja).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Artículo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 57);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "Subastador:";
            // 
            // boxSubastadores
            // 
            boxSubastadores.FormattingEnabled = true;
            boxSubastadores.Location = new System.Drawing.Point(114, 54);
            boxSubastadores.Name = "boxSubastadores";
            boxSubastadores.Size = new System.Drawing.Size(151, 28);
            boxSubastadores.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 107);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(96, 20);
            label3.TabIndex = 3;
            label3.Text = "Precio Inicial:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 156);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 20);
            label4.TabIndex = 4;
            label4.Text = "Precio Puja:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 210);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(50, 20);
            label5.TabIndex = 5;
            label5.Text = "Fecha:";
            // 
            // num_PrecioInicial
            // 
            num_PrecioInicial.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            num_PrecioInicial.Location = new System.Drawing.Point(114, 107);
            num_PrecioInicial.Name = "num_PrecioInicial";
            num_PrecioInicial.Size = new System.Drawing.Size(150, 27);
            num_PrecioInicial.TabIndex = 6;
            // 
            // num_PrecioPuja
            // 
            num_PrecioPuja.Location = new System.Drawing.Point(114, 154);
            num_PrecioPuja.Name = "num_PrecioPuja";
            num_PrecioPuja.Size = new System.Drawing.Size(150, 27);
            num_PrecioPuja.TabIndex = 7;
            // 
            // date_Fecha
            // 
            date_Fecha.Location = new System.Drawing.Point(114, 210);
            date_Fecha.Name = "date_Fecha";
            date_Fecha.Size = new System.Drawing.Size(250, 27);
            date_Fecha.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 261);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 20);
            label6.TabIndex = 10;
            label6.Text = "Hora:";
            // 
            // date_Hora
            // 
            date_Hora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            date_Hora.Location = new System.Drawing.Point(114, 261);
            date_Hora.Name = "date_Hora";
            date_Hora.ShowUpDown = true;
            date_Hora.Size = new System.Drawing.Size(250, 27);
            date_Hora.TabIndex = 11;
            // 
            // text_Articulo
            // 
            text_Articulo.Location = new System.Drawing.Point(114, 12);
            text_Articulo.Name = "text_Articulo";
            text_Articulo.Size = new System.Drawing.Size(151, 27);
            text_Articulo.TabIndex = 12;
            // 
            // btn_Crear
            // 
            btn_Crear.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Crear.Location = new System.Drawing.Point(12, 371);
            btn_Crear.Name = "btn_Crear";
            btn_Crear.Size = new System.Drawing.Size(96, 44);
            btn_Crear.TabIndex = 13;
            btn_Crear.Text = "Crear";
            btn_Crear.UseVisualStyleBackColor = true;
            btn_Crear.Click += crear_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 322);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(72, 20);
            label7.TabIndex = 14;
            label7.Text = "Duración:";
            // 
            // numDuracion
            // 
            numDuracion.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numDuracion.Location = new System.Drawing.Point(115, 320);
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new System.Drawing.Size(150, 27);
            numDuracion.TabIndex = 17;
            // 
            // CrearSubasta
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(numDuracion);
            Controls.Add(label7);
            Controls.Add(btn_Crear);
            Controls.Add(text_Articulo);
            Controls.Add(date_Hora);
            Controls.Add(label6);
            Controls.Add(date_Fecha);
            Controls.Add(num_PrecioPuja);
            Controls.Add(num_PrecioInicial);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(boxSubastadores);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CrearSubasta";
            Text = "CreacionSubasta";
            Load += CrearSubasta_Load;
            ((System.ComponentModel.ISupportInitialize)num_PrecioInicial).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_PrecioPuja).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


    }
}