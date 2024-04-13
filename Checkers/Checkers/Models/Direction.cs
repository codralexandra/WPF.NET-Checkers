
namespace Checkers.Models
{
    public class Direction
    {
        public static Direction NorthEast = new Direction(-1, 0) + new Direction(0, 1);
        public static Direction NorthWest = new Direction(-1, 0) + new Direction(0, -1);
        public static Direction SouthEast = new Direction(1, 0) + new Direction(0, 1);
        public static Direction SouthWest = new Direction(1, 0) + new Direction(0, -1);

        public int RowDelta { get; }
        public int ColumnDelta { get; }

        public Direction(int rowDelta, int columnDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }

        public static Direction operator +(Direction a, Direction b)
        {
            return new Direction(a.RowDelta + b.RowDelta, a.ColumnDelta + b.ColumnDelta);
        }

        public static Direction operator *(int scalar, Direction d)
        {
            return new Direction(scalar * d.RowDelta, scalar * d.ColumnDelta);
        }
    }
}
