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
            Random rnd = new Random();
            int einsatz, gewinn;
            einsatz = Convert.ToInt32(TBox_Einsatz.Text);
            int z1, z2, z3;

            if (einsatz <= 0) MessageBox.Show("Der Einsatz muss größer als Null sein!", "Falscher Einsatz");
            else if (einsatz > guthaben) MessageBox.Show("Nicht genug Guthaben.","Falscher Einsatz");
            else
            {
                guthaben -= einsatz;
                TB_Guthaben.Text = guthaben.ToString();
                z1 = rnd.Next(0, 10);
                z2 = rnd.Next(0, 10);
                z3 = rnd.Next(0, 10);
                TB_Zahl1.Text = z1.ToString();
                TB_Zahl2.Text = z2.ToString();
                TB_Zahl3.Text = z3.ToString();

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
                        //Textbox anpassen
                        break;
                    case MessageBoxResult.No:
                        Application.Current.Shutdown();
                        break;
                }
            }
        }
    }
}
