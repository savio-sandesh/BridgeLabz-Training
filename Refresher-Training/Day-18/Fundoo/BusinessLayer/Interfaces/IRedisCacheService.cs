namespace BusinessLayer.Interfaces
{
    public interface IRedisCacheService
    {
        Task SetTokenAsync(string token, TimeSpan expiry);
        Task<bool> IsTokenBlacklistedAsync(string token);
    }
}