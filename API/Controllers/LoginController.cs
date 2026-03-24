using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUser/{login}/{password}")]
        public bool Get(string login, string password)
        {
            if (login == "admin" && password == "admin")
            {
                return true;
            }
            return false;
        }
    }
}
