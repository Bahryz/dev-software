var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Endpoints
app.MapGet("/", () => "Testando C#");

app.Run();