using Microsoft.AspNetCore.Mvc;

namespace SiliconMVC.Controllers;

public class HomeController : Controller
{
    /// <summary>
    /// genererar min startsida (index)
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {

        return View();
    }
}
