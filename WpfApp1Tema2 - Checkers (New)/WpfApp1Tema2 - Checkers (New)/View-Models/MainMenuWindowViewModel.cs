using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1Tema2___Checkers__New_.Commands;
using WpfApp1Tema2___Checkers__New_.Models;
using WpfApp1Tema2___Checkers__New_.Views;

namespace WpfApp1Tema2___Checkers__New_.View_Models
{
    public class MainMenuWindowViewModel
    {
        public ICommand OpenGameOptionsWindow { get; }
        public ICommand OpenAboutWindow { get; }

        public MainMenuWindowViewModel()
        {
            OpenGameOptionsWindow = new RelayCommand<object>(OpenGameOptions);
            OpenAboutWindow = new RelayCommand<object>(OpenAbout);
        }

        private void OpenGameOptions(object parameter)
        {
            FileWindowView fileWindow = new FileWindowView();
            fileWindow.Show();
        }

        private void OpenAbout(object parameter)
        {
            HelpWindowView helpWindow = new HelpWindowView();
            helpWindow.Show();
        }

    }
}
