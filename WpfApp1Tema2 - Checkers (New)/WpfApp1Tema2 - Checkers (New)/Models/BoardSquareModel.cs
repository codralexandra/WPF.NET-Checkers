using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1Tema2___Checkers__New_.Service;

namespace WpfApp1Tema2___Checkers__New_.Models
{
    internal class BoardSquareModel
    {
        private int x { get; set; }
        private int y { get; set; }
        private bool hasPiece { get; set; }

        private PieceColors pieceColor { get; set; }

        public BoardSquareModel(int x, int y, bool hasPiece, PieceColors color)
        {
            this.x = x;
            this.y = y;
            this.hasPiece = hasPiece;
            this.pieceColor = color;
        }
    }
}
