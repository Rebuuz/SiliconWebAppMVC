using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.ViewModels;

public class AccountDetailsViewModel
{
    //public UserEntity User { get; set; } = null!;

    public string Title { get; set; } = "Account Details";

    public AccountDetailsProfileInfoModel? ProfileInfo { get; set; } 
    public AccountDetailsBasicInfoModel? BasicInfo { get; set; }
    public AccountDetailsAddressInfoModel? AddressInfo { get; set; } 

    ///Add file path upload later
}
