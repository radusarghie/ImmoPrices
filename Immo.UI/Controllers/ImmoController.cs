using Microsoft.AspNetCore.Mvc;

namespace Immo.UI.Controllers
{
    public class ImmoController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
