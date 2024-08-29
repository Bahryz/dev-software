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
    var endereco = new
    {
        rua = "Praça Osório",
        numero = 125
    };
    return Results.Ok(endereco);
});

app.MapGet("/retornacadastro", () =>
{
    var cadastro = new 
    {
        codigo = "1",
        nome = "Artur",
        dataNascimento = new DateTime(1990, 1, 1),
        Sexo = "Masculino"
    };
    return Results.Ok(cadastro);
});

app.MapGet("/saudacao/{nome}", (string nome) => $"Olá, {nome}!");

public class Item
{
    public string Produto { get; set; }
    public int Quantidade { get; set; }
}

app.MapGet("/retornalist", () =>
{
    var list = new
    {
        Id = 1, // Opcional
        Cliente = new 
        { 
            Nome = "Maria", 
            Email = "maria@gmail.com" 
        },
        Itens = new List<Item>
        {
            new Item { Produto = "Café", Quantidade = 2 },
            new Item { Produto = "Leite", Quantidade = 3 }
        }
    };
    return Results.Ok(list);
});

// Exercicio
// Criar novas funcionalidades/Endpoints para receber dados
// - Pelo URL da requisição
// - Corpo da requisição
// - Guardar as informações em uma lista

app.Run();