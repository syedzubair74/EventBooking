namespace EventBooking.DataAccess.Entities
{
    public class UserEvent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
