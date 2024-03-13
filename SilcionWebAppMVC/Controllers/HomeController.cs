using Microsoft.AspNetCore.Mvc;
using SiliconMVC.Models.Sections;
using SiliconMVC.Models.Views;

namespace SiliconMVC.Controllers;

public class HomeController : Controller
{
    /// <summary>
    /// genererar min startsida (index)
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {

        var viewModel = new HomeIndexViewModel
        {
            Title = "Home",
            Showcase = new ShowcaseViewModel
            {
                Id = "showcase-id",
                ShowcaseImage = new()
                {
                    ImageUrl = "images/showcase-taskmaster.svg",
                    AltText = "Image of the website"
                },
                Title = "Task Management Assistant You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                Link = new()
                {
                    ActionName = "Index",
                    ControllerName = "Downloads",
                    Text = "Get started for free"
                },
                BrandsText = "Largest companies use our tool to work efficiently",
            }

        };

        ViewData["Title"] = viewModel.Title;

        return View(viewModel);
    }
}
