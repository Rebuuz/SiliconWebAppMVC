
using Infrastructure.Models;

namespace SiliconMVC.ViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";

    public SignInModel Form { get; set; } = new SignInModel();

    public string? ErrorMsg { get; set; }
}
