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
            name: "GameApi", 
            pattern:"{controller}/{action}",
            defaults: new {controller = "GameApi"}
    );
});

#pragma warning restore ASP0014
app.Run();