using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.Enums;
using Appointment_Booking.Service.Services.CampanyService;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Booking.Web.Controllers
{
    public class CampanyController : Controller
    {

        private readonly ICampanyService campanyService;
        


        public CampanyController (ICampanyService campanyService )
        {

            this.campanyService = campanyService;
           
        }

        public IActionResult Index(int id , string name)
        {
            var campanies = campanyService.GetCampanies(id,name);

            ViewBag.name = name;

            return View(campanies);
        }

        [HttpGet]
        public IActionResult AddCampany()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCampany (CampanyDto dto)
        {

            campanyService.AddCampany(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCampany (int id)
        {
            ViewBag.id = id;

            ViewBag.campany = campanyService.GetCampany(id);

            return View();
        }

        [HttpPost]
        public IActionResult EditCampany(CampanyDto dto)
        {

            campanyService.EditCampany(dto);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteCampany(int id)
        {

            campanyService.DeleteCampany(id);

            return RedirectToAction("Index");
        }

    }
}
