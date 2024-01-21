using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.CustomExceptions.SettingExceptions
{
    public class SettingNotFoundException : Exception
    {
        public SettingNotFoundException()
        {
        }

        public SettingNotFoundException(string? message) : base(message)
        {
        }
    }
}
