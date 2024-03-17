using SiliconMVC.Models;

namespace SiliconMVC.ViewModels;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign Up";
    public SignUpFormModel Form { get; set; } = new SignUpFormModel();

    
}
