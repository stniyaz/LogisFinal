using FinalExam.Business.Services.Interfaces;
using FinalExam.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceService _service;

        public HomeController(IServiceService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _service.GetAllAsync(x=> x.IsDeleted == false);
            HomeViewModel model = new HomeViewModel();
            model.Services = services;

            return View(model);
        }
    }
}
