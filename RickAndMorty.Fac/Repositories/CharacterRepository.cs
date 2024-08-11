using System.Text.Json;
using RickAndMorty.Fac.Entities;
using RickAndMorty.Fac.Repositories.Interfacies;

namespace RickAndMorty.Fac.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly HttpClient _httpClient;
        public CharacterRepository(IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient("RickAndMortyApi");
        }

        public async Task<Character> GetCharacterAsync(string Filters)
        {
            var response = await _httpClient.GetAsync("character/?");
            var result = await JsonSerializer.DeserializeAsync<Character>(await response.Content.ReadAsStreamAsync());
            return result!;
        }
    }
}