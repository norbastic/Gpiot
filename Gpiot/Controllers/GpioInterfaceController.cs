using Gpiot.Models;
using Gpiot.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gpiot.Controllers;

[ApiController]
[Route("[controller]")]
public class GpioInterfaceController(IGpioHandler gpioHandler) : ControllerBase
{
    private readonly IGpioHandler _gpioHandler = gpioHandler;

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

    [HttpPost]
    public ActionResult SetPinStatus([FromBody] GpioPin gpioPin)
    {
        if (gpioPin == null || gpioPin.GpioPinId <= 0)
        {
            return BadRequest("Invalid pin id.");
        }

        try
        {
            var pinSetSuccessfully = _gpioHandler.SetPin(gpioPin);
            return pinSetSuccessfully ? StatusCode(StatusCodes.Status200OK) :
            StatusCode(StatusCodes.Status400BadRequest);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error while getting the status of gpio pin");
        }
    }
}
