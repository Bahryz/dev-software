using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adicionar o serviço do contexto de banco de dados (ProdutoDbContext)
builder.Services.AddDbContext<ProdutoDbContext>(options =>
    options.UseInMemoryDatabase("ProdutosDb")); // Use um banco em memória para fins de teste

var app = builder.Build();

// Mensagem de boas-vindas da API
app.MapGet("/", () => "API de Produtos");

// GET: /produto/listar
app.MapGet("/produto/listar", async (ProdutoDbContext context) =>
{
    var produtos = await context.Produtos.ToListAsync();
    return produtos.Count > 0 ? Results.Ok(produtos) : Results.NotFound("Nenhum produto encontrado.");
});

// GET: /produto/busca/2
app.MapGet("/produto/busca/{id}", async ([FromRoute] string id, ProdutoDbContext context) =>
{
    var produto = await context.Produtos.FindAsync(id);
    return produto != null ? Results.Ok(produto) : Results.NotFound("Produto não encontrado.");
});

// POST: /produto/cadastrar/
app.MapPost("/produto/cadastrar", async ([FromBody] Produto novoProduto, ProdutoDbContext context) =>
{
    novoProduto.Id = (context.Produtos.Count() + 1).ToString(); // Define um ID baseado na contagem
    novoProduto.CriadoEm = DateTime.Now; // Define a data de criação
    context.Produtos.Add(novoProduto);
    await context.SaveChangesAsync();
    return Results.Created($"/produto/{novoProduto.Id}", novoProduto);
});

// DELETE: /produto/remover/2
app.MapDelete("/produto/remover/{id}", async ([FromRoute] string id, ProdutoDbContext context) =>
{
    var produto = await context.Produtos.FindAsync(id);
    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado.");
    }

    context.Produtos.Remove(produto);
    await context.SaveChangesAsync();
    return Results.Ok("Produto removido com sucesso.");
});

// PUT: /produto/alterar/1
app.MapPut("/produto/alterar/{id}", async ([FromRoute] string id, [FromBody] Produto produtoAtualizado, ProdutoDbContext context) =>
{
    var produto = await context.Produtos.FindAsync(id);
    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado.");
    }

    produto.Nome = produtoAtualizado.Nome;
    produto.Preco = produtoAtualizado.Preco;
    produto.Quantidade = produtoAtualizado.Quantidade;
    produto.CriadoEm = produtoAtualizado.CriadoEm;

    await context.SaveChangesAsync();
    return Results.Ok(produto);
});

app.Run();


// Funcionalidades adicionais (mantidas)
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

// Modelos
public class Produto
{
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public DateTime CriadoEm { get; set; }
}

public class ProdutoDbContext : DbContext
{
    public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options) { }
    public DbSet<Produto> Produtos { get; set; }
}

