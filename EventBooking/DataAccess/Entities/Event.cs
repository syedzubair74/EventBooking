using System.ComponentModel.DataAnnotations;

namespace EventBooking.DataAccess.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? NumberOfAttendees { get; set; }
        public string? ThumbnailImage { get; set; }
        public string? MainImage { get; set; }
        public string? Category { get; set; }
        public DateTime EventDate { get; set; }
    }
}
