using System.Linq.Expressions;
using MongoDB.Driver;
using RickAndMorty.Fac.Repositories.Interfacies;

namespace RickAndMorty.Fac.Repositories
{
    public class GenericMongoRepository<T> : IGenericMongorepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IConfiguration _configuration;

        public GenericMongoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var database = new MongoClient(_configuration["MongoClient:connection"]).GetDatabase("UserDataBase");
            
            // Utiliza o nome da classe genérica como nome da coleção
            var collectionName = typeof(T).Name;
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IList<T>> GetFilterAsync(Expression<Func<T, bool>> expression)
        {
            return await _collection.Find(expression).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }
    }
}
