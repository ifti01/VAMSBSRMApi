using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VAMSBSRMApi.Application.Interfaces;

namespace VAMSBSRMApi.Persistance.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;


        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); // Retrieves the entity by its ID
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); // Retrieves all entities of type T
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity); // Adds a new entity to the DbSet<T>
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity); // Marks an entity as modified
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id); // Retrieves the entity by its ID
            if (entity != null)
            {
                _dbSet.Remove(entity); 
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
