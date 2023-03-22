using System.Buffers.Text;
using System.Net;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("[controller]/")]
[ApiController]

public class GameApiController : Controller
{
    private IConfiguration _config;

    private RandomNumberGenerator Generator = RandomNumberGenerator.Create();

    public GameApiController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    [Route("[action]/{gameId}")]
    public GameState GetGameState(string gameId)
    {
        //Finding game in a database
        //returning the game state of found
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("[action]/")]
    public MapSlotValue[,] MakeMove()
    {
        
    }


    [HttpPost]
    [Route("[action]/createrId={id1}&invitedId={id2}")]
    public JsonResult CreateGame(string id1, string id2)
    {
        Game game = new(new Player(id1), new Player(id2));
    }
}