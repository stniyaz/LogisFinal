using FinalExam.Business.Services.Interfaces;
using FinalExam.Core.Models;

namespace FinalExam.Business.Services.ViewServices
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;

        public LayoutService(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<List<Setting>> GetSettings()
        {
            return await _settingService.GettAllAsync();
        }
    }
}
