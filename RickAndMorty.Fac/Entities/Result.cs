using System.Text.Json.Serialization;
using RickAndMOrty.Entities;

namespace RickAndMorty.Fac.Entities
{
    public record Result(
       [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("species")] string Species,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("gender")] string Gender,
        [property: JsonPropertyName("origin")] Origin Origin,
        [property: JsonPropertyName("location")] Location Location,
        [property: JsonPropertyName("image")] string Image,
        [property: JsonPropertyName("episode")] IReadOnlyList<string> Episode,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("created")] DateTime Created
    );
}