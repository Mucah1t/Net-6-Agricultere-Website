using AgricultureUI.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Validatio_Rules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService; //creating new object from Interface (DAL layer)  to achieve CRUD operations without using BL Manager Class
        //construct the related Interface to be able to use the object

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var vList = _teamService.GetListAll();
            return View(vList);
        }


        //CRUD Insert Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost] //The POST Attribute works after action has taken (click button)
        public IActionResult AddTeam(Team team)
        {
            TeamValidator validationRules= new TeamValidator(); //We add our validator to the insert section
            ValidationResult result= validationRules.Validate(team);

            if (result.IsValid)
            {
                _teamService.Insert(team);
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
        public IActionResult DeleteTeam(int id)
        {
            var vDelete = _teamService.GetById(id); //assign vDelete with the ID
            _teamService.Delete(vDelete); //Then delete the value  

            return RedirectToAction("Index");
        }


        //CRUD Update Operation
        [HttpGet] //The GET Attribute works when the page loads
        public IActionResult UpdateTeam(int id)
        {
            var vUpdate = _teamService.GetById(id);
            return View(vUpdate);
        }
        [HttpPost]//The POST Attribute works after action has taken (click button)
        public IActionResult UpdateTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator(); //We add our validator to the insert section
            ValidationResult result = validationRules.Validate(team);

            if (result.IsValid)
            {
                _teamService.Update(team);
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
