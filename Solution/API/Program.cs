// Minimal APIs
// Teste de APIs - Rest Client - Extensão VS Code
// Postman/Insomnia outras aplicações externas para uso corporativo
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Endpoints - Funcionalidade do Código
// Request/Requisição - URL e o método/verbo HTTP
app.MapGet("/", () => "Testando C#");
app.MapGet("/segundafunc", () => "Segunda funcionalidade");


app.Run();