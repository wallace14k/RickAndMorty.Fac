using RickAndMorty.Fac.Entities;

namespace RickAndMorty.Fac.Repositories.Interfacies
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacterAsync(string Filters);
    };
}