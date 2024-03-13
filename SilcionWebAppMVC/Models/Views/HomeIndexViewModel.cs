using SiliconMVC.Models.Sections;

namespace SiliconMVC.Models.Views;

/// <summary>
/// Everything that is on the home page
/// </summary>
public class HomeIndexViewModel
{
    public string Title { get; set; } = "";
    public ShowcaseViewModel Showcase { get; set; } = null!;

}
