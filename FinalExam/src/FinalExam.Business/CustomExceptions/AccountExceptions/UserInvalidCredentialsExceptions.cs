using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.CustomExceptions.AccountExceptions
{
    public class UserInvalidCredentialsExceptions : Exception
    {
        public UserInvalidCredentialsExceptions()
        {
        }

        public UserInvalidCredentialsExceptions(string? message) : base(message)
        {
        }
    }
}
