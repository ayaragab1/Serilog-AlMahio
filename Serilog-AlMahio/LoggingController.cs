using Microsoft.AspNetCore.Mvc;

namespace Serilog_AlMahio;

[ApiController]
[Route("[controller]")]

public class LoggingController : ControllerBase
{
 
        private readonly ILogger<LoggingController> _logger;
        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogDebug("This is a debug message");
            _logger.LogInformation("This is an info message");
            _logger.LogWarning("This is a warning message ");
            _logger.LogError(new Exception(), "This is an error message");
            return new[] { "Cool", "Weather" };
        }
}