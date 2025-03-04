﻿namespace FilmPortal.Core.Entities
{
    public class MovieReview : BaseEntity
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string ReviewText { get; set; }
    }

}
