using ChessManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessManagerAPI.Controllers;

[ApiController]
[Route("games")]
public class GamesController : ControllerBase
{
    private static readonly List<Game> Games = 
    [ 
        new Game() { ID = 1, PlayerWhiteID = 1, PlayerBlackID = 2, Result = GameResult.BlackWins },
        new Game() { ID = 2, PlayerWhiteID = 2, PlayerBlackID = 1, Result = GameResult.WhiteWins },
    ];
    
    [HttpGet]
    public ActionResult<List<Game>> GetGames()
    {
        return Games;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Game> GetGame(int id)
    {
        var game = Games.FirstOrDefault(g => g.ID == id);

        if (game == null)
        {
            return NotFound();
        }
        return game;
    }

    [HttpPost]
    public ActionResult<Game> CreateGame(Game game)
    {
        game.ID = Games.Any() ? Games.Max(g => g.ID) + 1 : 1;
        
        Games.Add(game);
        return CreatedAtAction(nameof(GetGame), new { id = game.ID }, game);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Game> DeleteGame(int id)
    {
        var game = Games.FirstOrDefault(g => g.ID == id);

        if (game == null)
        {
            return NotFound();
        }

        Games.Remove(game);
        return game;
    }
}
