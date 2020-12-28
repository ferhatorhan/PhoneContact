using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PhoneContact.Engine.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Engine.Abstract
{
    public class BusinessEngineBase
    {
        protected IMemoryCache _cache;
        protected ILogger _logger;
        protected IMapper Mapper;
        public BusinessEngineBase()
        {
            Mapper = new MapperConfiguration(cfg =>
              {
                  MapperConfigurations.Map(cfg);
              }).CreateMapper();
        }
        protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func)
        {
            try
            {

                var result = func.Invoke();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, func.Method);
                // _logger.Error(ex.Message, ex);
                throw;
            }
        }
        protected void ExecuteWithExceptionHandledOperation(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, action.Method);
                // _logger.Error(ex.Message, ex);
                throw;
            }
        }

    }
}
