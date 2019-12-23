using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using server.Hubs;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        IHubContext<MessagesHub> _hubContext;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHubContext<MessagesHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            _hubContext.Clients.All.SendAsync("itemReceived", value);
            return Ok();
        }
    }
}
