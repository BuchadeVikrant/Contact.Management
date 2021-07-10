using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Management.Models.ErrorResponses
{
    public class Error
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Error(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}
