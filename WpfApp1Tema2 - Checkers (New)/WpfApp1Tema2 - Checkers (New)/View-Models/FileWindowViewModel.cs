using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1Tema2___Checkers__New_.Commands;
using WpfApp1Tema2___Checkers__New_.Models;
using WpfApp1Tema2___Checkers__New_.Service;
using WpfApp1Tema2___Checkers__New_.Views;

namespace WpfApp1Tema2___Checkers__New_.View_Models
{
    public class FileWindowViewModel : BaseNotification
    {
        public bool AllowMultipleJump { get; set; }
        public GameLogic GameLogic { get; set; }

        public ICommand OpenGameCommand { get; }

        public ICommand OpenSaveCommand { get; }
        public ICommand OpenStatisticsCommand { get; }

        public FileWindowViewModel()
        {
            OpenGameCommand = new RelayCommand<object>(OpenGameWindow);
            OpenSaveCommand = new RelayCommand<object>(OpenSavedGame);
            OpenStatisticsCommand = new RelayCommand<object>(OpenStatistics);
            OpenSaveCommand = new RelayCommand<object>(OpenSavedGame);
        }

        private void OpenGameWindow(object parameter)
        {
            var gameWindowViewModel = new GameWindowViewModel(this);
            var gameWindow = new GameWindowView();
            gameWindow.DataContext = gameWindowViewModel;
            gameWindow.Show();
        }

        private void OpenSavedGame(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                GameLogic = SerializationActions.OpenGame(filename);

                var gameWindowViewModel = new GameWindowViewModel(GameLogic);

                // Create and display the GameWindowView
                var gameWindow = new GameWindowView();
                gameWindow.DataContext = gameWindowViewModel;
                gameWindow.Show();
            }   
        }

        private void OpenStatistics(object parameter)
        {
            StatisticsWindowView statisticsWindow = new StatisticsWindowView();
            statisticsWindow.Show();
        }
    }
}
