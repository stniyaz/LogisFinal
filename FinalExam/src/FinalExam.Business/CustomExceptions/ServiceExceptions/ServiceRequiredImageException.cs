using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.CustomExceptions.ServiceExceptions
{
    public class ServiceRequiredImageException : Exception
    {
        public string PropertyName { get; set; }
        public ServiceRequiredImageException()
        {
        }

        public ServiceRequiredImageException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
