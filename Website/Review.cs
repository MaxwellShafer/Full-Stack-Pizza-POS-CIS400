using Newtonsoft.Json;

namespace Website
{
    /// <summary>
    /// static class for review page
    /// </summary>
    public class Review
    {
        /// <summary>
        /// static constructor
        /// </summary>
        static Review()
        {
            if (System.IO.File.Exists("reviews.json"))
            {
                string json = System.IO.File.ReadAllText("reviews.json");
                _reviews = JsonConvert.DeserializeObject<List<string>>(json);
                if (_reviews == null)
                {
                    _reviews = new List<string>();
                }
            }
        }

        /// <summary>
        /// list to hold reviews
        /// </summary>
        public static List<string> _reviews = new();


       

        /// <summary>
        /// a method to add a review
        /// </summary>
        /// <param name="review">the review string</param>
        public static void AddReview(string? review)
        {
            if (review != null)
            {
                review = review + "   " + DateTime.Now;
                _reviews.Insert(0,review);
               
                System.IO.File.WriteAllText("reviews.json", JsonConvert.SerializeObject(_reviews));
            }
        }
    }
}
