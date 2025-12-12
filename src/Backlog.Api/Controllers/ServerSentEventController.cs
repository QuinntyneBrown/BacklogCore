using Backlog.SharedKernel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers;
[ApiController]
[Route("api/events")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class ServerSentEventController : Controller
{
    private readonly INotificationService _notificationService;
    public ServerSentEventController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet(Name = "GetEvents")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<dynamic>> Get(CancellationToken cancellationToken)
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

        using (cancellationToken.Register(() => tcs.TrySetCanceled()))
        {
        }

        await tcs.Task;

        return null;

    }
}