using ChessManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessManagerAPI.Controllers;

[ApiController]
[Route("players")]
public class PlayerController : ControllerBase
{
    private static readonly List<Player> Players =
    [ 
        new Player() { ID = 1, Name = "Fuchs", Rating = 1300 },
        new Player() { ID = 2, Name = "Magnus", Rating = 2850 },
    ];
    
    [HttpGet]
    public ActionResult<List<Player>> GetPlayers()
    {
        return Players;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Player> GetPlayer(int id)
    {
        var model = Players.FirstOrDefault(p => p.ID == id);
        
        if (model == null)
        {
            return NotFound();
        }
        return model;
    }
    
    [HttpPost]
    public ActionResult<Player> CreatePlayer(Player player)
    {
        player.ID = Players.Max(p => p.ID) + 1;
        Players.Add(player);
        return CreatedAtAction(nameof(GetPlayer), new { id = player.ID }, player);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Player> DeletePlayer(int id)
    {
        var player = Players.FirstOrDefault(p => p.ID == id);

        if (player == null)
        {
            return NotFound();
        }
        
        Players.Remove(player);
        return player;
    }
}
