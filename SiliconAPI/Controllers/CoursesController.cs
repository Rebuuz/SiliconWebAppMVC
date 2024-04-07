using Microsoft.AspNetCore.Mvc;

namespace SiliconAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{

    ///Get all courses
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok();
    }

}
