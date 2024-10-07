namespace CustomerServiceApp.ViewModels
{
    public class PostReviewViewModel
    {
        public int ReviewID { get; set; }

        public int OverallRating { get; set; }

        public required string Title { get; set; }

        public required string Comments { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
