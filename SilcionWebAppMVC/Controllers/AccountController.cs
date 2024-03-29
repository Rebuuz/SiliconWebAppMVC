using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;


    //[Authorize] ?? 

    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Auth");


        var userEntity = await _userManager.GetUserAsync(User);

        var viewModel = new AccountDetailsViewModel()
        {
            User = userEntity!
        };

        return View(viewModel);
               

        //var viewModel = new AccountDetailsViewModel();
        ////to save to database later
        ////viewModel.BasicInfo = _accountService.GetBasicInfo();
        ////viewModel.AddressInfo = _accountService.AddressInfo();

        //return View(viewModel);
    }

    //when clicking Save changes on basic info in account details

    [HttpPost]
    public IActionResult BasicInfo(AccountDetailsViewModel viewModel)
    {
        //when saving to database
        //_accountService.SaveBasicInfo(viewModel.BasicInfo);
        return RedirectToAction(nameof(Details));
    }

    //when clicking save changes on address info in account details

    [HttpPost]
    public IActionResult AddressInfo(AccountDetailsViewModel viewModel)
    {
        //when saving to database
        //_accountService.SaveAddressInfo(viewModel.AddressInfo);
        return RedirectToAction(nameof(Details));
    }

}
