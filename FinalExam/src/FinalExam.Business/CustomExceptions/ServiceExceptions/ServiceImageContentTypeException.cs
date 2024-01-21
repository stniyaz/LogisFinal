using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.CustomExceptions.ServiceExceptions
{
    public class ServiceImageContentTypeException : Exception
    {
        public string PropertyName { get; set; }
        public ServiceImageContentTypeException()
        {
        }

        public ServiceImageContentTypeException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
