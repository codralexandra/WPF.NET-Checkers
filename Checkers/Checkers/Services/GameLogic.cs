using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    public class GameLogic
    {
        public Board Board { get; set; }

        public GameLogic(Board board)
        {
            Board = board;
        }
    }
}
