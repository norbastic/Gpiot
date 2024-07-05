using Gpiot.Models;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using System.Net;

namespace Gpiot.Controllers;

[ApiController]
[Route("[controller]")]
public class SchedulerController(ISchedulerFactory schedulerFactory) : ControllerBase
{
    private readonly ISchedulerFactory _schedulerFactory = schedulerFactory;

    [HttpGet]
    public async Task<ActionResult> GetJob()
    {
        var scheduler = await _schedulerFactory.GetScheduler();

        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPost]
    public async Task<ActionResult> ScheduleJob([FromBody] GpioEventSchedule schedule)
    {
        var scheduler = await _schedulerFactory.GetScheduler();
        var job = JobBuilder.Create().WithIdentity(schedule.ScheduleName);
        var trigger = TriggerBuilder.Create()
            .WithIdentity($"{schedule.ScheduleName}-trigger")
            .WithSimpleSchedule(x => x.)
        return StatusCode(StatusCodes.Status200OK);
    }
}
