﻿using System.Collections.Generic;
using System.Linq;

namespace RestfulMvcExample.Models
{
    // Contact domain object
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // URL of this resource
        public string Href
        {
            get
            {
                return "/contacts/" + Id;
            }
        }
    }

    // contact repository interface
    public interface IContactRepository
    {
        void Add(Contact contact);
        void Delete(int contactId);
        object Get(int contactId);
        List<Contact> GetAll();
        void Update(int contactId, Contact contact);
    }

    // A contact repository that keeps its data in memory.
    // Data will remain while the service is running and will vanish when the service is stopped.
    public class ContactRepository : IContactRepository
    {
        static private readonly Dictionary<int, Contact> ContactList = new Dictionary<int,Contact>();

        public List<Contact> GetAll()
        {
            List<Contact> contacts = ContactList.Select(c => c.Value).ToList();
            return contacts;
        }

        public object Get(int contactId)
        {
            return ContactList[contactId];
        }

        public void Delete(int contactId)
        {
            ContactList.Remove(contactId);
        }

        public void Add(Contact contact)
        {
            ContactList[contact.Id] = contact;
        }

        public void Update(int contactId, Contact contact)
        {
            ContactList[contactId] = contact;
        }
    }
}
