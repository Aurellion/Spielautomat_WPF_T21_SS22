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
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void button_Message_Click(object sender, RoutedEventArgs e)
        //{
        //    string messageBoxText = "Hallo!";
        //    string messageBoxCaption = "Achtung";
        //    MessageBox.Show(messageBoxText, messageBoxCaption);
        //}

        private void B_Spiel_Click(object sender, RoutedEventArgs e)
        {
            TB_Zahl1.Text = "5";
        }
    }
}
