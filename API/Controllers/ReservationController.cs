using API.DAO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {

        private readonly ILogger<ReservationController> _logger;

        public ReservationController(ILogger<ReservationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetReservation")]
        public List<Reservation> Get(int idClient)
        {
            return ReservationDAO.getReservations(idClient);
        }
    }
}
