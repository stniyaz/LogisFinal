using FinalExam.Business.CustomExceptions.AccountExceptions;
using FinalExam.Business.Services.Interfaces;
using FinalExam.Business.ViewModels;
using FinalExam.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalExam.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Login(LoginVM model)
        {
            AppUser? user = null;

            user = await _userManager.FindByNameAsync(model.UsernameOrEmail)
                ?? await _userManager.FindByEmailAsync(model.UsernameOrEmail);

            if (user is null) throw new UserInvalidCredentialsExceptions("invalid credentials!");

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if(!result.Succeeded) throw new UserInvalidCredentialsExceptions("invalid credentials!");
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
