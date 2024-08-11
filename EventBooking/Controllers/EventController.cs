using EventBooking.DataAccess.Entities;
using EventBooking.DTO.Requests;
using EventBooking.DTO.Responses;
using EventBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpPost("GetEvents")]
        public async Task<IActionResult> GetEvents(GetEventsRequest request)
        {
            var response = await _eventRepository.GetEvents(request);

            return Ok(response);
        }
        [HttpPost("UpsertEvent")]
        public async Task<IActionResult> UpsertEvent(UpsertEventRequest request)
        {
            var response = await _eventRepository.UpsertEvent(request);

            return Ok(response);
        }
        [HttpPost("RegisterForEvent")]
        public async Task<IActionResult> RegisterForEvent(RegisterEventRequest request)
        {
            var response = await _eventRepository.RegisterForEvent(request);

            return Ok(response);
        }
    }
}
