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

        /// <summary>
        /// index model
        /// </summary>
        /// <param name="logger">logger</param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// holds the search terms
        /// </summary>
        public string? SearchTerms { get; set; } = "";

        /// <summary>
        /// hold the min price filter
        /// </summary>
        public decimal? MinPrice { get; set; } = 0;

        /// <summary>
        /// holds max price filter
        /// </summary>
        public decimal? MaxPrice { get; set; } = 0;

        /// <summary>
        /// hold the min cal filter
        /// </summary>
        public int? MinCalories { get; set; } = 0;

        /// <summary>
        /// holds max cal filter
        /// </summary>
        public int? MaxCalories { get; set; }


        /// <summary>
        /// on get
        /// </summary>
        public void OnGet()
        {
            SearchTerms = Request.Query["SearchTerms"];
            try
            {
                MinPrice = Convert.ToDecimal(Request.Query["MinPrice"]);
            }
            catch
            {
                MinPrice = 0;
            }
            try
            {
                MaxPrice = Convert.ToDecimal(Request.Query["MaxPrice"]);

            }
            catch
            {
                MaxPrice = 0;
            }
            try
            {
                MinCalories = Convert.ToInt32(Request.Query["MinCalories"]);

            }
            catch
            {
                MinCalories = 0;
            }
            try
            {
                MaxCalories = Convert.ToInt32(Request.Query["MaxCalories"]);

            }
            catch
            {
                MaxCalories = 0;
            }





        }
    }
}