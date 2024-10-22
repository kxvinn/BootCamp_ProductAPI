using Bootcamp_Domain.Models;

namespace Bootcamp_Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> Add(Product product);
        Task<Product> Update(Guid id, Product product);
        Task<bool> DeleteById(Guid id);
        Task<Product> SaveChanges();

    }
}
