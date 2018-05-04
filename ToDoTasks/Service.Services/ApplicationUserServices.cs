using System.Linq;
using Persistence;
using Service.Interfaces;

namespace Service.Services
{
    public class ApplicationUserServices : IApplicationUserServices
    {
        private readonly ApplicationDbContext _databaseService;

        public ApplicationUserServices(ApplicationDbContext databaseService)
        {
            _databaseService = databaseService;
        }

        public string GetNameOfTheSpecifiedId(string id)
        {
            var check = _databaseService.Users.SingleOrDefault(user => user.Id == id.ToString());
            return check.Name;
        }

    }
}
