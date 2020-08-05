using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Blog.API.Controllers.Base
{
    /// <summary>
    /// Base v1.0 controller
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [Route("v1/[controller]")]
    [ApiController]
    public abstract class BaseV10Controller : ControllerBase
    {
        /// <summary>
        /// Log information
        /// </summary>
        /// <typeparam name="LoggerType">LoggerType</typeparam>
        /// <param name="message">log message</param>
        /// <param name="args">log args</param>
        protected virtual void LogInformation<LoggerType>(string message, params object[] args)
        {
            var log = HttpContext.RequestServices.GetService<ILogger<LoggerType>>();
            if (args.Length > 0)
            {
                log.LogInformation(message, args);
            }
            else
            {
                log.LogInformation(message);
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <typeparam name="LoggerType">LoggerType</typeparam>
        /// <param name="exception">Exception</param>
        /// <param name="message">log message</param>
        /// <param name="args">log args</param>
        protected virtual void LogError<LoggerType>(Exception exception, string message = null, params object[] args)
        {
            var log = HttpContext.RequestServices.GetService<ILogger<LoggerType>>();
            if (args.Length > 0)
            {
                log.LogError(exception, message ?? exception.Message, args);
            }
            else
            {
                log.LogError(exception, message ?? exception.Message);
            }
        }

    }
}