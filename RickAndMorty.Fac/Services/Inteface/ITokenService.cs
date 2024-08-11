using RickAndMorty.Fac.Entities;

namespace RickAndMorty.Fac.Services.Inteface
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}