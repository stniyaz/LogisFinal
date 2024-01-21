using FinalExam.Business.ViewModels;

namespace FinalExam.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task Login(LoginVM model);
        Task LogOut();
    }
}
