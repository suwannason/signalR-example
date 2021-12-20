using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace signalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChartController : ControllerBase
    {
        private IHubContext<DataHub> _hub;

        public ChartController(IHubContext<DataHub> hub)
        {
            _hub = hub;
        }

        [HttpGet("send/graph1")]
        public IActionResult GetTest()
        {
            var result = _hub.Clients.All.SendAsync("chartStation1", 5);
            return Ok(new { Status = "Send To Graph 1 Completed" });
        }

        [HttpGet("send/graph2")]
        public IActionResult GetTest2()
        {
            var result = _hub.Clients.All.SendAsync("chartStatus2", 10);
            return Ok(new { Status = "Send To Graph 2 Completed" });
        }
    }
}