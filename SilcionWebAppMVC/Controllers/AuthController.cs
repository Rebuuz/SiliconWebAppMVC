using Microsoft.AspNetCore.Mvc;

namespace SiliconMVC.Controllers;

public class AuthController : Controller
{
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }
}
