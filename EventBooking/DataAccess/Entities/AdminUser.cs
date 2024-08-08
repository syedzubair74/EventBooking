using System.ComponentModel.DataAnnotations;

namespace EventBooking.DataAccess.Entities
{
    public class AdminUser
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
