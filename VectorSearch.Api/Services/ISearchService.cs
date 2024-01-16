using VectorSearch.Api.Models;

namespace VectorSearch.Api.Services;

public interface ISearchService
{
    public Task<List<Book>> SearcAsync(string? text);
}