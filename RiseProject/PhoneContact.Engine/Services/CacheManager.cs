using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PhoneContact.Engine.Abstract;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Engine.Services
{
    public class CacheManager : BusinessEngineBase, ICacheManagementService
    {
        //private IMemoryCache _cache;
        //private readonly ILogger<CacheManager> _logger;
        public CacheManager(IMemoryCache cache, ILogger<CacheManager> logger)
        {
            this._cache = cache;
            _logger = logger;
        }
        public Task<bool> Clear()
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                PropertyInfo prop = _cache.GetType().GetProperty("EntriesCollection", BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Public);
                object innerCache = prop.GetValue(_cache);
                MethodInfo clearMethod = innerCache.GetType().GetMethod("Clear", BindingFlags.Instance | BindingFlags.Public);
                clearMethod.Invoke(innerCache, null);
                _logger.LogInformation("All Keys Removed From Cache");
                return true;
            });
        }
    }
}
