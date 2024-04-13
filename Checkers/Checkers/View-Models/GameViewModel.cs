using Checkers.Models;
using Checkers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.View_Models
{
    public class GameViewModel
    {
        public GameLogic GameLogic { get; set; }
        public Board GameBoard { get; }
        public Player CurrentPlayer { get; set; }

        public GameViewModel()
        {
            GameBoard = Board.Initialize();
            CurrentPlayer = Player.Red;
            GameLogic = new GameLogic(GameBoard);
        }
        
    }
}
