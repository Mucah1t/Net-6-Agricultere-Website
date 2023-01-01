using BusinessLayer.Abstract;
using BusinessLayer.Validatio_Rules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;//creating new object from Interface (DAL layer)  to achieve CRUD operations without using BL Manager Class
        //construct the related Interface to be able to use the object
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var vList = _contactService.GetListAll();
            return View(vList);
        }


        //CRUD Delete Operation
        public IActionResult DeleteContact(int id)
        {
            var vDelete = _contactService.GetById(id); //assign vDelete with the ID
            _contactService.Delete(vDelete); //Then delete the value  

            return RedirectToAction("Index");
        }

        public IActionResult MessageDetails(int id)
        {
            var value = _contactService.GetById(id);
            return View(value);
        }

    }
}
