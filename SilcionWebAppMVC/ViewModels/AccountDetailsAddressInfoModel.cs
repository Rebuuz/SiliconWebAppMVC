using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.ViewModels;

public class AccountDetailsAddressInfoModel
{
    /// <summary>
    /// Making all of these not required to add....
    /// want to make all of them required if they fill in one, except addressline 2 which is ultimately optional. 
    /// </summary>
    /// 
    public int? Id { get; set; } 

    [Required(ErrorMessage = "A valid address is required")]
    [Display(Name = "Address line 1", Prompt = "Enter your address line", Order = 0)]
    public string? AddressLine_1 { get; set; }

    [Display(Name = "Address line 2", Prompt = "Enter your second address line", Order = 1)]
    public string? AddressLine_2 { get; set; }

    [Required(ErrorMessage = "A valid postal code is required.")]
    [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 3)]
    [DataType(DataType.PostalCode)]
    public string? PostalCode { get; set; }

    [Required(ErrorMessage = "A valid city is required.")]
    [Display(Name = "City", Prompt = "Enter your city", Order = 4)]
    public string? City { get; set; }
}
