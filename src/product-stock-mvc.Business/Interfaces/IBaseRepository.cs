using product_stock_mvc.Business.Models;
using System.Linq.Expressions;

namespace product_stock_mvc.Business.Interfaces
{
    public interface IBaseRepository<Entity> : IDisposable where Entity : BaseEntity
    {
        Task<Guid> CreateAsync(Entity entity);
        Task<Entity> GetByIdAsync(Guid id);
        Task<Entity> GetByNameAsync(string name);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task UpdateAsync(Entity entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Entity>> SearchAsync(Expression<Func<Entity, bool>> predicate);
        Task<int> SaveChangesAsync();
    }
}
