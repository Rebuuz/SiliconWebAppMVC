using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

public class AccountController : Controller
{
    ///Use later
    //private readonly AccountService _accountService;

    //public AccountController(AccountService accountService)
    //{
    //    _accountService = accountService;
    //}

    [Authorize]

    [Route("/account")]
    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        //to save to database later
        //viewModel.BasicInfo = _accountService.GetBasicInfo();
        //viewModel.AddressInfo = _accountService.AddressInfo();

        return View(viewModel);
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
