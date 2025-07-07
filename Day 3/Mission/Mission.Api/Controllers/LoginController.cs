using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission.Services.IServices;

namespace Mission.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string EmailAddress, string Password)
        {
            _logger.LogInformation("Login attempt for email: {EmailAddress}", EmailAddress);

            var user = _loginService.login(EmailAddress, Password);
            if (user == null)
            {
                _logger.LogWarning("Login failed for email: {EmailAddress}", EmailAddress);
                return NotFound("Please check your email and password");
            }

            _logger.LogInformation("User logged in successfully: {EmailAddress}", EmailAddress);
            return Ok("Login successfully");
        }
    }
}
