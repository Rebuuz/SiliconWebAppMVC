using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.ViewModels;

public class SubscribeViewModel
{
    [Display(Name = "Email Address", Prompt = "Enter your email address")]
    [EmailAddress]
    [Required(ErrorMessage = "Email address is required. Must be of format xx@xx.xx.")]
    [RegularExpression("^[^@\\s]+@[^\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Email address is required. Must be of format xx@xx.xx.")]
    public string Email { get; set; } = null!;


    public bool DailyNewsletter { get; set; }
    public bool EventUpdates { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool WeekInReview { get; set; }
    public bool Podcasts { get; set; }
}
