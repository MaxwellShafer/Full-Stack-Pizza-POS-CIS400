using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    /// <summary>
    /// privacy model
    /// </summary>
    public class PrivacyModel : PageModel
    {
        /// <summary>
        /// Ilogger
        /// </summary>
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        
    }
}