using System;
using System.Text;
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
        [TestInitialize]
        public void Initialize()
        {
            ContactManager.Reload();
        }

        [TestMethod]
        public void TestIndex()
        {
            ContactsController controller = new ContactsController();
            JsonResult result = controller.Index() as JsonResult;
            List<Contact> contacts = result.Data as List<Contact>;
            Assert.AreEqual(3, contacts.Count());
        }

        [TestMethod]
        public void TestGet()
        {
            const int idToGet = 2;
            ContactsController controller = new ContactsController();
            JsonResult result = controller.Get(idToGet) as JsonResult;
            Contact contact = result.Data as Contact;
            Assert.AreEqual(idToGet, contact.Id);
        }

        [TestMethod]
        public void TestPost()
        {
            const int contactId = 4;
            const string contactName = "Contact four";
            Contact newContact = new Contact { Id = contactId, Name = contactName, Email = "four@example.com", Phone = "555-4444" };
            ContactsController controller = new ContactsController();
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
            ContactsController controller = new ContactsController();
            JsonResult result = controller.Put(contactId, updatedContact) as JsonResult;
            result = controller.Get(contactId) as JsonResult;
            Contact contact = result.Data as Contact;
            Assert.AreEqual(contactName, contact.Name);
        }

        [TestMethod]
        public void TestDeleteGet()
        {
            const int contactId = 1;
            ContactsController controller = new ContactsController();
            JsonResult result = controller.Delete(contactId) as JsonResult;
            result = controller.Get(contactId) as JsonResult;
            Assert.AreEqual("{ message = Contact not found. }", result.Data.ToString());
        }

        [TestMethod]
        public void TestDeleteIndex()
        {
            const int contactId = 1;
            ContactsController controller = new ContactsController();
            JsonResult result = controller.Delete(contactId) as JsonResult;
            result = controller.Index() as JsonResult;
            List<Contact> contacts = result.Data as List<Contact>;
            Assert.AreEqual(2, contacts.Count());
        }
    }
}
