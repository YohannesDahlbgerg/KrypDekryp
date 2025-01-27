var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!!!");

app.MapGet("/Kryptering", () => "");  // Endpoints

app.MapGet("/Dekryptering", () => "");

app.Run();
