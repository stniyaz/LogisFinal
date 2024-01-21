using FinalExam.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table { get; }

        Task<int> CommitAsync();
        void Delete(T entity);
        Task CreateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>>? expression=null,params string[]? includes);
        IQueryable<T> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);
    }
}
