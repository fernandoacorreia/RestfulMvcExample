using System.Web.Mvc;
using RestfulMvcExample.Models;

namespace RestfulMvcExample.Controllers
{
    // Web service class
    public class ContactsController : Controller
    {
        // reference to contact repository object
        private readonly IContactRepository _repository;

        // default constructor will create a new instance of the repository
        public ContactsController() : this(new ContactRepository())
        {
        }

        // alternate constructor for unit testing
        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        // Get all contacts
        public ActionResult Index()
        {
            var data = _repository.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // Get a contact
        public ActionResult Get(int id)
        {
            var data = _repository.Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // Add a new contact
        public ActionResult Post(Contact contact)
        {
            _repository.Add(contact);
            return Json(contact);
        }

        // Update a contact
        public ActionResult Put(int id, Contact contact)
        {
            _repository.Update(id, contact);
            return Json(contact);
        }

        // Delete a contact
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            var data = new { message = "Contact deleted." };
            return Json(data);
        }
    }
}
