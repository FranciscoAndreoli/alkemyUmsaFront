using Data.DTO;
using Microsoft.AspNetCore.Mvc;
namespace alkemyUmsaFront.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Ingresar(LoginDto dto)
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
