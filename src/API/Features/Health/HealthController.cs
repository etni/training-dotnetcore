namespace API.Features.Health
{
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Reflection;

    [ApiController]
    [AllowAnonymous]
    public class HealthController : ControllerBase 
    {
        private readonly ILogger<HealthController> logger;

        public HealthController(ILogger<HealthController> logger) 
            => this.logger = logger;

        [HttpGet("/api/health")]
        public IActionResult ApiHealth() 
            => Ok();

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("/api/version")]
        public IActionResult ApiVersion()
            => Ok(Assembly.GetExecutingAssembly().GetName().Version.ToString());

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("/api/log")]
        public IActionResult ApiLog()
        {

            logger.LogTrace(9000, "Trace Message from Health Controller");
            logger.LogDebug(9001, "Debug Message from Health Controller");
            logger.LogInformation(9002, "Information From Health Controller");
            logger.LogWarning(9003, "Warning from Health Controller");
            logger.LogError(9004, "Error from Health Controller");

            return NoContent();
        }
    }
}
