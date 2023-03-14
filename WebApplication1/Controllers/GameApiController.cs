using System.Buffers.Text;
using System.Net;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("[controller]")]
public class GameApiController : Controller
{
    private RandomNumberGenerator Generator = RandomNumberGenerator.Create();
    
    [HttpHead]
    [Route("[action]/")]
    public async Task<AcceptedAtRouteResult> Ping()
    {
        Console.WriteLine("Pong");
        return AcceptedAtRoute(new { data = DateTime.Now });
    }
    
    [HttpPost]
    [Route("[action]-id1={id1}&id2={id2}")]
    public async Task<ObjectResult> StartGame(int id1, int id2)
    {
        JsonResult result = new JsonResult("");
        
        result.StatusCode = 200;
        
        if (id1 == id2)
        {
            result.Value = "Error: The ids must be different";
            result.StatusCode = 400;
            return BadRequest(result);
        }

        byte[] bytes = new byte[8];
        Generator.GetBytes(bytes);
        
        string uuid = Convert.ToBase64String(bytes)
            .Replace("/", "")
            .Replace("+", "")
            .Substring(0, 10);
        
        //Database logic to create game with current params

        result.Value = new
        {
            gameId = uuid,
            id1Token = "X",
            id2Token = "O"
        };
        return Ok(result);
    }
}