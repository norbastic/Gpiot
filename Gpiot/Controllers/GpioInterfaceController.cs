using Gpiot.Models;
using Gpiot.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gpiot.Controllers;

[ApiController]
[Route("[controller]")]
public class GpioInterfaceController : ControllerBase
{
    private readonly IGpioHandler _gpioHandler;

    public GpioInterfaceController(IGpioHandler gpioHandler)
    {
        _gpioHandler = gpioHandler;
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<GpioPin> GetAllPorts(int id)
    {
        try
        {
            return _gpioHandler.GetStatusOfPin(id);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error while getting the status of gpio pin");
        }
    }
}
