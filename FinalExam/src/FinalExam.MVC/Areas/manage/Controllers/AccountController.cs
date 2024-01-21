using FinalExam.Business.CustomExceptions.AccountExceptions;
using FinalExam.Business.Services.Interfaces;
using FinalExam.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken,HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(!ModelState.IsValid) return View(model);

            try
            {
                await _accountService.Login(model);
            }
            catch(UserInvalidCredentialsExceptions ex)
            {
                ModelState.AddModelError("",ex.Message);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("index", "dashboard");
        }
    }
}
