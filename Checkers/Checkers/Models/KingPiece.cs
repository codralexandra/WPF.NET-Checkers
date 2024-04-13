namespace Checkers.Models
{
    public class KingPiece: Piece
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }

        public KingPiece(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            KingPiece copy = new KingPiece(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
