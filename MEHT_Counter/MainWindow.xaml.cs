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

namespace MEHT_Counter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Copyright(c) 2019 Jan Koranda\n\n"

+ "Permission is hereby granted, free of charge, to any person\n"
+ "obtaining a copy of this software and associated documentation\n"
+ "files(the 'Software'), to deal in the Software without\n"
+ "restriction, including without limitation the rights to use,\n"
+ "copy, modify, merge, publish, distribute, sublicense, and / or sell\n"
+ "copies of the Software, and to permit persons to whom the\n"
+ "Software is furnished to do so, subject to the following\n"
+ "conditions:\n"
+ "\n"
+ "THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,\n"
+ "EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES\n"
+ "OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND\n"
+ "NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT\n"
+ "HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,\n"
+ "WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING\n"
+ "FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR\n"
+ "OTHER DEALINGS IN THE SOFTWARE.");

        }

        private void CountMehtClick(object sender, RoutedEventArgs e)
        {
            double degree = 0;
            double minute = 0;
            double second = 0;
            double papiThr = 0;
            double papiAlt = 0;
            double thrAlt = 0;
            bool inputsOk = true;
            DigitValidator validator = new DigitValidator();

            if (validator.isNumeric(Degrees.Text))
            {
                Double.TryParse(Degrees.Text, out degree);
            }
            else
            {
                MessageBox.Show("Do pole Stupne jste nezadali celé číslo.");
                inputsOk = false;
            }

            if (validator.isNumeric(Minutes.Text))
            {
                Double.TryParse(Minutes.Text, out minute);
            }
            else
            {
                MessageBox.Show("Do pole Minuty jste nezadali celé číslo.");
                inputsOk = false;
            }

            if (validator.isNumeric(Seconds.Text))
            {
                Double.TryParse(Seconds.Text, out second);

            }
            else
            {
                MessageBox.Show("Do pole Vteřiny jste nezadali celé číslo.");
                inputsOk = false;
            }

            if (validator.validateDigits(PapiThrDistance.Text))
            {
                Console.WriteLine("ok");
                if (validator.checkIfDotSeparated(PapiThrDistance.Text))
                {
                    papiThr = double.Parse(PapiThrDistance.Text, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    Double.TryParse(PapiThrDistance.Text, out papiThr);
                }
            }
            else
            {
                MessageBox.Show("Do pole Vzdálenost PAPI od Prahu dráhy jste nezadali číselnou hodnotu.");
                inputsOk = false;
            }

            if (validator.validateDigits(PapiAltitude.Text))
            {
                Console.WriteLine("ok");
                if (validator.checkIfDotSeparated(PapiAltitude.Text))
                {
                    papiAlt = double.Parse(PapiAltitude.Text, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    Double.TryParse(PapiAltitude.Text, out papiAlt);
                }
            }
            else
            {
                MessageBox.Show("Do pole 'Papi Altitude' jste nezadali číselnou hodnotu.");
                inputsOk = false;
            }


            if (validator.validateDigits(RwyTheresholdAltitude.Text))
            {
                Console.WriteLine("ok");
                if (validator.checkIfDotSeparated(RwyTheresholdAltitude.Text))
                {
                    thrAlt = double.Parse(RwyTheresholdAltitude.Text, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    Double.TryParse(RwyTheresholdAltitude.Text, out thrAlt);
                }
            }
            else
            {
                MessageBox.Show("Do pole 'RWY THR Altitude' jste nezadali číselnou hodnotu.");
                inputsOk = false;
            }

            if (inputsOk)
            {
                MehtCounter counter = new MehtCounter(degree, minute, second, papiThr, papiAlt, thrAlt);
                MehtMetres.Content = (counter.CountMehtInMeter()).ToString() + " m";
                MehtFeet.Content = (counter.ConvertMehtIntoFeet()).ToString() + " ft";
            }


        }

        private void RwyTheresholdAltitude_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            curApp.Shutdown();
        }

        private void EraseClick(object sender, RoutedEventArgs e)
        {
            MehtFeet.Content = "";
            MehtMetres.Content = "";
            Degrees.Text = "0";
            Minutes.Text = "0";
            Seconds.Text = "0";
            PapiAltitude.Text = "0";
            PapiThrDistance.Text = "0";
            RwyTheresholdAltitude.Text = "0";
        }
    }
}




