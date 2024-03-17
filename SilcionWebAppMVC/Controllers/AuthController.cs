using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

public class AuthController : Controller
{

    /// <summary>
    /// For my view 
    /// </summary>
    /// <returns></returns>
    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();


        return View(viewModel);
    }

    /// <summary>
    /// Routing for my form posts ... 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>

    [Route("/signup")]
    [HttpPost]
    public IActionResult SignUp(SignUpViewModel viewModel)
    {
        ///Return to same page
        
        if (!ModelState.IsValid)
            return View(viewModel);

        return RedirectToAction("SignIn", "Auth");
    }
}
