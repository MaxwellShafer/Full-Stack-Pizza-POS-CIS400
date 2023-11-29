using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Website.Pages
{
    /// <summary>
    /// model for review Page
    /// </summary>
    public class ReviewModel : PageModel
    {
        
        /// <summary>
        /// on get method for the review page
        /// </summary>
        public void OnGet()
        {
           

        }

        /// <summary>
        /// a property to hold the review
        /// </summary>
        public string? SubmitReview { get; set; }

        /// <summary>
        /// public list of all reviews
        /// </summary>
        public IEnumerable<string> Reviews => Review._reviews;


        /// <summary>
        /// post method for Review page
        /// </summary>
        public void OnPost()
        {
            SubmitReview = Request.Form["SubmitReview"];
            Review.AddReview(SubmitReview);
            SubmitReview = null;
        }


    }
}
