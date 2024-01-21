using FinalExam.Core.Models;
using FinalExam.Core.Repositories;
using FinalExam.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalExam.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = Table.AsQueryable();

            if(expression is not null) query = query.Where(expression);

            if(includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = Table.AsQueryable();

            if (expression is not null) query = query.Where(expression);

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
