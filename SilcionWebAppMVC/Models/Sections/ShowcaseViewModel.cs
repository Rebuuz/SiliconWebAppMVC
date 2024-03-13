using SiliconMVC.Models.Components;

namespace SiliconMVC.Models.Sections;

/// <summary>
/// all parts of my showcase
/// </summary>
public class ShowcaseViewModel
{
    public string? Id { get; set; }
    public ImageViewModel ShowcaseImage { get; set; } = null!;
    public string? Title { get; set; }
    public string? Text {  get; set; }
    public LinkViewModel Link { get; set; } = new LinkViewModel();
    public string? BrandsText { get; set; }
    
}
