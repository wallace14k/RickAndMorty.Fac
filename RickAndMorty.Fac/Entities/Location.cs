using System.Text.Json.Serialization;

namespace RickAndMOrty.Entities
{
    public record Location(
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("url")] string Url
        );
}