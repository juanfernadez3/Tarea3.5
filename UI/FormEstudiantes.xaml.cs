using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroInscripcion1.BLL;
using RegistroInscripcion1.Entidades;

namespace RegistroInscripcion1.UI
{
    /// <summary>
    /// Lógica de interacción para FormEstudiantes.xaml
    /// </summary>
    public partial class FormEstudiantes : Window
    {
        public FormEstudiantes()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            EstudianteIDTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDatePicker.SelectedDate = DateTime.Now;
        }

        private Estudiantes LlenaClase()
        {
            Estudiantes estudiante = new Estudiantes();

            estudiante.EstudianteId = Convert.ToInt32(EstudianteIDTextBox.Text);
            estudiante.Nombre = NombreTextBox.Text;
            estudiante.Telefono = TelefonoTextBox.Text;
            estudiante.Cedula = CedulaTextBox.Text;
            estudiante.Direccion = DireccionTextBox.Text;
            estudiante.FechaNacimiento = (DateTime)FechaNacimientoDatePicker.SelectedDate;
            estudiante.Balance = Convert.ToDecimal(TextBoxBalance.Text);
            return estudiante;
        }

        private void LlenaCampo(Estudiantes estudiantes)
        {
            EstudianteIDTextBox.Text = Convert.ToString(estudiantes.EstudianteId);
            NombreTextBox.Text = estudiantes.Nombre;
            CedulaTextBox.Text = estudiantes.Cedula;
            TelefonoTextBox.Text = estudiantes.Telefono;
            DireccionTextBox.Text = estudiantes.Direccion;
            FechaNacimientoDatePicker.SelectedDate = estudiantes.FechaNacimiento;
            TextBoxBalance.Text = Convert.ToString(estudiantes.Balance);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Estudiantes estudiantes = EstudiantesBLL.Buscar(Convert.ToInt32(EstudianteIDTextBox.Text));
            return (estudiantes != null);
        }

        private bool Validar() //Validar los campos
        {
            bool paso = true;
            if (string.IsNullOrEmpty(EstudianteIDTextBox.Text))
            {
                MessageBox.Show("El campo PersonaID debe estar en 0 para agregar una nueva persona");
                EstudianteIDTextBox.Focus();
                paso = false;
            }

            if (NombreTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo direccion no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(CedulaTextBox.Text))
            {
                MessageBox.Show("El campo  cedula no puede estar vacio");
                CedulaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TelefonoTextBox.Text))
            {
                MessageBox.Show("El campo telefono no puede estar vacio");
                TelefonoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                MessageBox.Show("El campo direccion no puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }
            return paso;
        }
        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Estudiantes estudiantes = new Estudiantes();
            int.TryParse(EstudianteIDTextBox.Text, out id);

            Limpiar();

            estudiantes = EstudiantesBLL.Buscar(id);

            if (estudiantes != null)
            {
                MessageBox.Show("Persona encontrada");
                LlenaCampo(estudiantes);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Estudiantes estudiantes;
            bool paso = false;

            if (!Validar())
                return;

            estudiantes = LlenaClase();

            if (string.IsNullOrEmpty(EstudianteIDTextBox.Text) || EstudianteIDTextBox.Text == "0")
                paso = EstudiantesBLL.Guardar(estudiantes);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = EstudiantesBLL.Modificar(estudiantes);
            }

            //Informar resultado
            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(EstudianteIDTextBox.Text, out id);
            Limpiar();

            if (EstudiantesBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("No se puede eliminar una persona que no existe");
            }
        }

        private void ButtonNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
