using FilmPortal.Core.Enums;

namespace FilmPortal.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DataStatus Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
