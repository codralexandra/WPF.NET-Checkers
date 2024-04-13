using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Tema2___Checkers__New_.Models
{
    public class Cell : BaseNotification
    {
        public Cell(
            int x,
            int y,
            string pieceImage,
            PieceType type = PieceType.None,
            PieceColor color = PieceColor.None)
        {
            this.X = x;
            this.Y = y;
            this.PieceImage = pieceImage;
            this.PieceType = type;
            this.PieceColor = color;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string pieceImage { get; set; }
        public string SelectedImage { get; set; } = "Assets/selectedPiece.png";

        public PieceType PieceType { get; set; }
        public PieceColor PieceColor { get; set; }

        public string PieceImage
        {
            get { return pieceImage; }
            set
            {
                pieceImage = value;
                NotifyPropertyChanged();
            }
        }
    }
}
