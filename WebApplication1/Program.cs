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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "test", 
            pattern:"{controller}/{action}");
});
app.Run();