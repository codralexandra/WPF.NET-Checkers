using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1Tema2___Checkers__New_.Models;
using WpfApp1Tema2___Checkers__New_.Service;

namespace WpfApp1Tema2___Checkers__New_.View_Models
{
    internal class GameWindowViewModel
    {
        private ObservableCollection<ObservableCollection<BoardSquareModel>> gameBoard { get; set; }
        private GameBusinessLogic gameLogic { get; set; }

        public GameWindowViewModel()
        {
            gameBoard = gameLogic.initializeGameBoard();
        }
    }
}
