using Azure;
using Azure.AI.OpenAI;

namespace VectorSearch.Api.Services;

public class AzureOpenAiService(IConfiguration configuration) : IEmbeddingService
{
    public float[] CreateEmbedding(string text)
    {
        Uri oaiEndpoint = new (configuration.GetSection("AzureOpenAI:Url").Value!);
        string oaiKey = configuration.GetSection("AzureOpenAI:Key").Value!;

        var credentials = new AzureKeyCredential(oaiKey);

        var client = new OpenAIClient(oaiEndpoint, credentials);

        EmbeddingsOptions embeddingOptions = new()
        {
            DeploymentName = "text-embedding-ada-002",
            Input = { text }
        };

        var returnValue = client.GetEmbeddings(embeddingOptions);
        return returnValue.Value.Data[0].Embedding.ToArray();
    }
}