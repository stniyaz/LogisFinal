using FinalExam.Business.CustomExceptions.SettingExceptions;
using FinalExam.Business.PaginationHelper;
using FinalExam.Business.Services.Interfaces;
using FinalExam.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var settings = await _settingService.GettAllAsync();
        //    return View(settings);
        //}
        public async Task<IActionResult> Index(int page = 1)
        {
            page = page < 1 ? 1 : page;
            var settingQuery = _settingService.GetAllQuery();

            var paginatedSetting = PaginatedList<Setting>.Create(settingQuery, page, 2);

            return View(paginatedSetting);
        }
        public async Task<IActionResult> Update(int id)
        {
            var setting = await _settingService.GetAsync(x => x.Id == id);
            if (setting is null) NotFound();
            return View(setting);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Update(Setting setting)
        {
            if (!ModelState.IsValid) return View(setting);
            try
            {
                await _settingService.UpdateAsync(setting);
            }
            catch (SettingNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
