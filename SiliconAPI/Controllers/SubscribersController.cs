using Microsoft.AspNetCore.Mvc;

namespace SiliconAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController : ControllerBase
{
    /// <summary>
    /// create a subscriber
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SubscribeAsync()
    {
        return Ok();
    }

    /// <summary>
    /// Delete a subscriber
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> UnsubscribeAsync()
    {
        return Ok();
    }
}
