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

namespace WpfApp1Tema2___Checkers__New_.Views
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : Window
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindowView helpWindow = new HelpWindowView();
            helpWindow.Show();
        }

        private void fileButton_Click(Object sender, RoutedEventArgs e)
        {
            FileWindowView fileWindow = new FileWindowView();
            this.Close();
            fileWindow.Show();
        }
    }
}
