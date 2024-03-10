namespace BikeRental.Api.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string message);
    }
}
