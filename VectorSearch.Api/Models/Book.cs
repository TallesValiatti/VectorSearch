using System.Text.Json.Serialization;
using Pgvector;

namespace VectorSearch.Api.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    
    [JsonIgnore]
    public Vector? Embedding { get; set; }
}