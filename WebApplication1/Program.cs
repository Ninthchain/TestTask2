using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute (
            name: "default", 
            pattern:"{controller}/{action}"
            );
    
    endpoints.MapControllerRoute(
        name: "start-game",
        pattern: "{controller}/{action}-{id1}&{id2}",
        defaults: new
        {
            controller = "GameApi", 
            action = "StartGame", 
            id1 = args, 
            id2 = args
        }
    );
});

#pragma warning restore ASP0014
app.Run();