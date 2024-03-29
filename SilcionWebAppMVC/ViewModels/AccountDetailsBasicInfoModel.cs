using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.ViewModels;

public class AccountDetailsBasicInfoModel
{
    /// <summary>
    /// All information for basic info in account details... 
    /// Firstname, lastname and email is required.
    /// </summary>

    ///Profile Image
    [DataType(DataType.ImageUrl)]
    public string? ProfileImage { get; set; }

    /// Firstname
    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Lastname
    /// </summary>
    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
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
    /// Phone number (making this one optional just because it is not required when creating the account in the first place.
    /// </summary>
    [Display(Name = "Phone", Prompt = "Enter your phone", Order = 3)]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Phone number not correct format")]
    public string? Phone { get; set; }

    /// <summary>
    /// Bio (making this optional because it says optional in the design file)
    /// </summary>
    [Display(Name = "Bio", Prompt = "Add a short bio...", Order = 4)]
    [DataType(DataType.MultilineText)]
    public string? Bio { get; set; }
}
