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
    private readonly SignInManager<UserEntity> _signInManager;

    public AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        ///if working, go to sign in when created a user successfully
        if (ModelState.IsValid)
        {
            ///check if user already exists by email
            var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email);
            if (exists)
            {
                ModelState.AddModelError("AlreadyExistrs", "User with the same email address already exists.");
                ViewData["ErrorMessage"] = "User with the same email address already exists.";
                return View(viewModel);
            }

            ///create user (eventuellt flytta till userfactory
            var userEntity = new UserEntity
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                UserName = viewModel.Email
            };

            ///register user
            var result = await _userManager.CreateAsync(userEntity, viewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Auth");
            }
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
    public async Task<IActionResult> SignIn(SignInViewModel viewModel) 
    {
        ViewData["Title"] = "Sign In";
        
        ///If working, redirect to user home page after signing in
        ///
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            }
        }

        ModelState.AddModelError("IncorrectValues", "Email or password is not correct.");
        ViewData["ErrorMessage"] = "Incorrect email or password.";

        return View(viewModel);
    }

   
}
