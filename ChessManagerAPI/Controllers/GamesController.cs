using Microsoft.AspNetCore.Mvc;

namespace ChessManagerAPI.Controllers;

[ApiController]
[Route("games")]
public class GamesController
{
    [HttpGet]
    public List<string> GetGames()
    {
        return ["Game 1", "Game 2"];
    }
}
