using FinalExam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services.Interfaces
{
    public interface IServiceService
    {
        Task CommitAsync();
        Task CreateAsync(Service service);
        Task HardDeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(Service service);
        Task<List<Service>> GetAllAsync(Expression<Func<Service, bool>>? expression = null, params string[]? includes);
        IQueryable<Service> GetQuery(Expression<Func<Service, bool>>? expression = null, params string[]? includes);
        Task<Service> GetAsync(Expression<Func<Service, bool>>? expression = null, params string[]? includes);
    }
}
