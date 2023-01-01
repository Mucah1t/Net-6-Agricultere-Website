using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureUI.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService; //creating new object from Interface (DAL layer)  to achieve CRUD operations without using BL Manager Class
        //construct the related Interface to be able to use the object

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        //CRUD List Operations
        public IActionResult Index()
        {   var vList = _announcementService.GetListAll();
            return View(vList);
        }

        public IActionResult StatusToTrue(int id)
        {
            _announcementService.AnnouncementStatustoTrue(id);
            return RedirectToAction("Index");   
        }
        public IActionResult StatusToFalse(int id)
        {
            _announcementService.AnnouncementStatustoFalse(id);
            return RedirectToAction("Index");
        }


        //CRUD Insert Operation
        [HttpGet]  //The GET Attribute works when the page loads
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost] //The POST Attribute works after action has taken (e.g. click button)
        public IActionResult AddAnnouncemnet(Announcement announcement)
        {
            announcement.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
            announcement.Status = false;

            _announcementService.Insert(announcement);
            return RedirectToAction("Index");
        }


        //CRUD Delete Operation
        public IActionResult DeleteAnnouncement(int id)
        {
            var vDelete = _announcementService.GetById(id); //assign vDelete with the ID
            _announcementService.Delete(vDelete); //Then delete the value  

            return RedirectToAction("Index");
        }


        //CRUD Update Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult UpdateAnnouncement(int id)
        {
            var vUpdate = _announcementService.GetById(id);
            return View(vUpdate);
        }
        [HttpPost]//The POST Attribute works after action has taken (click button)
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            _announcementService.Update(announcement);
            return RedirectToAction("Index");
        }
    }
}

