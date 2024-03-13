using Microsoft.AspNetCore.Mvc;

namespace SiliconMVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
