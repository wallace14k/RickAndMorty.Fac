using System.Text.Json.Serialization;

namespace RickAndMorty.Fac.Entities
{
    public record Origin(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url
    );
}