namespace SiliconMVC.ViewModels;

public class AccountDetailsProfileInfoModel
{
    ///Profile Image
    public string? ProfileImage { get; set; }

    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Lastname
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Email address
    /// </summary>
    public string EmailAddress { get; set; } = null!;
}
