using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using InMemoryCachingWithDecorator.Entities;

namespace InMemoryCachingWithDecorator.Services
{
    public class CachedVehicleService : IVehicleService
    {
        private const string VehicleListCacheKey = "VehicleList";
        private readonly IMemoryCache _memoryCache;
        private readonly IVehicleService _vehicleService;

        public CachedVehicleService(IMemoryCache memoryCache, IVehicleService vehicleService)
        {
            _memoryCache = memoryCache;
            _vehicleService = vehicleService;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            if (_memoryCache.TryGetValue(VehicleListCacheKey, out IEnumerable<Vehicle> query))
            {
                return query;
            }

            query = await _vehicleService.GetAllAsync();

            _memoryCache.Set(VehicleListCacheKey, query);

            return query;
        }
    }
}
