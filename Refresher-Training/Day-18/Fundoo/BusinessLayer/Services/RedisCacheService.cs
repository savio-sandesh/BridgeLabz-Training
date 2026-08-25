using BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace BusinessLayer.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisCacheService(IConfiguration configuration)
        {
            var connectionString = configuration["Redis:ConnectionString"]
                ?? throw new InvalidOperationException("Redis ConnectionString is missing in appsettings.json.");

            _redis = ConnectionMultiplexer.Connect(connectionString);
            _database = _redis.GetDatabase();
        }

        public async Task SetTokenAsync(string token, TimeSpan expiry)
        {
            string key = $"blacklist:{token}";
            await _database.StringSetAsync(key, "revoked", expiry);
        }

        public async Task<bool> IsTokenBlacklistedAsync(string token)
        {
            string key = $"blacklist:{token}";
            return await _database.KeyExistsAsync(key);
        }
    }
}