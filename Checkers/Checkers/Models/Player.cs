namespace Checkers.Models
{
    public enum Player
    {
        None,
        Black,
        Red
    }

    public static class PlayerService
    {
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.Black => Player.Red,
                Player.Red => Player.Black,
                _ => Player.None,
            };
        }
    }
}
