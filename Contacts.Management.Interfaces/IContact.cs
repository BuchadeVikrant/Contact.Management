using Contacts.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Management.Interfaces
{
    public interface IContact
    {
        List<Contact> GetContacts();
        bool AddContact(Contact contact);
        bool UpdateContact(Contact contact);
        bool ChangeContactStatus(int contactId);
    }
}
