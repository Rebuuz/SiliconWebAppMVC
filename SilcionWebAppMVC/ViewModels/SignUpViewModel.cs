using Infrastructure.Helpers;
using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.ViewModels;

public class SignUpViewModel
{
    //[Required]
    public string Title { get; set; } = "Sign Up";
    public SignUpModel Form { get; set; } = new SignUpModel();


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
    [Required(ErrorMessage = "Email address is required. Must be of format xx@xx.xx.")]
    [RegularExpression("^[^@\\s]+@[^\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Email address is required. Must be of format xx@xx.xx.")]
    public string EmailAddress { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required. Must contain 8 signs, one capitol letter, one small letter, a number and one special sign.")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$", ErrorMessage = "Password is required. Must contain 8 signs, one capitol letter, one small letter, a number and one special sign.")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// Confirm password and compare to the one above
    /// </summary>
    [Display(Name = "Password", Prompt = "Confirm your password", Order = 4)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Must compare password.")]
    [Compare(nameof(Password), ErrorMessage = "Must compare password.")]
    public string ConfirmPassword { get; set; } = null!;

    /// <summary>
    /// Checkbox 
    /// </summary>
    [Display(Name = "I agree to the Terms & Conditions", Order = 5)]
    [CheckboxRequired(ErrorMessage = "You must accept the terms and conditions to proceed.")]
    public bool TermsAndConditions { get; set; } = false;


}
