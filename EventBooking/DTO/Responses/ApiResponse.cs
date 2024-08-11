namespace EventBooking.DTO.Responses
{
    public class ApiResponse<T>
    {
        public bool? IsRequestSuccesfull { get; set; }
        public T SuccessResponse{get;set;}
        public string? Error { get; set; }
    }
}
