namespace FilmPortal.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<MovieReview> MovieReviews { get; set; }
        public ICollection<MovieLike> MovieLikes { get; set; }
    }

}
