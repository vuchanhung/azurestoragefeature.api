namespace azurestoragefeature.api.Service
{
    public interface IAzureServiceBusService
    {
        Task SendMessageAsync(string message);

        Task SendMessageAsync<T>(T message);
    }
}
