
namespace EventBooking.DTO.Requests
{
    public class UpsertEventRequest
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? NumberOfAttendees { get; set; }
        public string? ThumbnailImage { get; set; }
        public string? MainImage { get; set; }
        public string? Category { get; set; }
        public string? EventDate { get; set; }
        public string? MaxAllowed { get; set; }
    }
}
