using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("[controller]")]
public class GameApiController : Controller
{
    [HttpGet]
    [Route("[action]/")]
    public async Task<AcceptedAtRouteResult> Ping()
    {
        Console.WriteLine("Pong");
        return AcceptedAtRoute(new { data = DateTime.Now });
    }
    
    [HttpGet]
    [Route("[action]/{id}/")]
    public OkObjectResult Connect(int id)
    {
        var response = Json("Connected");
        //logic
        return Ok(response);
    }
}