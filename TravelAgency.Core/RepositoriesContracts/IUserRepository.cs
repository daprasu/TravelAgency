using TravelAgency.Core.Entities;

namespace TravelAgency.Core.RepositoriesContracts
{
    public interface IUserRepository
    {
        User GetUserByCode(int? userId);
    }
}
