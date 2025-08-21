using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ProductApi.Application.Services.RedisCacheServices;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly StackExchange.Redis.IDatabase _database;
        private readonly ILogger<RedisCacheService> _logger;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer, ILogger<RedisCacheService> logger)
        {
            _database = connectionMultiplexer.GetDatabase();
            _logger = logger;
        }

        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            await _database.StringSetAsync(key, value, expiry);
            _logger.LogInformation("Redis SET - Key: {Key}, Expiry: {Expiry}", key, expiry);
        }

        public async Task<string?> GetAsync(string key)
        {
            var value = await _database.StringGetAsync(key);

            if (value.HasValue)
            {
                _logger.LogInformation("Redis HIT - Key: {Key}", key);
            }
            else
            {
                _logger.LogInformation("Redis MISS - Key: {Key}", key);
            }

            return value;
        }

        public async Task RemoveAsync(string key)
        {
            var deleted = await _database.KeyDeleteAsync(key);
            _logger.LogInformation("Redis DELETE - Key: {Key}, Deleted: {Deleted}", key, deleted);
        }
    }
}
