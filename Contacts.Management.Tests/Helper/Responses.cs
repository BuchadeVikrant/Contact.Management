using Contacts.Management.Models;
using System.Collections.Generic;

namespace Contacts.Management.Tests.Helper
{
    public class Responses
    {
        public static List<Contact> ContactsResponse()
        {
            return new List<Contact>()
            {
                new Contact()
                {
                    Id = 1,
                    FirstName = "Vikrant",
                    LastName = "Buchade",
                    Email = "Vikrant.Buchade@outlook.com",
                    PhoneNumber="9890446585",
                    IsActive=true
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = "Prashant",
                    LastName = "Dalvi",
                    Email = "Prashant.Dalvi@gmail.com",
                    PhoneNumber="8959654232",
                    IsActive=true
                }
            };
        }
    }
}
