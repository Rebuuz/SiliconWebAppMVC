using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

public class AuthController(UserService userService) : Controller
{
    /// <summary>
    /// to access userservice
    /// </summary>
    private readonly UserService _userService = userService;

    /// <summary>
    /// For my signup view
    /// </summary>
    /// <returns></returns>
    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp() => View(new SignUpViewModel());


    /// <summary>
    /// Routing for my form posts ... 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        ///If working, go to sign in 
        
        if (ModelState.IsValid) 
        {
            var result = await _userService.CreateUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCodes.OK)
                return RedirectToAction("SignIn", "Auth");
        }
        
        return View(viewModel);
    }

    /// <summary>
    /// For my Sign in view 
    /// </summary>
    /// <returns></returns>
    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn() => View(new SignInViewModel());

    [Route("/signin")]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        ///If working, redirect to home page 

        if (ModelState.IsValid)
        {
            var result = await _userService.SignInUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCodes.OK)
                return RedirectToAction("Details", "Account");
        }

        viewModel.ErrorMsg = "Incorrect email or password.";
        return View(viewModel);

        
    }
}
