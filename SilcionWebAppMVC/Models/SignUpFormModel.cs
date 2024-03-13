using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.Models;

public class SignUpFormModel
{
    /// <summary>
    /// Firstname
    /// </summary>
    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "Invalid First Name")]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Lastname
    /// </summary>
    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Invalid Last Name")]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Email address
    /// </summary>
    [Display(Name = "Email Address", Prompt = "Enter your email address", Order = 2)]
    [EmailAddress]
    [RegularExpression("^[^@\\s]+@[^\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Invalid Email address")]
    public string EmailAddress { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$", ErrorMessage = "Invalid password format.")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// Confirm password and compare to the one above
    /// </summary>
    [Display(Name = "Password", Prompt = "Confirm your password", Order = 4)]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Password does not match")]
    public string ConfirmPassword { get; set; } = null!;

    /// <summary>
    /// Checkbox 
    /// </summary>
    [Display(Name = "I agree to the Terms & Conditions", Order = 5)]
    [Required(ErrorMessage = "You must agree to the Terms & Conditions")]
    public bool TermsAndConditions { get; set; } = false;

}
