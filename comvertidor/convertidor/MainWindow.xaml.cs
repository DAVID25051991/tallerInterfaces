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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace convertidor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Mostrar u ocultar los controles según la selección del ComboBox
            string opcionSeleccionada = ((ComboBoxItem)opcionSeleccionada.SelectedItem)?.Content.ToString();

            switch (opcionSeleccionada)
            {
                case "Longitud":
                    unid1.Text = "Metros:";
                    unid2.Text = "Pies:";
                    break;
                case "Peso":
                    unid1.Text = "Kilogramos:";
                    unid2.Text = "Libras:";
                    break;
                case "Temperatura":
                    unid1.Text = "Celsius:";
                    unid2.Text = "Fahrenheit:";
                    break;
                default:
                    unid1.Text = string.Empty;
                    unid2.Text = string.Empty;
                    break;
            }
        }

        private void Convertir_Click(object sender, RoutedEventArgs e)
        {
            string opcionSeleccionada = ((ComboBoxItem)opcionSeleccionada.SelectedItem)?.Content.ToString();

            double valor;
            if (!double.TryParse(unidad1.Text, out valor))
            {
                MessageBox.Show("Ingrese un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double resultado = 0;

            switch (opcionSeleccionada)
            {
                case "Longitud":
                    resultado = ConvertirLongitud(valor);
                    break;
                case "Peso":
                    resultado = ConvertirPeso(valor);
                    break;
                case "Temperatura":
                    resultado = ConvertirTemperatura(valor);
                    break;
                default:
                    MessageBox.Show("Seleccione una opción válida de conversión.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }

            unidad2.Text = resultado.ToString("F2");
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private double ConvertirLongitud(double metros)
        {
            return metros * 3.281; // Convertir metros a pies
        }

        private double ConvertirPeso(double kilogramos)
        {
            return kilogramos * 2.205; // Convertir kilogramos a libras
        }

        private double ConvertirTemperatura(double celsius)
        {
            return (celsius * 9 / 5) + 32; // Convertir Celsius a Fahrenheit
        }
    }
}