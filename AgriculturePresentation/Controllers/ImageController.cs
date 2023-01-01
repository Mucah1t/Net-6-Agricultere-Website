using BusinessLayer.Abstract;
using BusinessLayer.Validatio_Rules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService; //creating new object from Interface (DAL layer)  to achieve CRUD operations without using BL Manager Class
        //construct the related Interface to be able to use the object
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var vList = _imageService.GetListAll();
            return View(vList);
        }

        //CRUD Insert Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost] //The POST Attribute works after action has taken (click button)
        public IActionResult AddImage(Image image)
        {
            ImageValidator validationRules = new ImageValidator(); //We add our validator to the insert section
            ValidationResult result = validationRules.Validate(image);

            if (result.IsValid)
            {
                _imageService.Insert(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }



        //CRUD Delete Operation
        public IActionResult DeleteImage(int id)
        {
            var vDelete = _imageService.GetById(id); //assign vDelete with the ID
            _imageService.Delete(vDelete); //Then delete the value  

            return RedirectToAction("Index");
        }


        //CRUD Update Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult UpdateImage(int id)
        {
            var vUpdate = _imageService.GetById(id);
            return View(vUpdate);
        }
        [HttpPost]//The POST Attribute works after action has taken (click button)
        public IActionResult UpdateImage(Image image)
        {
            ImageValidator validationRules = new ImageValidator(); //We add our validator to the insert section
            ValidationResult result = validationRules.Validate(image);

            if (result.IsValid)
            {
                _imageService.Update(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}

