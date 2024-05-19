using azurestoragefeature.api.Service;
using azurestoragefeature.api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace azurestoragefeature.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueStorageMessageController : ControllerBase
    {
        private readonly IAzureServiceBusService _azureServiceBusService;

        public QueueStorageMessageController(IAzureServiceBusService azureServiceBusService)
        {
            _azureServiceBusService = azureServiceBusService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(string message)
        {
            await _azureServiceBusService.SendMessageAsync(message);
            return new StatusCodeResult((int)HttpStatusCode.Created);
        }
        [HttpPost("withJsonBody")]
        public async Task<IActionResult> Post([FromBody] MessageRequest messageRequest)
        {
            await _azureServiceBusService.SendMessageAsync(messageRequest);
            return new StatusCodeResult((int)HttpStatusCode.Created);
        }
    }
}
