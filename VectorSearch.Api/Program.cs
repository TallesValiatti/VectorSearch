using Microsoft.EntityFrameworkCore;
using Pgvector;
using VectorSearch.Api.Data;
using VectorSearch.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IEmbeddingService, AzureOpenAiService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString, o => o.UseVector())
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/search-books", async (string? text, ISearchService searchService) =>
    {
        return Results.Ok(await searchService.SearcAsync(text));
    })
.WithName("GetSearchBooks")
.WithOpenApi();

app.MapPost("/create-embeddings", async (IEmbeddingService embeddingService, AppDbContext appDbContext) =>
    {
        var books = await appDbContext.Books.ToListAsync();
        foreach (var book in books)
        {
            if (book.Embedding == null)
            {
                var embedding = embeddingService.CreateEmbedding(book.Description);
                book.Embedding = new Vector(embedding);
            }
            
            await appDbContext.SaveChangesAsync();
        }
        return Results.Ok();
    })
    .WithName("CreateEmbeddings")
    .WithOpenApi();

app.Run();