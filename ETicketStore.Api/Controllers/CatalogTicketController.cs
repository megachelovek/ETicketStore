using Microsoft.AspNetCore.Mvc;

namespace ETicketStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogTicketController : ControllerBase
    {
        //private readonly ILogger<CatalogTicketController> _logger;
        private readonly ETicketRepository _eTicketRepository;
        private readonly EventRepository _eventRepository;

        public CatalogTicketController(ETicketRepository eTicketRepository, EventRepository eventRepository)
        {
            _eTicketRepository = eTicketRepository;
            _eventRepository = eventRepository;
        }

        [HttpGet]
        [Route("GetCatalogTickets")]
        public async Task<IEnumerable<Ticket>> GetCatalogTickets()
        {
            return await ticketService.GetAllAsync();
        }

        [HttpGet]
        [Route("GetEventShedule")]
        public async Task<IEnumerable<EventShedule>> GetEventShedule()
        {
            return await _eventRepository.GetEventShedule();
        }

        [HttpGet]
        [Route("BuyTicket")]
        public async Task BuyTicket(string customerId, string ticketId)
        {
            await _eTicketRepository.BuyTicket(customerId, ticketId);
        }

    }
}
