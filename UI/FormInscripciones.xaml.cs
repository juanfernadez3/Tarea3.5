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
using RegistroInscripcion1.Entidades;
using RegistroInscripcion1.BLL;

namespace RegistroInscripcion1.UI
{
    /// <summary>
    /// Lógica de interacción para FormInscripciones.xaml
    /// </summary>
    public partial class FormInscripciones : Window
    {
        public FormInscripciones()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            TextBoxInscripcionesId.Text = "0";
            DatePickerFechaInscripcion.SelectedDate = DateTime.Now;
            TextBoxPersonaId.Text = "0";
            TextBoxComentario.Text = string.Empty;
            TextBoxMonto.Text = string.Empty;
            TextBoxBalance.Text = string.Empty;
        }

        private Inscripciones LlenaClase()
        {
            Inscripciones inscripcion = new Inscripciones();

            inscripcion.InscripcionId = Convert.ToInt32(TextBoxInscripcionesId.Text);
            inscripcion.EstudianteID = Convert.ToInt32(TextBoxPersonaId.Text);
            inscripcion.Fecha = (DateTime)DatePickerFechaInscripcion.SelectedDate;
            inscripcion.Comentario = TextBoxComentario.Text;
            inscripcion.Monto = Convert.ToDecimal(TextBoxMonto.Text);
            inscripcion.Balance = Convert.ToDecimal(TextBoxBalance.Text);
            EstudiantesBLL.ActualizarBalance(int.Parse(TextBoxPersonaId.Text), inscripcion.Balance);

            return inscripcion;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Inscripciones inscripcion = InscripcionesBLL.Buscar(Convert.ToInt32(TextBoxInscripcionesId.Text));
            return (inscripcion != null);
        }

        private bool Validar() //Validar los campos
        {
            bool paso = true;

            if (string.IsNullOrEmpty(TextBoxPersonaId.Text))
            {
                MessageBox.Show("El campo PersonaId no puede estar vacio y debe ser mayor o igual que 1");
                TextBoxPersonaId.Focus();
                paso = false;
            }

            if (TextBoxComentario.Text == string.Empty)
            {
                MessageBox.Show("El campo comentario no puede estar vacio");
                TextBoxComentario.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TextBoxMonto.Text))
            {
                MessageBox.Show("El campo  monto no puede estar vacio");
                TextBoxBalance.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TextBoxBalance.Text))
            {
                MessageBox.Show("El campo balance no puede estar vacio");
                TextBoxBalance.Focus();
                paso = false;
            }

            return paso;
        }

       
        private void LlenaCampo(Inscripciones inscripcion)
        {
            TextBoxInscripcionesId.Text = Convert.ToString(inscripcion.InscripcionId);
            TextBoxPersonaId.Text = Convert.ToString(inscripcion.EstudianteID);
            TextBoxComentario.Text = inscripcion.Comentario;
            TextBoxMonto.Text = Convert.ToString(inscripcion.Monto);
            TextBoxBalance.Text = Convert.ToString(inscripcion.Balance);
            DatePickerFechaInscripcion.SelectedDate = (DateTime)inscripcion.Fecha;
        }

        private void btn_Buscar_Click(object sender, RoutedEventArgs e) //Buscar
        {
            int id;
            Inscripciones inscripcion = new Inscripciones();
            int.TryParse(TextBoxInscripcionesId.Text, out id);

            Limpiar();

            inscripcion = InscripcionesBLL.Buscar(id);

            if (inscripcion != null)
            {
                MessageBox.Show("Persona encontrada");
                LlenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripcion = new Inscripciones();
            int id;
            int.TryParse(TextBoxInscripcionesId.Text, out id);

            inscripcion = InscripcionesBLL.Buscar(id);
            EstudiantesBLL.ActualizarBalance(Convert.ToInt32(TextBoxPersonaId.Text), (0 * inscripcion.Balance));
            Limpiar();


            if (InscripcionesBLL.Eliminar(id))
            {

                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("ERROR", "No se puede eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
        }

       

        private void ButtonGuardar_Click_1(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripcion;
            bool paso = false;

            if (!Validar())
                return;

            inscripcion = LlenaClase();

            if (string.IsNullOrEmpty(TextBoxInscripcionesId.Text) || TextBoxInscripcionesId.Text == "0")
                paso = InscripcionesBLL.Guardar(inscripcion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("ERROR", "no se pudo modificar", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = InscripcionesBLL.Modificar(inscripcion);
            }

            //Informar resultado
            if (paso)
            {
                MessageBox.Show("Guardado!!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
                MessageBox.Show("ERROR", "no fue posible guardar", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Inscripciones inscripcion = new Inscripciones();
            int.TryParse(TextBoxInscripcionesId.Text, out id);

            Limpiar();

            inscripcion = InscripcionesBLL.Buscar(id);

            if (inscripcion != null)
            {
                LlenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion no encontrada", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
