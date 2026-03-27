namespace ChessManagerAPI.Models;

public enum GameResult
{
    OnGoing = 0,
    WhiteWins = 1,
    BlackWins = 2,
    Draw = 3,
}

public class Game
{
    public int ID { get; set; }
    public int PlayerWhiteID { get; set; }
    public int PlayerBlackID { get; set; }
    public GameResult Result { get; set; }
}
