namespace FilmPortal.Core.Entities
{
    public class MovieLike : BaseEntity
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }


}