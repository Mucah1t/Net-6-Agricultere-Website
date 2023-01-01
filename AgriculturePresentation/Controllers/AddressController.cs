using BusinessLayer.Abstract;
using BusinessLayer.Validatio_Rules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAdressService _addressService;

        public AddressController(IAdressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var vList = _addressService.GetListAll();
            return View(vList);
        }


        //CRUD Update Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult UpdateAddress(int id)
        {
            var vUpdate = _addressService.GetById(id);
            return View(vUpdate);
        }
        [HttpPost]//The POST Attribute works after action has taken (click button)
        public IActionResult UpdateAddress(Adress adress)
        {
            AdressValidator validationRules = new AdressValidator(); //We add our validator to the insert section
            ValidationResult result = validationRules.Validate(adress);

            if (result.IsValid)
            {
                    _addressService.Update(adress);
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
