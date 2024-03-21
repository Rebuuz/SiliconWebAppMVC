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

    [Route("/")]
    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();

        return View(viewModel);
    }
}
