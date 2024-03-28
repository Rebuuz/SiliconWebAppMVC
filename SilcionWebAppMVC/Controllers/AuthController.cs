using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

public class AuthController : Controller
{
    /// <summary>
    /// to access user
    /// </summary>

    private readonly UserManager<UserEntity> _userManager;

    public AuthController(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Signup view
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpModel viewModel)
    {
        ///if working, go to sign in when created a user successfully, make into an async
        if (ModelState.IsValid)
        {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.EmailAddress);

            _userManager.CreateAsync(UserEntity, viewModel.Password);
        }
        return View(viewModel);
    }

    /// <summary>
    /// sign in view
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    [Route("/signin")]
    public IActionResult SignIn(SignInViewModel viewModel) 
    {
        ViewData["Title"] = "Sign In";
        
        ///If working, redirect to user home page after signing in
        ///
        if (ModelState.IsValid)
        {

        }
        return View(viewModel);
    }

   
}
