using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1Tema2___Checkers__New_.Commands;
using WpfApp1Tema2___Checkers__New_.Models;
using WpfApp1Tema2___Checkers__New_.Service;

namespace WpfApp1Tema2___Checkers__New_.View_Models
{
    internal class GameWindowViewModel : BaseNotification
    {
        #region class members
        public GameLogic GameLogic { get; }
        public ObservableCollection<ObservableCollection<Cell>> GameBoard { get; set; }
        private string _currentPlayer;
        public string currentPlayer
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
                NotifyPropertyChanged();
            }
        }
        public int _blackPieces;
        public int blackPieces
        {
            get => _blackPieces;
            set
            {
                _blackPieces = value;
                NotifyPropertyChanged();
            }
        }
        public int _redPieces;
        public int redPieces
        {
            get => _redPieces;
            set
            {
                _redPieces = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand clickCommand;

        public ICommand SaveCommand { get; }
        #endregion

        public GameWindowViewModel(FileWindowViewModel fileVM)
        {
            GameBoard = GameLogic.InitGameBoard();
            GameLogic = new GameLogic(GameBoard,fileVM);
            currentPlayer = GameLogic.currentPlayerColor.ToCustomString();
            redPieces = GameLogic.RedPieces;
            blackPieces = GameLogic.BlackPieces;

            //for currentPlayer & piece numbers dynamic changes
            GameLogic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(GameLogic.currentPlayerColor))
                {
                    currentPlayer = GameLogic.currentPlayerColor.ToCustomString();
                }
            };

            GameLogic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(GameLogic.RedPieces))
                {
                    redPieces = GameLogic.RedPieces;
                }
            };

            GameLogic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(GameLogic.BlackPieces))
                {
                    blackPieces = GameLogic.BlackPieces;
                }
            };

            SaveCommand = new RelayCommand<object>(SaveCommandClick);
        }

        //open from a save
        public GameWindowViewModel(GameLogic gameLogic)
        {
            GameBoard = GameLogic.GameBoardFromSave(gameLogic);
            GameLogic = gameLogic;
            currentPlayer = GameLogic.currentPlayerColor.ToCustomString();
            redPieces = GameLogic.RedPieces;
            blackPieces = GameLogic.BlackPieces;

            //for currentPlayer & piece numbers dynamic changes
            GameLogic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(GameLogic.currentPlayerColor))
                {
                    currentPlayer = GameLogic.currentPlayerColor.ToCustomString();
                }
            };

            GameLogic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(GameLogic.RedPieces))
                {
                    redPieces = GameLogic.RedPieces;
                }
            };

            GameLogic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(GameLogic.BlackPieces))
                {
                    blackPieces = GameLogic.BlackPieces;
                }
            };

            SaveCommand = new RelayCommand<object>(SaveCommandClick);
        }

        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand<Cell>(GameLogic.Move);
                }
                return clickCommand;
            }
        }

        public void SaveCommandClick(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".xml";

            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = saveFileDialog.FileName;

                SerializationActions.SaveGame(filename, GameLogic);

                MessageBox.Show("Game saved successfully!", "Save Game", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}