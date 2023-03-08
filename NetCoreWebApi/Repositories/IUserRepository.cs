using NetCoreWebApi.Models;

namespace NetCoreWebApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<dynamic> GetOne(Guid UserID);
        Task<dynamic> Save(User User);
        Task<dynamic> Delete(Guid UserID);
    }
}
