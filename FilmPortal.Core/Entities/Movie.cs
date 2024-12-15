using System.IO;

namespace FilmPortal.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double ImdbRating { get; set; }
        public string Picture { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }
        public ICollection<MovieReview> MovieReviews { get; set; }
        public ICollection<MovieLike> MovieLikes { get; set; }
    }
}
