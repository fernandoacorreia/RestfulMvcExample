using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestfulMvcExample.Models;

namespace RestfulMvcExample.Controllers
{
    public class ContactsController : Controller
    {
        public ActionResult Index()
        {
            ContactManager contactManager = new ContactManager();
            var data = contactManager.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int id)
        {
            ContactManager contactManager = new ContactManager();
            try
            {
                var data = contactManager.Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                var data = new { message = "Contact not found." };
                return Json(data);
            }
        }

        public ActionResult Post(Contact contact)
        {
            ContactManager contactManager = new ContactManager();
            contactManager.Add(contact);
            return Json(contact);
        }

        public ActionResult Put(int id, Contact contact)
        {
            ContactManager contactManager = new ContactManager();
            contactManager.Update(id, contact);
            return Json(contact);
        }

        public ActionResult Delete(int id)
        {
            ContactManager contactManager = new ContactManager();
            contactManager.Delete(id);
            var data = new { message = "Contact deleted." };
            return Json(data);
        }
    }
}
