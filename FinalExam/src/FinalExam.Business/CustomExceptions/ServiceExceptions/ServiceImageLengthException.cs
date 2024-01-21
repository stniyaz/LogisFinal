using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.CustomExceptions.ServiceExceptions
{
    public class ServiceImageLengthException : Exception
    {
        public string PropertyName { get; set; }
        public ServiceImageLengthException()
        {
        }

        public ServiceImageLengthException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
