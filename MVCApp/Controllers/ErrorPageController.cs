using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
