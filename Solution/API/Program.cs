using API.Models;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> 8b9a85e85a55f820ee17178dc16263e4e2dd691e

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API de Produtos");

var produtos = new List<Produto>
{
    new Produto { Id = "1", Nome = "Café", Preco = 10.50, Quantidade = 100, CriadoEm = DateTime.Now },
    new Produto { Id = "2", Nome = "Leite", Preco = 5.20, Quantidade = 50, CriadoEm = DateTime.Now },
    new Produto { Id = "3", Nome = "Açúcar", Preco = 3.80, Quantidade = 200, CriadoEm = DateTime.Now }
};

// GET: /produto/listar
app.MapGet("/produto/listar", () =>
{
<<<<<<< HEAD
=======

>>>>>>> 8b9a85e85a55f820ee17178dc16263e4e2dd691e
    if (produtos.Count > 0)
    {
        return Results.Ok(produtos);
    }
    return Results.NotFound();
<<<<<<< HEAD
});

// GET: /produto/busca/2
app.MapGet("/produto/busca/{id}", ([FromRoute] string id) =>
{
    foreach (Produto produtoId in produtos)
    {
        if (produtoId.Id == id)
        {
=======

});

// GET: http://localhost:5252/produto/busca/2
app.MapGet("/produto/busca/{id}", ([FromRoute] string id) =>
{

    foreach (Produto produtoId in produtos) {
        if (produtoId.Id == id) {
>>>>>>> 8b9a85e85a55f820ee17178dc16263e4e2dd691e
            return Results.Ok(produtoId);
        }
    }
    return Results.NotFound();
<<<<<<< HEAD
=======
 
    

>>>>>>> 8b9a85e85a55f820ee17178dc16263e4e2dd691e
});

// POST: /produto/cadastrar/
app.MapPost("/produto/cadastrar", ([FromBody] Produto novoProduto) =>
{
    novoProduto.Id = (produtos.Count + 1).ToString(); // Define um ID baseado na contagem
    novoProduto.CriadoEm = DateTime.Now; // Define a data de criação
    produtos.Add(novoProduto);
    return Results.Created(" ", novoProduto);
});

// DELETE: /produto/remover/2
app.MapDelete("/produto/remover/{id}", ([FromRoute] string id) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == id);
    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado.");
    }

    produtos.Remove(produto);
    return Results.Ok("Produto removido com sucesso.");
});

// PUT: /produto/alterar/1
app.MapPut("/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAtualizado) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == id);
    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado.");
    }

    produto.Nome = produtoAtualizado.Nome;
    produto.Preco = produtoAtualizado.Preco;
    produto.Quantidade = produtoAtualizado.Quantidade;
    produto.CriadoEm = produtoAtualizado.CriadoEm;

    return Results.Ok(produto);
});

// Funcionalidades adicionais
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
        Id = 1,
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

app.Run();

<<<<<<< HEAD
// Modelos
=======
>>>>>>> 8b9a85e85a55f820ee17178dc16263e4e2dd691e
public class Produto
{
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public DateTime CriadoEm { get; set; }
}

public class Item
{
    public string? Produto { get; set; }
    public int Quantidade { get; set; }
}

<<<<<<< HEAD
public class ProdutoDbContext : DbContext
{
    public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options) { }
    public DbSet<Produto> Produtos { get; set; }
}
=======
//Implementar Todas as Funcionalidades do CRUD
// - Remover Produto
// - Alterar Produto
>>>>>>> 8b9a85e85a55f820ee17178dc16263e4e2dd691e
