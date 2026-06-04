namespace FireBaseApi
{
    public interface INotificationClient
    {
        Task RecibeNotification(string message);
    }
}
