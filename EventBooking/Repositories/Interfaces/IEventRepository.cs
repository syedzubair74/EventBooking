using EventBooking.DataAccess.Entities;
using EventBooking.DTO.Requests;
using EventBooking.DTO.Responses;

namespace EventBooking.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetEvents(GetEventsRequest request);
        Task<ApiResponse<bool>> UpsertEvent(UpsertEventRequest e);
        Task<ApiResponse<bool>> RegisterForEvent(RegisterEventRequest request);
        Task<ApiResponse<bool>> DeleteEvent(DeleteEventRequest request);
    }
}
