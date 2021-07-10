using Contacts.Management.Models;

namespace Contacts.Management.Tests.Helper
{
    public class Requests
    {
        public static Contact ContactRequest()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Vikrant",
                LastName = "Buchade",
                Email = "Vikrant.Buchade@outlook.com",
                PhoneNumber = "9890446585",
                IsActive = true
            };
        }
    }
}
