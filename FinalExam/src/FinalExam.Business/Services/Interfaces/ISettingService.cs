using FinalExam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services.Interfaces
{
    public interface ISettingService
    {
        Task UpdateAsync(Setting setting);
        Task<Setting> GetAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes);
        Task<List<Setting>> GettAllAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes);
    }
}
