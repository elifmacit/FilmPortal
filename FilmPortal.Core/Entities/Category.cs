namespace FilmPortal.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }
    }


}
