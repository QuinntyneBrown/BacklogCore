using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : Controller
    {
        private readonly INotificationService _notificationService;
        public EventsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task Get(CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            var response = Response;
            response.Headers.Add("Content-Type", "text/event-stream");

            _notificationService.Subscribe(async e =>
            {
                var @event = JsonConvert.SerializeObject(e);

                await response
                .WriteAsync($"data: {@event}\r\r");

                response.Body.Flush();

            });

            await tcs.Task;

        }

    }
}