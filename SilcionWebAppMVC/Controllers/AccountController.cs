using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

// protects the account page if not signed in. 
[Authorize]
public class AccountController(UserManager<UserEntity> userManager, AddressManager addressManager, AccountManager accountManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    //private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly AddressManager _addressManager = addressManager;
    private readonly AccountManager _accountManager = accountManager;

    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {

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
                

                var adressId = await _addressManager.GetOrCreateAddressAsync(viewModel.AddressInfo.AddressLine_1, viewModel.AddressInfo.AddressLine_2, viewModel.AddressInfo.PostalCode, viewModel.AddressInfo.City);


                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    user.AddressId = adressId;
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        //meddelande
                    }
                }

            }
        }

        viewModel.ProfileInfo ??= await PopulateProfileInfoAsync();
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }


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

        var user = await _userManager.GetUserAsync(User);
        if (user != null && user.AddressId != null)
        {
            var address = await _addressManager.GetAddressAsync(user.AddressId.Value);
            if (address != null)
            {
                return new AccountDetailsAddressInfoModel
                {
                    Id = user.AddressId,
                    AddressLine_1 = address.AddressOne,
                    AddressLine_2 = address.AddressTwo,
                    PostalCode = address.PostalCode,
                    City = address.City
                };
            }
        }

        return new AccountDetailsAddressInfoModel();

    }

    [HttpGet]
    [Route("/account/courses")]
    public async Task<IActionResult> Courses()
    {

        using var http = new HttpClient();
        var response = await http.GetAsync("http://localhost:5295/api/Courses");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<CoursesEntity>>(json);


        return View(data);
    }


    /// <summary>
    /// Upload profile image method
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        var result = await _accountManager.UploadProfileImageAsync(User, file);

        return RedirectToAction("Details", "Account");
    }

}
