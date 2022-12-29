using AgricultureUI.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService; //creating new object from Interface (DAL layer)  to achieve CRUD operations without using BL Manager Class
        //construct the related Interface to be able to use the object
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        //CRUD List Operations
        public IActionResult Index()
        {
            var vList = _serviceService.GetListAll();
            return View(vList);
        }

        //CRUD Insert Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult AddService()
        {
            return View(new ServiceAddViewModel());
        }
        [HttpPost] //The POST Attribute works after action has taken (click button)
        public IActionResult AddService(ServiceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = model.Title,
                   Image= model.Image,
                   Description= model.Description,
                });
                return RedirectToAction("Index");
            }
         return View(model);
            
        }


        //CRUD Delete Operation
        public IActionResult DeleteService(int id)
        {
            var vDelete = _serviceService.GetById(id); //assign vDelete with the ID
            _serviceService.Delete(vDelete); //Then delete the value  

            return RedirectToAction("Index");
        }


        //CRUD Update Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult UpdateService(int id)
        {
            var vUpdate = _serviceService.GetById(id);
            return View(vUpdate);
        }
        [HttpPost]//The POST Attribute works after action has taken (click button)
        public IActionResult UpdateService(Service service)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }
    }
}
