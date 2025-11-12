using ProyectoSubasta.Controllers;
using ProyectoSubasta.Repository;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace ProyectoSubasta.Views
{
    public partial class CrearUserView : Form
    {
        private readonly SubastadorController subastadorController;
        private readonly PostorController postorController;

        public int DniUsuarioLogueado { get; set; }
        public string RolUsuarioLogueado { get; set; }

        public CrearUserView(DBcontext context)
        {
            InitializeComponent();

            subastadorController = new SubastadorController(context);
            postorController = new PostorController(context);
            LlenarCombobox();
            ActualizarGrid();
        }

        private void LlenarCombobox()
        {
            comboBox1.Items.Add("Postor");
            comboBox1.Items.Add("Subastador");
            comboBox1.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!int.TryParse(txtDni.Text, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número.");
                return;
            }
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string rol = comboBox1.SelectedItem?.ToString();

            if (rol == "Postor")
            {
                bool ok = postorController.CrearPostor(dni, nombre, apellido);
                if (!ok) MessageBox.Show("Ya existe un postor con ese DNI.");
                else
                {
                    ActualizarGrid();
                    MessageBox.Show("Postor creado con éxito.");
                }
            }
            else if (rol == "Subastador")
            {
                bool ok = subastadorController.CrearSubastador(dni, nombre, apellido);
                if (!ok) MessageBox.Show("Ya existe un Subastador con ese DNI.");
                else
                {
                    MessageBox.Show("Subastador creado con éxito.");
                    ActualizarGrid();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol válido.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la grilla para eliminar.");
                return;
            }

            var fila = dgvUsuarios.CurrentRow;
            int dni = (int)fila.Cells["Dni"].Value;
            string rol = (string)fila.Cells["Rol"].Value;

            if (rol == "Postor")
            {
                bool ok = postorController.EliminarPostor(dni);
                if (!ok) MessageBox.Show("No existe un postor con ese DNI.");
                else
                {
                    ActualizarGrid();
                    MessageBox.Show("Postor eliminado");
                }
            }
            else if (rol == "Subastador")
            {
                bool ok = subastadorController.EliminarSubastador(dni);
                if (!ok) MessageBox.Show("No existe un Subastador con ese DNI.");
                else
                {
                    ActualizarGrid();
                    MessageBox.Show("Subastador eliminado");
                }
            }
        }

        private void ActualizarGrid()
        {
            var postores = postorController.ListarPostores();
            var subastadores = subastadorController.ListarSubastadores();

            var listaPostores = postores.Select(postor => new
            {
                Dni = postor.Dni,
                Nombre = postor.Nombre,
                Apellido = postor.Apellido,
                Rol = "Postor"
            });

            var listaSubastadores = subastadores.Select(subastador => new
            {
                Dni = subastador.Dni,
                Nombre = subastador.Nombre,
                Apellido = subastador.Apellido,
                Rol = "Subastador"
            });

            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaPostores.Concat(listaSubastadores).ToList();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la grilla para ingresar.");
                return;
            }

            var Fila = dgvUsuarios.CurrentRow;
            DniUsuarioLogueado = (int)Fila.Cells["Dni"].Value;
            RolUsuarioLogueado = (string)Fila.Cells["Rol"].Value;

            Close();
        }
    }
}
