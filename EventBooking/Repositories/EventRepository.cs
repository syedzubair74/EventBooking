using EventBooking.DataAccess;
using EventBooking.DataAccess.Entities;
using EventBooking.DTO.Requests;
using EventBooking.DTO.Responses;
using EventBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventBookingDbContext _dbContext;
        public EventRepository(EventBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Event>> GetEvents(GetEventsRequest request)
        {
            var events = _dbContext.Event.AsQueryable();

            if (string.IsNullOrEmpty(request.Name))
            {
                events = events.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
            }
            if (string.IsNullOrEmpty(request.Location))
            {
                events = events.Where(x => x.Location.ToLower().Contains(request.Location.ToLower()));
            }
            if (string.IsNullOrEmpty(request.Category))
            {
                events = events.Where(x => x.Category.ToLower().Contains(request.Category.ToLower()));
            }

            var res = await events.AsNoTracking().ToListAsync();
            return res;
        }
        public async Task<ApiResponse<bool>> UpsertEvent(UpsertEventRequest e)
        {
            var response = new ApiResponse<bool>();
            try
            {


                if (e.Id != null)
                {
                    var query = await _dbContext.Event.FirstOrDefaultAsync(x => x.Id == e.Id);
                    if (query != null)
                    {
                        if (!string.IsNullOrEmpty(e.Name))
                        {
                            query.Name = e.Name;
                        }

                        if (!string.IsNullOrEmpty(e.Description))
                        {
                            query.Description = e.Description;
                        }

                        if (!string.IsNullOrEmpty(e.Location))
                        {
                            query.Location = e.Location;
                        }

                        if (!string.IsNullOrEmpty(e.Category))
                        {
                            query.Category = e.Category;
                        }

                        if (e.NumberOfAttendees.HasValue)
                        {
                            query.NumberOfAttendees = e.NumberOfAttendees.Value;
                        }

                        if (!string.IsNullOrEmpty(e.ThumbnailImage))
                        {
                            query.ThumbnailImage = e.ThumbnailImage;
                        }

                        if (!string.IsNullOrEmpty(e.MainImage))
                        {
                            query.MainImage = e.MainImage;
                        }

                        if (!string.IsNullOrEmpty(e.EventDate))
                        {
                            query.EventDate = DateTime.Parse(e.EventDate);
                        }
                        if (!string.IsNullOrEmpty(e.MaxAllowed))
                        {
                            query.MaxAllowed = int.Parse(e.MaxAllowed);
                        }

                        _dbContext.Event.Update(query);

                    }
                }
                else
                {
                    var ev = new Event();

                    if (!string.IsNullOrEmpty(e.Name))
                    {
                        ev.Name = e.Name;
                    }

                    if (!string.IsNullOrEmpty(e.Description))
                    {
                        ev.Description = e.Description;
                    }

                    if (!string.IsNullOrEmpty(e.Location))
                    {
                        ev.Location = e.Location;
                    }

                    if (!string.IsNullOrEmpty(e.Category))
                    {
                        ev.Category = e.Category;
                    }

                    if (e.NumberOfAttendees.HasValue)
                    {
                        ev.NumberOfAttendees = e.NumberOfAttendees.Value;
                    }

                    if (!string.IsNullOrEmpty(e.ThumbnailImage))
                    {
                        ev.ThumbnailImage = e.ThumbnailImage;
                    }

                    if (!string.IsNullOrEmpty(e.MainImage))
                    {
                        ev.MainImage = e.MainImage;
                    }

                    if (!string.IsNullOrEmpty(e.EventDate))
                    {
                        ev.EventDate = DateTime.Parse(e.EventDate);
                    }
                    if (!string.IsNullOrEmpty(e.MaxAllowed))
                    {
                        ev.MaxAllowed = int.Parse(e.MaxAllowed);
                    }

                    await _dbContext.Event.AddAsync(ev);
                }
                await _dbContext.SaveChangesAsync();
                response.IsRequestSuccesfull = true;
                response.SuccessResponse = true;

            }
            catch (Exception ex)
            {
                response.IsRequestSuccesfull = false;
                response.Error = ex.Message;
            }
            return response;
        }
        public async Task<ApiResponse<bool>> RegisterForEvent(RegisterEventRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var evnt = await _dbContext.Event.FirstOrDefaultAsync(x => x.Id == request.EventId);
                if (evnt != null)
                {
                    if (evnt.NumberOfAttendees == evnt.MaxAllowed)
                    {
                        throw new Exception("Attendance full");
                    }


                    var userEvent = new UserEvent
                    {
                        UserId = request.UserId,
                        EventId = request.EventId,
                        TimeStamp = DateTime.Now,
                    };
                    await _dbContext.UserEvent.AddAsync(userEvent);

                    evnt.NumberOfAttendees += 1;
                    _dbContext.Event.Update(evnt);

                    await _dbContext.SaveChangesAsync();
                    response.IsRequestSuccesfull = true;
                    response.SuccessResponse = true;
                }
                else
                {
                    throw new Exception("Event does not exist!");
                }
            }
            catch (Exception ex)
            {
                response.IsRequestSuccesfull = false;
                response.Error = ex.Message;
            }
            return response;
        }
        public async Task<ApiResponse<bool>> DeleteEvent(DeleteEventRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                if (request.Id == null)
                {
                    throw new ArgumentException(nameof(request.Id));
                }

                var evnt = await _dbContext.Event.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (evnt == null)
                {
                    throw new Exception("Data not found");
                }

                _dbContext.Event.Remove(evnt);
                await _dbContext.SaveChangesAsync();
                response.IsRequestSuccesfull = true;
                response.SuccessResponse = true;
            }
            catch (Exception ex)
            {
                response.IsRequestSuccesfull = false;
                response.Error = ex.Message;
            }
            return response;
        }
    }
}

