using Contacts.Management.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Management.Models.ErrorResponses
{
    public class ValidationError : Error
    {
        public string Field { get; set; }

        public ValidationError(string field, string message) : base(ErrorCodes.ValidationError.ToString(), message)
        {
            Field = field;
        }
    }
}
