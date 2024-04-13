using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Tema2___Checkers__New_.Models
{
    public enum PieceColor
    {
        None,
        Red,
        Black
    }
    public static class PieceColorExtensions
    {
        public static string ToCustomString(this PieceColor color)
        {
            switch (color)
            {
                case PieceColor.Red:
                    return "Red";
                case PieceColor.Black:
                    return "Black";
                default:
                    return "None";
            }
        }

        public static PieceColor Opponent(this PieceColor color) 
        {
            switch (color)
            {
                case PieceColor.Red:
                    return PieceColor.Black;
                case PieceColor.Black:
                    return PieceColor.Red;
                default:
                    return PieceColor.None;
            }
        }
    }
}
