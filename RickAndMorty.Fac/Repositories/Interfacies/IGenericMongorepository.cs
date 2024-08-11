using System.Linq.Expressions;

namespace RickAndMorty.Fac.Repositories.Interfacies
{
    public interface IGenericMongorepository<T> where T : class
    {
        Task<IList<T>> GetFilterAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
    }
}