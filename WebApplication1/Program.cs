using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseCors();


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute (
            name: "GameApi", 
            pattern:"{controller}/{action}",
            defaults: new {controller = "GameApi"}
    );
});


if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();