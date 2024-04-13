using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1Tema2___Checkers__New_.Models;

namespace WpfApp1Tema2___Checkers__New_.Service
{
    public class GameLogic : BaseNotification
    {
        #region class members
        public PieceColor _currentPlayerColor { get; set; }
        public PieceColor currentPlayerColor
        {
            get => _currentPlayerColor;
            set
            {
                _currentPlayerColor = value;
                NotifyPropertyChanged();
            }
        }
        public bool MultipleJump { get; set; } = true;
        public int _RedPieces { get; set; }
        public int RedPieces
        {
            get => _RedPieces;
            set
            {
                _RedPieces = value;
                NotifyPropertyChanged();
            }
        }
        public int _BlackPieces { get; set; }
        public int BlackPieces
        {
            get => _BlackPieces;
            set
            {
                _BlackPieces = value;
                NotifyPropertyChanged();
            }
        }
        public GameState State { get; set; }
        public Cell previousPosition { get; set; }
        public ObservableCollection<ObservableCollection<Cell>> board { get; set; }
        #endregion

        #region methods

        public GameLogic(ObservableCollection<ObservableCollection<Cell>> b)
        {
            board = b;
            currentPlayerColor = PieceColor.Red;
            State = GameState.Ongoing;
            RedPieces = 12;
            BlackPieces = 12;
        }

        #region inits
        public static string InitPlayers()
        {
            return "Red";
        }

        public static ObservableCollection<ObservableCollection<Cell>> InitGameBoard()
        {
            return new ObservableCollection<ObservableCollection<Cell>>()
            {
                new ObservableCollection<Cell>()
                {
                    new Cell(0, 0, "Assets/Empty.png"),
                    new Cell(0, 1, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(0, 2, "Assets/Empty.png"),
                    new Cell(0, 3, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(0, 4, "Assets/Empty.png"),
                    new Cell(0, 5, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(0, 6, "Assets/Empty.png"),
                    new Cell(0, 7, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(1, 0, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(1, 1, "Assets/Empty.png"),
                    new Cell(1, 2, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(1, 3, "Assets/Empty.png"),
                    new Cell(1, 4, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(1, 5, "Assets/Empty.png"),
                    new Cell(1, 6, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(1,7,"Assets/Empty.png")
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(2, 0, "Assets/Empty.png"),
                    new Cell(2, 1, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(2, 2, "Assets/Empty.png"),
                    new Cell(2, 3, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(2, 4, "Assets/Empty.png"),
                    new Cell(2, 5, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red),
                    new Cell(2, 6, "Assets/Empty.png"),
                    new Cell(2, 7, "Assets/redPiece.png", PieceType.Normal, PieceColor.Red)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(3, 0, "Assets/Empty.png"),
                    new Cell(3, 1, "Assets/Empty.png"),
                    new Cell(3, 2, "Assets/Empty.png"),
                    new Cell(3, 3, "Assets/Empty.png"),
                    new Cell(3, 4, "Assets/Empty.png"),
                    new Cell(3, 5, "Assets/Empty.png"),
                    new Cell(3, 6, "Assets/Empty.png"),
                    new Cell(3, 7, "Assets/Empty.png")
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(4, 0, "Assets/Empty.png"),
                    new Cell(4, 1, "Assets/Empty.png"),
                    new Cell(4, 2, "Assets/Empty.png"),
                    new Cell(4, 3, "Assets/Empty.png"),
                    new Cell(4, 4, "Assets/Empty.png"),
                    new Cell(4, 5, "Assets/Empty.png"),
                    new Cell(4, 6, "Assets/Empty.png"),
                    new Cell(4, 7, "Assets/Empty.png")
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(5, 0, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(5,1,"Assets/Empty.png"),
                    new Cell(5, 2, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(5,3,"Assets/Empty.png"),
                    new Cell(5, 4, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(5,5,"Assets/Empty.png"),
                    new Cell(5, 6, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(5,7,"Assets/Empty.png")
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(6,0,"Assets/Empty.png"),
                    new Cell(6, 1, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(6,2,"Assets/Empty.png"),
                    new Cell(6, 3, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(6,4,"Assets/Empty.png"),
                    new Cell(6, 5, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(6,6,"Assets/Empty.png"),
                    new Cell(6, 7, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(7, 0, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(7,1,"Assets/Empty.png"),
                    new Cell(7, 2, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(7,3,"Assets/Empty.png"),
                    new Cell(7, 4, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(7,5,"Assets/Empty.png"),
                    new Cell(7, 6, "Assets/blackPiece.png", PieceType.Normal, PieceColor.Black),
                    new Cell(7,7,"Assets/Empty.png")
                }
            };
        }

        public void InitFromSave(string filename)
        {
            //for opening from save
        }

        public void SaveGame(string filename)
        {
            //to save a game
        }

        #endregion

        #region moves
        public void Move(Cell position)
        {
            MoveOptions(position);

            //check for end game
            if (RedPieces == 0 || BlackPieces == 0)
                State = GameState.Finished;

            if (State == GameState.Finished)
            {
                string winner = (RedPieces == 0) ? "Black" : "Red";

                MessageBox.Show($"The game is finished!\nWinner: {winner}\nRed pieces left: {RedPieces}\nBlack pieces left: {BlackPieces}");
                // Add an option to close the game window
            }
        }

        public void MoveOptions(Cell position)
        {
            if (previousPosition == null && currentPlayerColor == board[position.X][position.Y].PieceColor)
            {
                SelectPiece(position);
            }
            else if (previousPosition != null && ValidPosition(position))
            {
                if (previousPosition.PieceColor == currentPlayerColor && board[position.X][position.Y].PieceType == PieceType.None)
                {
                    NormalMove(position);
                    currentPlayerColor = currentPlayerColor.Opponent();
                }
                else if (previousPosition.PieceColor == currentPlayerColor && board[position.X][position.Y].PieceColor == currentPlayerColor.Opponent())
                {
                    TakeOverMove(position);
                }
            }
            else
                DeselectPiece();
        }

        public bool ValidPosition(Cell position)
        {
            if (board[previousPosition.X][previousPosition.Y].PieceType == PieceType.Normal)
            {
                int directionX = (currentPlayerColor == PieceColor.Red) ? 1 : -1;
                int directionY = (currentPlayerColor == PieceColor.Red) ? -1 : 1;

                int deltaX = Math.Abs(position.X - previousPosition.X);
                int deltaY = Math.Abs(position.Y - previousPosition.Y);

                return deltaX == 1 && deltaY == 1 &&
                       position.X == previousPosition.X + directionX &&
                       (position.Y == previousPosition.Y + directionY || position.Y == previousPosition.Y - directionY);
            }
            else if (board[previousPosition.X][previousPosition.Y].PieceType == PieceType.King)
            {
                int deltaX = Math.Abs(position.X - previousPosition.X);
                int deltaY = Math.Abs(position.Y - previousPosition.Y);

                return deltaX == 1 && deltaY == 1;
            }
            else return false;
        }

        public void NormalMove(Cell position)
        {
            //pt red pieces
            if (currentPlayerColor == PieceColor.Red && position.X == previousPosition.X + 1 && (position.Y == previousPosition.Y - 1 || position.Y == previousPosition.Y + 1))
            {
                //pune piesa pe pozitia noua
                board[position.X][position.Y].PieceImage = board[previousPosition.X][previousPosition.Y].SelectedImage;
                //seteaza PieceType si PieceColor pt noua pozitie
                board[position.X][position.Y].PieceType = PieceType.Normal;
                board[position.X][position.Y].PieceColor = PieceColor.Red;
                //seteaza PieceImage pt noua pozitie
                board[position.X][position.Y].PieceImage = "Assets/redPiece.png";
                board[position.X][position.Y].SelectedImage = "Assets/selectedPiece.png";
                //sterge de pe previous position
                board[previousPosition.X][previousPosition.Y].PieceImage = "Assets/Empty.png";
                board[previousPosition.X][previousPosition.Y].SelectedImage = "Assets/selectedPiece.png";
                board[previousPosition.X][previousPosition.Y].PieceType = PieceType.None;
                board[previousPosition.X][previousPosition.Y].PieceColor = PieceColor.None;
                //resetam pozitiile
                previousPosition = null;
            }
            //pt black pieces
            else if (currentPlayerColor == PieceColor.Black && position.X == previousPosition.X - 1 && (position.Y == previousPosition.Y - 1 || position.Y == previousPosition.Y + 1))
            {
                //pune piesa pe pozitia noua
                board[position.X][position.Y].PieceImage = board[previousPosition.X][previousPosition.Y].SelectedImage;
                //seteaza PieceType si PieceColor pt noua pozitie
                board[position.X][position.Y].PieceType = PieceType.Normal;
                board[position.X][position.Y].PieceColor = PieceColor.Black;
                //seteaza PieceImage pt noua pozitie
                board[position.X][position.Y].PieceImage = "Assets/blackPiece.png";
                board[position.X][position.Y].SelectedImage = "Assets/selectedPiece.png";
                //sterge de pe previous position
                board[previousPosition.X][previousPosition.Y].PieceImage = "Assets/Empty.png";
                board[previousPosition.X][previousPosition.Y].SelectedImage = "Assets/selectedPiece.png";
                board[previousPosition.X][previousPosition.Y].PieceType = PieceType.None;
                board[previousPosition.X][previousPosition.Y].PieceColor = PieceColor.None;
                //resetam pozitiile
                previousPosition = null;
            }

            //change piece to king
            if (currentPlayerColor == PieceColor.Red && position.X == 7)
            {
                PromoteToKing(position);
            }
            else if (currentPlayerColor == PieceColor.Black && position.X == 0)
            {
                PromoteToKing(position);
            }
        }

        #region selection-deselection

        public void DeselectPiece()
        {
            if (previousPosition != null)
            {
                string aux = board[previousPosition.X][previousPosition.Y].PieceImage;
                board[previousPosition.X][previousPosition.Y].PieceImage = previousPosition.SelectedImage;
                board[previousPosition.X][previousPosition.Y].SelectedImage = aux;
                if(board[previousPosition.X][previousPosition.Y].PieceColor != currentPlayerColor)
                    previousPosition = null;
            }
        }

        public void SelectPiece(Cell position)
        {
            string aux = board[position.X][position.Y].SelectedImage;
            board[position.X][position.Y].SelectedImage = board[position.X][position.Y].PieceImage;
            board[position.X][position.Y].PieceImage = aux;
            previousPosition = position;
        }
        #endregion 

        #region take-over moves

        public void TakeOverMove(Cell position)
        {
            int direction = (currentPlayerColor == PieceColor.Red) ? 1 : -1;

            int newX = previousPosition.X + 2 * direction;
            int newY = (position.Y > previousPosition.Y) ? position.Y + 1 : position.Y - 1;


            if (newX >= 0 && newX < board.Count && newY >= 0 && newY < board[newX].Count && board[newX][newY].PieceType==PieceType.None)
            {
                //move the previous piece to the new position
                board[newX][newY].PieceImage = board[previousPosition.X][previousPosition.Y].SelectedImage;
                board[newX][newY].PieceType = board[previousPosition.X][previousPosition.Y].PieceType;
                board[newX][newY].PieceColor = currentPlayerColor;

                //empty the cell of the capured piece
                int capturedX = (newX + previousPosition.X) / 2; 
                int capturedY = (newY + previousPosition.Y) / 2;
                board[capturedX][capturedY].PieceImage = "Assets/Empty.png";
                board[capturedX][capturedY].PieceType = PieceType.None;
                board[capturedX][capturedY].PieceColor = PieceColor.None;

                //clear the previous cell of the selected piece to move
                board[previousPosition.X][previousPosition.Y].PieceImage = "Assets/Empty.png";
                board[previousPosition.X][previousPosition.Y].SelectedImage = "Assets/selectedPiece.png";
                board[previousPosition.X][previousPosition.Y].PieceType = PieceType.None;
                board[previousPosition.X][previousPosition.Y].PieceColor = PieceColor.None;

                previousPosition = null; //daca e multiple jump available you need this to not be null

                if (currentPlayerColor.Opponent() == PieceColor.Red)
                    RedPieces--;
                else if (currentPlayerColor.Opponent() == PieceColor.Black)
                    BlackPieces--;

                if (currentPlayerColor == PieceColor.Red && newX == 7)
                {
                    PromoteToKing(board[newX][newY]);
                }
                else if (currentPlayerColor == PieceColor.Black && newX == 0)
                {
                    PromoteToKing(board[newX][newY]);
                }

                if (MultipleJump && AdditionalTakeOverMoves(newX, newY))
                { 
                    previousPosition = board[newX][newY];
                }
                else
                {
                    previousPosition = null;
                    currentPlayerColor = currentPlayerColor.Opponent();
                }            
            }

        }

        private bool AdditionalTakeOverMoves(int x, int y)
        {
            if (board[x][y].PieceType == PieceType.King)
            {
                return AdditionalTakeOverMovesForKing(x, y);
            }
            else
            {
                return AdditionalTakeOverMovesForRegularPiece(x, y);
            }
        }

        private bool AdditionalTakeOverMovesForRegularPiece(int x, int y)
        {
            int direction = (currentPlayerColor == PieceColor.Red) ? 1 : -1;

            // Check if there are any opponent pieces adjacent to the piece at position (x, y)
            if (x + 2 * direction >= 0 && x + 2 * direction < board.Count)
            {
                if (y - 2 >= 0 && board[x + 2 * direction][y - 2].PieceType == PieceType.None)
                {
                    // Check if the cell diagonally opposite to (x, y) is empty
                    if (board[x + direction][y - 1].PieceColor == currentPlayerColor.Opponent())
                    {
                        return true; // Additional take-over move is possible
                    }
                }

                if (y + 2 < board[x + 2 * direction].Count && board[x + 2*direction][y + 2].PieceType == PieceType.None)
                {
                    // Check if the cell diagonally opposite to (x, y) is empty
                    if (board[x + direction][y + 1].PieceColor == currentPlayerColor.Opponent())
                    {
                        return true; // Additional take-over move is possible
                    }
                }
            }

            return false; // No additional take-over moves possible
        }

        private bool AdditionalTakeOverMovesForKing(int x, int y)
        {
            // King pieces can move forward and backward
            // Check if there are any opponent pieces adjacent to the king piece at position (x, y)
            // and whether the cells diagonally opposite to those pieces are empty
            int[] dx = { -1, -1, 1, 1 };
            int[] dy = { -1, 1, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                if (newX >= 0 && newX < board.Count && newY >= 0 && newY < board[newX].Count &&
                    board[newX][newY].PieceColor == currentPlayerColor.Opponent())
                {
                    int nextX = newX + dx[i];
                    int nextY = newY + dy[i];

                    if (nextX >= 0 && nextX < board.Count && nextY >= 0 && nextY < board[nextX].Count &&
                        board[nextX][nextY].PieceType == PieceType.None)
                    {
                        return true; // Additional take-over move is possible
                    }
                }
            }

            return false; // No additional take-over moves possible
        }
        #endregion

        #region king-piece behaviours
        private void PromoteToKing(Cell position)
        {
            // Set the piece type to King
            board[position.X][position.Y].PieceType = PieceType.King;

            // Update the piece image based on the player color
            if (currentPlayerColor == PieceColor.Red)
            {
                board[position.X][position.Y].PieceImage = "Assets/redPieceKing.png";
            }
            else if (currentPlayerColor == PieceColor.Black)
            {
                board[position.X][position.Y].PieceImage = "Assets/blackPieceKing.png";
            }
        }

        public void KingMove(Cell position)
        {
            int directionX = (position.X > previousPosition.X) ? 1 : -1;
            int directionY = (position.Y > previousPosition.Y) ? 1 : -1;

            if (Math.Abs(position.X - previousPosition.X) == 1 && Math.Abs(position.Y - previousPosition.Y) == 1)
            {
                // Destination cell
                Cell destCell = board[position.X][position.Y];

                // Check if destination cell is empty or contains an opponent's piece
                if (destCell.PieceType == PieceType.None || destCell.PieceColor == currentPlayerColor.Opponent())
                {
                    // Move the king piece
                    destCell.PieceImage = board[previousPosition.X][previousPosition.Y].SelectedImage;
                    destCell.PieceType = PieceType.King;
                    destCell.PieceColor = currentPlayerColor;
                    destCell.SelectedImage = "Assets/selectedPiece.png";

                    // Clear the previous position
                    board[previousPosition.X][previousPosition.Y].PieceImage = "Assets/Empty.png";
                    board[previousPosition.X][previousPosition.Y].SelectedImage = "Assets/selectedPiece.png";
                    board[previousPosition.X][previousPosition.Y].PieceType = PieceType.None;
                    board[previousPosition.X][previousPosition.Y].PieceColor = PieceColor.None;

                    // Clear the cell of the captured piece, if any
                    if (destCell.PieceType != PieceType.None)
                    {
                        int capturedX = (position.X + previousPosition.X) / 2;
                        int capturedY = (position.Y + previousPosition.Y) / 2;
                        board[capturedX][capturedY].PieceImage = "Assets/Empty.png";
                        board[capturedX][capturedY].PieceType = PieceType.None;
                        board[capturedX][capturedY].PieceColor = PieceColor.None;

                        // Update piece count
                        if (currentPlayerColor.Opponent() == PieceColor.Red)
                            RedPieces--;
                        else if (currentPlayerColor.Opponent() == PieceColor.Black)
                            BlackPieces--;
                    }

                    // Reset previous position
                    previousPosition = null;

                    // Switch player turn
                    currentPlayerColor = currentPlayerColor.Opponent();
                }
            }
        }
        #endregion

        #endregion

        #endregion
    }
}
