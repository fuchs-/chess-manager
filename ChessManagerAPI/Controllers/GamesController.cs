// ReSharper disable SuggestVarOrType_SimpleTypes

using ChessManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessManagerAPI.Controllers;

[ApiController]
[Route("games")]
public class GamesController : ControllerBase
{
    // ReSharper disable once InconsistentNaming
    private static readonly List<Game> _games = 
    [ 
        new Game() { ID = 1, PlayerWhiteID = 1, PlayerBlackID = 2, Result = GameResult.BlackWins },
        new Game() { ID = 2, PlayerWhiteID = 2, PlayerBlackID = 1, Result = GameResult.WhiteWins },
    ];
    
    [HttpGet]
    public ActionResult<List<Game>> GetGames()
    {
        return _games;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Game> GetGame(int id)
    {
        var game = _games.FirstOrDefault(g => g.ID == id);

        if (game is null)
        {
            return NotFound();
        }
        return game;
    }

    [HttpPost]
    public ActionResult<Game> CreateGame(Game game)
    {
        game.ID = _games.Any() ? _games.Max(g => g.ID) + 1 : 1;
        
        _games.Add(game);
        return CreatedAtAction(nameof(GetGame), new { id = game.ID }, game);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Game> DeleteGame(int id)
    {
        var game = _games.FirstOrDefault(g => g.ID == id);

        if (game is null)
        {
            return NotFound();
        }

        _games.Remove(game);
        return game;
    }
}
