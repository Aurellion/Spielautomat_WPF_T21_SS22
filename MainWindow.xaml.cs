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
using System.Text.RegularExpressions;

namespace Spielautomat
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int guthaben = 5;
        public MainWindow()
        {
            InitializeComponent();
            
            TB_Guthaben.Text = guthaben.ToString();
        }

        //private void button_Message_Click(object sender, RoutedEventArgs e)
        //{
        //    string messageBoxText = "Hallo!";
        //    string messageBoxCaption = "Achtung";
        //    MessageBox.Show(messageBoxText, messageBoxCaption);
        //}

        private void B_Spiel_Click(object sender, RoutedEventArgs e)
        {
            Spielen();          
        }

        private void Spielen()
        {
            Random rnd = new Random();
            int einsatz, gewinn;
            einsatz = Convert.ToInt32(TBox_Einsatz.Text);
            int z1, z2, z3;

            if (einsatz <= 0) MessageBox.Show("Der Einsatz muss größer als Null sein!", "Falscher Einsatz");
            else if (einsatz > guthaben) MessageBox.Show("Nicht genug Guthaben.", "Falscher Einsatz");
            else
            {
                guthaben -= einsatz;
                TB_Guthaben.Text = guthaben.ToString();
                z1 = rnd.Next(1, 7);
                z2 = rnd.Next(1, 7);
                z3 = rnd.Next(1, 7);
                TB_Zahl1.Text = z1.ToString();
                TB_Zahl2.Text = z2.ToString();
                TB_Zahl3.Text = z3.ToString();

                if (z1 == z2 && z2 == z3)
                {
                    gewinn = einsatz * 3;
                    MessageBox.Show("Der Gewinn beträgt: " + gewinn, "Gewonnen!");
                    guthaben += gewinn;
                    TB_Guthaben.Text = guthaben.ToString();
                }
                else if (z1 == z2 || z1 == z3 || z2 == z3)
                {
                    gewinn = einsatz + 3;
                    MessageBox.Show("Der Gewinn beträgt: " + gewinn, "Gewonnen!");
                    guthaben += gewinn;
                    TB_Guthaben.Text = guthaben.ToString();
                }
                else
                {
                    MessageBox.Show("leider kein Gewinn.", "Schade...");
                }

            }


            if (guthaben == 0)
            {
                MessageBoxResult ergebnis;
                string messageboxtext = "Noch eine Runde?";
                string messageboxcaption = "Spiel Verloren";

                ergebnis = MessageBox.Show(messageboxtext, messageboxcaption, MessageBoxButton.YesNo);

                switch (ergebnis)
                {
                    case MessageBoxResult.Yes:
                        guthaben = 5;
                        TB_Guthaben.Text = "5";
                        TB_Zahl1.Text = "0";
                        TB_Zahl2.Text = "0";
                        TB_Zahl3.Text = "0";
                        break;
                    case MessageBoxResult.No:
                        Application.Current.Shutdown();
                        break;
                }
            }
        }

        private void ZahlenEingabeprüfung(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);

            //Bedeutung
            // ^ Beginn der Strings
            // [-+]? Vorzeichen
            // [0-9]* 0 oder mehr Ziffern
            // [0-9]+ 1 oder mehr ziffern
            // [a-z] alle Kleinbuchstaben
            // [A-Z] alle Großbuchstaben
            // [a-zA-Z] alle Buchstaben
            // . jedes beliebige Zeichen
            // \. Dezimalpunkt
            // [.,] Komma oder Punkt
            // $ Ende des Strings

            //Bsp ^[+-]?[0-9]*[.,]?[0-9]+$
        }

        private void TBox_Einsatz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Spielen();
        }
    }
}
