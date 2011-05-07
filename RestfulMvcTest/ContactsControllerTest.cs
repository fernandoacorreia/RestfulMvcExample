using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestfulMvcExample.Models;
using RestfulMvcExample.Controllers;

namespace RestfulMvcTest
{
    [TestClass]
    public class ContactsControllerTest
    {
        private IContactRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new ContactRepository();
            _repository.Add(new Contact { Id = 1, Name = "Contact one", Email = "one@example.com", Phone = "555-1234" });
            _repository.Add(new Contact { Id = 2, Name = "Contact two", Email = "two@example.com", Phone = "555-2222" });
            _repository.Add(new Contact { Id = 3, Name = "Contact three", Email = "three@example.com", Phone = "555-3333" });
        }

        [TestMethod]
        public void TestIndex()
        {
            ContactsController controller = new ContactsController(_repository);
            JsonResult result = controller.Index() as JsonResult;
            List<Contact> contacts = result.Data as List<Contact>;
            Assert.AreEqual(3, contacts.Count());
        }

        [TestMethod]
        public void TestGet()
        {
            const int idToGet = 2;
            ContactsController controller = new ContactsController(_repository);
            JsonResult result = controller.Get(idToGet) as JsonResult;
            Contact contact = result.Data as Contact;
            Assert.AreEqual(idToGet, contact.Id);
        }

        [TestMethod]
        public void Get_Must_Return_Href()
        {
            const int idToGet = 2;
            ContactsController controller = new ContactsController(_repository);
            JsonResult result = controller.Get(idToGet) as JsonResult;
            Contact contact = result.Data as Contact;
            Assert.AreEqual("/contacts/2", contact.Href);
        }

        [TestMethod]
        public void TestPost()
        {
            const int contactId = 4;
            const string contactName = "Contact four";
            Contact newContact = new Contact { Id = contactId, Name = contactName, Email = "four@example.com", Phone = "555-4444" };
            ContactsController controller = new ContactsController(_repository);
            JsonResult result = controller.Post(newContact) as JsonResult;
            result = controller.Get(contactId) as JsonResult;
            Contact contact = result.Data as Contact;
            Assert.AreEqual(contactName, contact.Name);
        }

        [TestMethod]
        public void TestPut()
        {
            const int contactId = 3;
            const string contactName = "Updated contact";
            Contact updatedContact = new Contact { Id = contactId, Name = contactName, Email = "updated@example.com", Phone = "555-7777" };
            ContactsController controller = new ContactsController(_repository);
            JsonResult result = controller.Put(contactId, updatedContact) as JsonResult;
            result = controller.Get(contactId) as JsonResult;
            Contact contact = result.Data as Contact;
            Assert.AreEqual(contactName, contact.Name);
        }

        [TestMethod]
        public void TestDeleteGet()
        {
            const int contactId = 1;
            ContactsController controller = new ContactsController(_repository);
            JsonResult result = controller.Delete(contactId) as JsonResult;
            try
            {
                result = controller.Get(contactId) as JsonResult;
                Assert.Fail("Contact was not deleted.");
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                return;
            }
        }

        [TestMethod]
        public void TestDeleteIndex()
        {
            const int contactId = 1;
            ContactsController controller = new ContactsController(_repository);
            JsonResult result = controller.Delete(contactId) as JsonResult;
            result = controller.Index() as JsonResult;
            List<Contact> contacts = result.Data as List<Contact>;
            Assert.AreEqual(2, contacts.Count());
        }
    }
}
