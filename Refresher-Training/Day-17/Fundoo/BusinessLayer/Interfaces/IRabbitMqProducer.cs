namespace BusinessLayer.Interfaces
{
    public interface IRabbitMqProducer
    {
        Task SendMessageAsync<T>(T message, string queueName);
    }
}