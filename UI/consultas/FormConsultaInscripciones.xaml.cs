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

namespace RegistroInscripcion1.UI.consultas
{
    /// <summary>
    /// Lógica de interacción para FormConsultaInscripciones.xaml
    /// </summary>
    public partial class FormConsultaInscripciones : Window
    {
        public FormConsultaInscripciones()
        {
            InitializeComponent();
        }
        private void ButtonConsultarInscripcion_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Inscripciones>();
            if (TextBoxCriterio.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = InscripcionesBLL.GetList(p => true);
                        break;

                    case 1:
                        int id = int.Parse(TextBoxCriterio.Text);
                        listado = InscripcionesBLL.GetList(p => p.InscripcionId == id);
                        break;

                    case 2:
                        int personaId = int.Parse(TextBoxCriterio.Text);
                        listado = InscripcionesBLL.GetList(p => p.EstudianteID == personaId);
                        break;

                    case 3:
                        decimal monto = decimal.Parse(TextBoxCriterio.Text);
                        listado = InscripcionesBLL.GetList(p => p.Monto == monto);
                        break;

                    case 4:
                        decimal balance = decimal.Parse(TextBoxCriterio.Text);
                        listado = InscripcionesBLL.GetList(p => p.Balance == balance);
                        break;
                }
            }
            else
            {
                listado = InscripcionesBLL.GetList(p => true);
            }
            ConsultaDataGridView.ItemsSource = null;
            ConsultaDataGridView.ItemsSource = listado;
        }
    }
}
