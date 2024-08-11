using Microsoft.AspNetCore.Authorization;
using RickAndMorty.Fac.Entities;
using RickAndMorty.Fac.Repositories.Interfacies;
using RickAndMorty.Fac.Services.Inteface;

namespace RickAndMorty.Fac.Utils
{
    public static class WebApplicationsMaps
    {
        public static WebApplication WebApplicationsAddMaps(this WebApplication app, IServiceCollection services, IConfiguration configuration)
        {
            IServiceProvider _serviceProvider = app.Services;

            app.MapGet($@"characters/", [Authorize(Roles = "Admin")] async (string name) =>
            {
                var characterRepository = _serviceProvider.GetService<ICharacterRepository>()!;
                var result = await characterRepository.GetCharacterAsync(name);
                return result;
            });

            app.MapPost("addUser/", async (User user) =>
            {
                var userRepository = _serviceProvider.GetService<IGenericMongorepository<User>>()!;
                var userDataBase = await userRepository.GetFilterAsync(x => x.Name == user.Name);
                if (userDataBase.Count() > 0)
                {
                    _ = new BadHttpRequestException("User already exists!");
                    return null;
                }
                return await userRepository.AddAsync(user); ;
            });

            app.MapGet("getUser/", async (string name) =>
            {
                var userRepository = _serviceProvider.GetService<IGenericMongorepository<User>>()!;
                var userDataBase = userRepository.GetFilterAsync(x => x.Name == name).Result.First();
                if (userDataBase != null)
                {
                    return await Task.FromResult(userDataBase);
                }
                _ = new BadHttpRequestException($@"User {name} not find");
                return null;
            });

            app.MapGet("getToken/", async (string name, string passWord) =>
            {
                var userRepository = _serviceProvider.GetService<IGenericMongorepository<User>>()!;
                var userDataBase =  userRepository.GetFilterAsync(x => x.Name == name && x.PassWord == passWord).Result.First();
                if (userDataBase != null)
                {
                    var tokenService = _serviceProvider.GetService<ITokenService>();
                    var token = tokenService!.GenerateToken(userDataBase);
                    return await Task.FromResult(token);
                }
                else
                {                    
                _ = new BadHttpRequestException($@"User {name} or password incorrect");
                    return null;
                }
            });

            return app;
        }
    }
}