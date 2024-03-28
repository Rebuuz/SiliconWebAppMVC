
using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.ViewModels;

public class SignInViewModel
{
    [Display(Name = "Email Address", Prompt = "Enter your email address", Order = 0)]
    [EmailAddress]
    [Required(ErrorMessage = "Email address is required")]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    [Display(Name = "Password", Prompt = "Enter your password", Order = 1)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// bool remember me
    /// </summary>
    [Display(Name = "Remember me", Order = 2)]
    public bool RememberMe { get; set; }


}


