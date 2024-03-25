using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.Models;

public class AccountDetailsAddressInfoModel
{
    /// <summary>
    /// Making all of these not required to add....
    /// want to make all of them required if they fill in one, except addressline 2 which is ultimately optional. 
    /// </summary>
    [Display(Name = "Address line 1", Prompt = "Enter your address line", Order = 0)]
    public string? AddressLine_1 { get; set; }

    [Display(Name = "Address line 2", Prompt = "Enter your second address line", Order = 1)]
    public string? AddressLine_2 { get; set; } 

    [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 3)]
    [DataType(DataType.PostalCode)]
    public string? PostalCode { get; set; }

    [Display(Name = "City", Prompt = "Enter your city", Order = 4)]
    public string? City { get; set; }
}
