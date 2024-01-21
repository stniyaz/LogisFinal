using FinalExam.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DashboardController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    return Ok();
        //}
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser user1 = new AppUser()
        //    {
        //        FullName = "Eli Eliyev",
        //        UserName = "SuperAdmin",
        //        Email = "super@gmail.com"
        //    };

        //    AppUser user2 = new AppUser()
        //    {
        //        FullName = "Veli Veliyev",
        //        UserName = "Member",
        //        Email = "member@gmail.com"
        //    };

        //    await _userManager.CreateAsync(user1,"Salam123!");
        //    await _userManager.CreateAsync(user2,"Salam123!");

        //    await _userManager.AddToRoleAsync(user1, "SuperAdmin");
        //    await _userManager.AddToRoleAsync(user2, "Member");

        //    return Ok();
        //}
    }
}
