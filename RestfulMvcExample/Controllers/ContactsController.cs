using System.Web.Mvc;
using RestfulMvcExample.Models;

namespace RestfulMvcExample.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactsController() : this(new ContactRepository())
        {
        }

        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var data = _repository.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int id)
        {
            var data = _repository.Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Post(Contact contact)
        {
            _repository.Add(contact);
            return Json(contact);
        }

        public ActionResult Put(int id, Contact contact)
        {
            _repository.Update(id, contact);
            return Json(contact);
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            var data = new { message = "Contact deleted." };
            return Json(data);
        }
    }
}
