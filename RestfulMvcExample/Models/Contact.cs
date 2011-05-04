using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestfulMvcExample.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class ContactManager
    {
        static private Dictionary<int, Contact> contactList;

        static ContactManager()
        {
            ContactManager.Reload();
        }

        public static void Reload()
        {
            contactList = new Dictionary<int, Contact> {
                {1, new Contact { Id = 1, Name = "Contact one", Email = "one@example.com", Phone = "555-1234" } },
                {2, new Contact { Id = 2, Name = "Contact two", Email = "two@example.com", Phone = "555-2222" } },
                {3, new Contact { Id = 3, Name = "Contact three", Email = "three@example.com", Phone = "555-3333" } }
            };
        }

        public List<Contact> GetAll()
        {
            List<Contact> contacts = contactList.Select(c => c.Value).ToList();
            return contacts;
        }

        internal object Get(int contactId)
        {
            return contactList[contactId];
        }

        internal void Delete(int contactId)
        {
            contactList.Remove(contactId);
        }

        internal void Add(Contact contact)
        {
            contactList[contact.Id] = contact;
        }

        internal void Update(int contactId, Contact contact)
        {
            contactList[contactId] = contact;
        }
    }
}
