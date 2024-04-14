using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApp1Tema2___Checkers__New_.Models;
using WpfApp1Tema2___Checkers__New_.View_Models;

namespace WpfApp1Tema2___Checkers__New_.Service
{
    internal class SerializationActions
    {
        public static void SaveGame(string filename, GameLogic gameLogic)
        {
            GameSaveData saveData = new GameSaveData
            {
                CurrentPlayer = gameLogic.currentPlayerColor.ToString(),
                RedPieces = gameLogic.RedPieces,
                BlackPieces = gameLogic.BlackPieces,
                MultipleJump = gameLogic.MultipleJump,
                Board = gameLogic.board
            };


            if (gameLogic.previousPosition != null)
            {
                saveData.IsPreviousPositionSet = true;
                saveData.PreviousPositionRow = gameLogic.previousPosition.X;
                saveData.PreviousPositionColumn = gameLogic.previousPosition.Y;
            }
            else
            {
                saveData.IsPreviousPositionSet = false;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(GameSaveData));

            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(stream, saveData);
            }
        }

        public static GameLogic OpenGame(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameSaveData));

            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                GameSaveData saveData = (GameSaveData)serializer.Deserialize(stream);

                GameLogic gameLogic = new GameLogic(
                    new ObservableCollection<ObservableCollection<Cell>>(saveData.Board),
                    new FileWindowViewModel());

                gameLogic.currentPlayerColor = (PieceColor)Enum.Parse(typeof(PieceColor), saveData.CurrentPlayer);
                gameLogic.RedPieces = saveData.RedPieces;
                gameLogic.BlackPieces = saveData.BlackPieces;
                gameLogic.MultipleJump = saveData.MultipleJump;
  
                if (saveData.IsPreviousPositionSet)
                {
                    int previousRow = saveData.PreviousPositionRow;
                    int previousColumn = saveData.PreviousPositionColumn;

                    foreach (var row in gameLogic.board)
                    {
                        foreach (var cell in row)
                        {
                            if (cell.X == previousRow && cell.Y == previousColumn)
                            {
                                gameLogic.previousPosition = cell;
                                break;
                            }
                        }
                    }
                }

                return gameLogic;
            }
        }
    }
}
