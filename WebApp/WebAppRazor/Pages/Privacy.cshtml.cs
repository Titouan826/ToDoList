using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace WebAppRazor.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = "Under construction since " + dateTime + "\n\nOpen source project by tcorino.";
        }
    }

}
