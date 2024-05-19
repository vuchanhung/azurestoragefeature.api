using Azure.Storage.Queues;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace azurestoragefeature.api.Service
{
    public class AzureServiceBusService:IAzureServiceBusService
    {
        private readonly QueueClient _queueClient;
        public AzureServiceBusService(QueueServiceClient queueServiceClient)
        {
            _queueClient = queueServiceClient.GetQueueClient("mynewqueuestorage");
        }
        public async Task SendMessageAsync(string message)
        {
            await _queueClient.CreateIfNotExistsAsync();
            await _queueClient.SendMessageAsync(message);
        }

        public async Task SendMessageAsync<T>(T message)
        {
            var serializerConfig = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            var msg = JsonSerializer.Serialize(message,serializerConfig);
            await _queueClient.CreateIfNotExistsAsync();
            await _queueClient.SendMessageAsync(msg);
        }
    }
}
