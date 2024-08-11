using System.Text.Json.Serialization;

namespace RickAndMOrty.Entities
{
    public record Info(
        [property: JsonPropertyName("count")] int Count,
        [property: JsonPropertyName("pages")] int Pages,
        [property: JsonPropertyName("next")] string Next,
        [property: JsonPropertyName("prev")] object Prev
    );
}