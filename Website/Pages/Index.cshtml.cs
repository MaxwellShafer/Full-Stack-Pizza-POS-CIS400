using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    /// <summary>
    /// index model
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// logger
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// on get
        /// </summary>
        public void OnGet()
        {

        }
    }
}