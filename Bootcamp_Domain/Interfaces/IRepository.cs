
namespace Bootcamp_Domain.Interfaces;

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(Guid id);
        Task<bool> DeleteById(Guid id);
    }

