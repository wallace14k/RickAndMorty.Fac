using System.Text.Json.Serialization;
using RickAndMOrty.Entities;

namespace RickAndMorty.Fac.Entities
{

    public record Character(
        [property: JsonPropertyName("info")] Info Info,
        [property: JsonPropertyName("results")] IReadOnlyList<Result> Results
    );
}