using NetCoreWebApi.Models;

namespace NetCoreWebApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<dynamic> GetUser(Guid userID);
        Task<dynamic> SaveUser(User user);
        Task<dynamic> DeleteUser(Guid userID);
    }
}
