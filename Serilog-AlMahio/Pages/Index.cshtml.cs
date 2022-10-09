using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Serilog_AlMahio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogWarning("This is a log message. This is an object: {User}", new { name = "John Doe" });
            _logger.LogError("This is a log message. This is an object: {User}", new { name = "John Doe" });
        }
    }
}