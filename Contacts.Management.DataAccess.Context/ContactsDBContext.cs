using Contacts.Management.Models;
using System.Data.Entity;

namespace Contacts.Management.DataAccess.Context
{
    public class ContactsDBContext : DbContext
    {
        public ContactsDBContext() : base("ContactsManagementDB")
        {

        }

        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
