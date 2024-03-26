using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SiliconMVC.Helpers;

namespace SiliconMVC.Models;

public class SignUpFormModel
{
    /// <summary>
    /// Firstname
    /// </summary>
    [DataType(DataType.Text)]
    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "Enter a first name")]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Lastname
    /// </summary>
    [DataType(DataType.Text)]
    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Enter a last name")]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Email address
    /// </summary>
    [Display(Name = "Email Address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email address is required")]
    [RegularExpression("^[^@\\s]+@[^\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Your email address is invalid")]
    public string EmailAddress { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$", ErrorMessage = "Invalid password. Must contain 8 signs, one capitol letter, one small letter, a number and one special sign.")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// Confirm password and compare to the one above
    /// </summary>
    [Display(Name = "Password", Prompt = "Confirm your password", Order = 4)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Must compare password.")]
    [Compare(nameof(Password), ErrorMessage = "Password does not match.")]
    public string ConfirmPassword { get; set; } = null!;

    /// <summary>
    /// Checkbox 
    /// </summary>
    [Display(Name = "I agree to the Terms & Conditions", Order = 5)]
    [CheckboxRequired(ErrorMessage = "You must accept the terms and conditions to proceed.")]
    public bool TermsAndConditions { get; set; } = false;

}


