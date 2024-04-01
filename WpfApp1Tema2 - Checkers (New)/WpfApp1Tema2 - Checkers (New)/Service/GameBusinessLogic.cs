using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1Tema2___Checkers__New_.Models;

namespace WpfApp1Tema2___Checkers__New_.Service
{
    internal class GameBusinessLogic
    {
        private ObservableCollection<ObservableCollection<BoardSquareModel>> gameBoard;

        public ObservableCollection<ObservableCollection<BoardSquareModel>> initializeGameBoard()
        {
            for (int y = 0; y < 8; y++)
            {
                var row = new ObservableCollection<BoardSquareModel>();
                for (int x = 0; x < 8; x++)
                {
                    bool hasPiece = ((x + y) % 2 != 0) && (y < 3 || y > 4);
                    PieceColors color;
                    if (y < 4 && hasPiece == true)
                    {
                        color = PieceColors.White;
                    }
                    else if (y > 4 && hasPiece == true)
                    {
                        color = PieceColors.Red;
                    }
                    else color = PieceColors.None;

                    row.Add(new BoardSquareModel(x, y, hasPiece, color));
                }
                gameBoard.Add(row);
            }
            return gameBoard;
        }
    }
}
