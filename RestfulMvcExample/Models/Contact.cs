using System.Collections.Generic;
using System.Linq;

namespace RestfulMvcExample.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Href
        {
            get
            {
                return "/contacts/" + Id;
            }
        }
    }

    public interface IContactRepository
    {
        void Add(Contact contact);
        void Delete(int contactId);
        object Get(int contactId);
        List<Contact> GetAll();
        void Update(int contactId, Contact contact);
    }

    public class ContactRepository : IContactRepository
    {
        static private readonly Dictionary<int, Contact> contactList = new Dictionary<int,Contact>();

        public List<Contact> GetAll()
        {
            List<Contact> contacts = contactList.Select(c => c.Value).ToList();
            return contacts;
        }

        public object Get(int contactId)
        {
            return contactList[contactId];
        }

        public void Delete(int contactId)
        {
            contactList.Remove(contactId);
        }

        public void Add(Contact contact)
        {
            contactList[contact.Id] = contact;
        }

        public void Update(int contactId, Contact contact)
        {
            contactList[contactId] = contact;
        }
    }
}
