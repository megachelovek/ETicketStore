using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ETicketStore.Domain.Models;
using ETicketStore.Domain.Repository;

namespace ETicketStore.Api.Admin.Controllers
{
    [Authorize]
    [ApiController]
    [Route("admin/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly EventRepository _eventRepository;

        public EventController(ILogger<EventController> logger, EventRepository eventRepository, ApplicationContext context)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        [HttpPost()]
        [Route("AddEvent")]
        [Authorize]
        public async Task AddEvent(EventShedule eventShedule)
        {
            await _eventRepository.AddEventShedule(eventShedule);
        }
    }
}
