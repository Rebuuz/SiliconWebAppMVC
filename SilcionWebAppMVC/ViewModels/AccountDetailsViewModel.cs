using Infrastructure.Entities;

namespace SiliconMVC.ViewModels;

public class AccountDetailsViewModel
{
    public UserEntity User { get; set; } = null!;

    public string Title { get; set; } = "Account Details";
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel();
    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();

    ///Add file path upload later
}
