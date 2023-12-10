using System.Linq;
using TravelAgency.Core.Entities;
using TravelAgency.Core.RepositoriesContracts;
using TravelAngecy.Infraestructure.Data;

namespace TravelAgency.Infraestructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        #region Fields
        protected readonly AgenciaViajesSmartContext _context;
        #endregion

        #region Builders

        public UserRepository(AgenciaViajesSmartContext context)
        {
            _context = context;
        }
        #endregion
        public User GetUserByCode(int? userId)
        {
           var user = _context.User.FirstOrDefault(x => x.Id.Equals(userId));
           return user;
            
        }
    }
}
