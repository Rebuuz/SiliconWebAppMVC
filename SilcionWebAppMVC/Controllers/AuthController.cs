﻿using Microsoft.AspNetCore.Mvc;
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
        ///If working, go to sign in 
        
        if (!ModelState.IsValid)
            return View(viewModel);

        return RedirectToAction("SignIn", "Auth");
    }

    /// <summary>
    /// For my Sign in view 
    /// </summary>
    /// <returns></returns>
    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();


        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public IActionResult SignIn(SignInViewModel viewModel)
    {
        ///If working, go to account page

        if (!ModelState.IsValid)
            return View(viewModel);

        return RedirectToAction("Account", "Auth");
    }
}
