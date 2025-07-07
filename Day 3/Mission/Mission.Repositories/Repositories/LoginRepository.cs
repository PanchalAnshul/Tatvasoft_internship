using Mission.Entities.context;
using Mission.Entities.Entities;
using Mission.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Mission.Repositories.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MissionDbContext _missionDbContext;
        private readonly ILogger<LoginRepository> _logger;

        public LoginRepository(MissionDbContext missionDbContext, ILogger<LoginRepository> logger)
        {
            _missionDbContext = missionDbContext;
            _logger = logger;
        }

        public User login(string EmailAddress, string Password)
        {
            _logger.LogInformation("Attempting login in repository for email: {Email}", EmailAddress);

            var user = _missionDbContext.Users
                .FirstOrDefault(x => x.EmailAddress == EmailAddress && x.Password == Password);

            if (user == null)
            {
                _logger.LogWarning("No matching user found for email: {Email}", EmailAddress);
                return null;
            }

            _logger.LogInformation("User found in repository for email: {Email}", EmailAddress);
            return user;
        }
    }
}
