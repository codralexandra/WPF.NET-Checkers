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
    /// Interaction logic for FileWindowView.xaml
    /// </summary>
    public partial class FileWindowView : Window
    {
        public FileWindowView()
        {
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindowView gameWindow = new GameWindowView();
            gameWindow.Show();
        }
    }
}
