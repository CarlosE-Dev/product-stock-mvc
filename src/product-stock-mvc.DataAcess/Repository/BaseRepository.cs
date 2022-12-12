using Microsoft.EntityFrameworkCore;
using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.Business.Models;
using product_stock_mvc.DataAcess.Context;
using System.Linq.Expressions;

namespace product_stock_mvc.DataAcess.Repository
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        protected readonly ProductStockDbContext _context;

        public BaseRepository(ProductStockDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Entity entity)
        {
            _context.Set<Entity>().Add(entity);
            await SaveChangesAsync();
            var createdEntity = await GetByNameAsync(entity.Name);
            return createdEntity.Id;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            _context.Set<Entity>().Remove(await GetByIdAsync(id));
            await SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(Guid id)
        {
            return await _context.Set<Entity>().FindAsync(id);
        }

        public virtual async Task<Entity> GetByNameAsync(string name)
        {
            return await _context.Set<Entity>().FirstOrDefaultAsync(x => x.Name == name);
        }

        public virtual async Task<IEnumerable<Entity>> SearchAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _context.Set<Entity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task UpdateAsync(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
