// Minimal APIs
// Teste de APIs - Rest Client - Extensão VS Code
// Postman/Insomnia outras aplicações externas para uso corporativo
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Endpoints - Funcionalidade do Código
// Request/Requisição - URL e o método/verbo HTTP
app.MapGet("/", () => "Testando C#");
app.MapGet("/segundafunc", () => "Segunda funcionalidade");

app.MapGet("/retornaendereco", () =>
{
    dynamic endereco = new
    {
        rua = "Praça Osório",
        numero = 125
    };
    return endereco;
});

// Exercicio
// Criar novas funcionalidades/Endpoints para receber dados
// - Pelo URL da requisição
// - Corpo da requisição
// - Guardar as informações em uma lista


app.Run();