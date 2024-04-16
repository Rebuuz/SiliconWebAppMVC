using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconMVC.ViewModels;
using System.Net;
using System.Text;

namespace SiliconMVC.Controllers;

public class HomeController : Controller
{
    /// <summary>
    /// genererar min startsida (index)
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();

            var json = JsonConvert.SerializeObject(model);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync($"http://localhost:5295/api/Subscribers?email={model.Email}", content);

            if (response.IsSuccessStatusCode)
            {
                ViewData["You Are Subscribed"] = true;
            }
        }

        return RedirectToAction("Index", "Home", "newsletter");
    }
}
