// ReSharper disable SuggestVarOrType_SimpleTypes

using ChessManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessManagerAPI.Controllers;

[ApiController]
[Route("players")]
public class PlayerController : ControllerBase
{
    // TODO: centralize configuration
    // ReSharper disable once ConvertToConstant.Local
    private static readonly int StartingRating = 1500;
    
    //TODO: move to service
    // ReSharper disable once InconsistentNaming
    private static readonly List<Player> _players =
    [
        new (id: 1, name: "Fuchs", rating: 1300),
        new (id: 2, name: "Magnus", rating: 2850),
    ];
    
    [HttpGet]
    public ActionResult<List<Player>> GetPlayers()
    {
        return _players;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Player> GetPlayer(int id)
    {
        var player = _players.FirstOrDefault(p => p.ID == id);
        
        if (player is null)
        {
            return NotFound();
        }
        return player;
    }
    
    [HttpPost]
    public ActionResult<Player> CreatePlayer(Player player)
    {
        player.ID = _players.Max(p => p.ID) + 1;
        
        if (player.Rating is 0)
        {
            player.Rating = StartingRating;
        }
        
        _players.Add(player);
        return CreatedAtAction(nameof(GetPlayer), new { id = player.ID }, player);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Player> DeletePlayer(int id)
    {
        var player = _players.FirstOrDefault(p => p.ID == id);

        if (player is null)
        {
            return NotFound();
        }
        
        _players.Remove(player);
        return player;
    }
}
