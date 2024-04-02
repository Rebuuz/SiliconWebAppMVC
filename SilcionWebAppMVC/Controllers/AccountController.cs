using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

// protects the account page if not signed in. 
[Authorize]
public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {

        //var viewModel = new AccountDetailsViewModel()
        //{
        //    BasicInfo = await PopulateDetailsViewModelAsync()
        //};

        var viewModel = new AccountDetailsViewModel();
        viewModel.ProfileInfo ??= await PopulateProfileInfoAsync();
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }


    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfo != null)
        {
            if (viewModel.BasicInfo.FirstName != null && viewModel.BasicInfo.LastName != null && viewModel.BasicInfo.EmailAddress != null)
            {

                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfo.FirstName;
                    user.LastName = viewModel.BasicInfo.LastName;
                    user.Email = viewModel.BasicInfo.EmailAddress;
                    user.PhoneNumber = viewModel.BasicInfo.Phone;
                    user.Bio = viewModel.BasicInfo.Bio;

                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("IncorrectValues", "Something went wrong, unable to save the data!");
                        ViewData["ErrorMessage"] = "Something went wrong, unable to save the data!";
                    }
                }
            }
        }

        if (viewModel.AddressInfo != null)
        {
            if (viewModel.AddressInfo.AddressLine_1 != null && viewModel.AddressInfo.PostalCode != null && viewModel.AddressInfo.City != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfo.FirstName;
                    user.LastName = viewModel.BasicInfo.LastName;
                    user.Email = viewModel.BasicInfo.EmailAddress;
                    user.PhoneNumber = viewModel.BasicInfo.Phone;
                    user.Bio = viewModel.BasicInfo.Bio;

                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("IncorrectValues", "Something went wrong, unable to save the data!");
                        ViewData["ErrorMessage"] = "Something went wrong, unable to save the data!";
                    }
                }
            }
        }

        viewModel.ProfileInfo ??= await PopulateProfileInfoAsync();
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }




    //when clicking Save changes on basic info in account details

    //[HttpPost]
    //public IActionResult SaveBasicInfo(AccountDetailsViewModel viewModel)
    //{
    //    if (TryValidateModel(viewModel.BasicInfo))
    //    {
    //        return RedirectToAction("Details", "Account");
    //    }

    //    ///return to details page
    //    return View("Details", viewModel);
    //}

    ////when clicking save changes on address info in account details

    //[HttpPost]
    //public IActionResult SaveAddressInfo(AccountDetailsViewModel viewModel)
    //{
    //    if (TryValidateModel(viewModel.AddressInfo))
    //    {
    //        return RedirectToAction("Details", "Account");
    //    }

    //    ///return to details page
    //    return View("Details", viewModel);
    //}

    private async Task<AccountDetailsProfileInfoModel> PopulateProfileInfoAsync()
    {

        var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsProfileInfoModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            EmailAddress = user.Email!,
            //add imageurl...
        };

    }

    private async Task<AccountDetailsBasicInfoModel> PopulateBasicInfoAsync()
    {

        var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsBasicInfoModel
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            EmailAddress = user.Email!,
            Phone = user.PhoneNumber,
            Bio = user.Bio,
        };

    }

    private async Task<AccountDetailsAddressInfoModel> PopulateAddressInfoAsync()
    {

        //var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsAddressInfoModel();
        

    }

}
