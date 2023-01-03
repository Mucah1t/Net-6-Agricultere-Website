using AgricultureUI.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var vList=_adminService.GetListAll();
            return View(vList);
        }


        //CRUD Insert Operation
        [HttpGet]  //The GET Attribute works when the page loads
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost] //The POST Attribute works after action has taken (e.g. click button)
        public IActionResult AddAdmin(Admin admin)
        {
            _adminService.Insert(admin);
            return RedirectToAction("Index");
        }


        //CRUD Delete Operation
        public IActionResult DeleteAdmin(int id)
        {
            var vDelete = _adminService.GetById(id); //assign vDelete with the ID
            _adminService.Delete(vDelete); //Then delete the value  

            return RedirectToAction("Index");
        }


        //CRUD Update Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult UpdateAdmin(int id)
        {
            var vUpdate = _adminService.GetById(id);
            return View(vUpdate);
        }
        [HttpPost]//The POST Attribute works after action has taken (click button)
        public IActionResult UpdateAdmin(Admin admin)
        {
            _adminService.Update(admin);
            return RedirectToAction("Index");
        }
    }
}
