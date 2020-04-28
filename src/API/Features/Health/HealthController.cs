namespace API.Features.Health
{
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using System.Reflection;

    [ApiController]
    public class HealthController : ControllerBase 
    {
        [HttpGet("/api/health")]
        public IActionResult ApiHealth() 
            => Ok();

        [HttpGet("/api/version")]
        public IActionResult ApiVersion()
            => Ok(Assembly.GetExecutingAssembly().GetName().Version.ToString());
    }
}
