using Microsoft.AspNetCore.Mvc;
using Portfolio_back.Models;

namespace Portfolio_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        private List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "John", Password = "1234" },
            new User { Id = 2, Name = "Baldor", Password = "test" },
            new User { Id = 3, Name = "Sam", Password = "Sam" }
        };

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<User> Auth(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var isExists = _users.Exists(_ => _.Name == user.Name && _.Password == user.Password);
            var token = new { token = "test123" };
            if (isExists)
            {
                return new ObjectResult(token);
            }

            return NotFound();
        }
    }
}
