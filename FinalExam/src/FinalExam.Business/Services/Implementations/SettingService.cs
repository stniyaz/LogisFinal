using FinalExam.Business.CustomExceptions.SettingExceptions;
using FinalExam.Business.Services.Interfaces;
using FinalExam.Core.Models;
using FinalExam.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<Setting> GetAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes)
        {
            return await _settingRepository.GetAsync(expression, includes);
        }

        public async Task<List<Setting>> GettAllAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes)
        {
            return await _settingRepository.GetAllAsync(expression, includes).ToListAsync();
        }

        public async Task UpdateAsync(Setting setting)
        {
            var exist = await _settingRepository.GetAsync(x => x.Id == setting.Id);
            if (exist is null) throw new SettingNotFoundException();

            exist.Value = setting.Value;

            await _settingRepository.CommitAsync();
        }
    }
}
