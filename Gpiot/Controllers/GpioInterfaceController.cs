using Microsoft.AspNetCore.Mvc;

namespace Gpiot.Controllers;

[ApiController]
[Route("[controller]")]
public class GpioInterfaceController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> GetAllPorts()
    {
        return [""];
    }
}
