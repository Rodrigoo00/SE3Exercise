using NetCoreWebApi.Models;
using NetCoreWebApi.Repositories;

namespace NetCoreWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<dynamic> DeleteUser(Guid userID)
        {
            return await _userRepository.Delete(userID);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<dynamic> GetUser(Guid userID)
        {
            return await _userRepository.GetOne(userID);
        }

        public async Task<dynamic> SaveUser(User user)
        {
            if (user.DateOfBirth > DateTime.Now.AddYears(-18))
            {
                return new ErrorCode
                {
                    Succes = false,
                    Message = "User must be older than 18 years old"
                };
            }

            var users = await this._userRepository.GetAll();

            if (users.Where(x => x.Email == user.Email).Any())
            {
                return new ErrorCode
                {
                    Succes = false,
                    Message = "Email already exists"
                };
            }

            return await _userRepository.Save(user);
        }
    }
}
