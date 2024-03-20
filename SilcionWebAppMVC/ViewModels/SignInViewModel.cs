using SiliconMVC.Models;

namespace SiliconMVC.ViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";

    public SignInFormModel Form { get; set; } = new SignInFormModel();

    public string? ErrorMsg { get; set; }
}
