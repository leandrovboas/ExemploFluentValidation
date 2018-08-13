using AspNetCore.FluentValidation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.FluentValidation.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClienteVM model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(model);
        }
    }
}