// Minimal APIs
// Teste de APIs - Rest Client - Extensão VS Code
// Postman/Insomnia outras aplicações externas para uso corporativo
using API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoints - Funcionalidade do Código
// Request/Requisição - URL e o método/verbo HTTP
app.MapGet("/", () => "API de Produtos");

var produtos = new List<Produto>
    {
        new Produto { Id = "1", Nome = "Café", Preco = 10.50, Quantidade = 100, CriadoEm = DateTime.Now },
        new Produto { Id = "2", Nome = "Leite", Preco = 5.20, Quantidade = 50, CriadoEm = DateTime.Now },
        new Produto { Id = "3", Nome = "Açúcar", Preco = 3.80, Quantidade = 200, CriadoEm = DateTime.Now }
    };

//GET: /produto/listar
app.MapGet("/produto/listar", () =>
{
    return produtos;
});

app.MapPost("/produto/cadastrar/{nome}/", (string nome) =>
{
    Produto produto = new Produto();
    produto.Nome = "nome";
    produtos.Add(produto);
    return produtos;
});

// Corpo Requisição
// Estudar e entender qual é o código HTTP adequado para um cadastro

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

Produto produto = new Produto();
produto.Preco = 50;
Console.WriteLine("Preço: " + produto.Preco);

public class Item
{
    public string? Produto { get; set; }
    public int Quantidade { get; set; }
}