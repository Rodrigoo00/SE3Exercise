using NetCoreWebApi.Models;

namespace NetCoreWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _listUsers;

        public UserRepository()
        {
            _listUsers = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jhon",
                    LastName = "Lemon",
                    Email = "JhonLemon@gmail.com",
                    DateOfBirth = new DateTime(1980, 3, 25)
                },
                new User
                {
                     Id = Guid.NewGuid(),
                    FirstName = "Marcus",
                    LastName = "Casper",
                    Email = "MarcusCasper@gmail.com",
                    DateOfBirth = new DateTime(1989, 8, 12)
                }
            };
        }

        public async Task<dynamic> Delete(Guid UserID)
        {
            var user = _listUsers.Where(x => x.Id == UserID).FirstOrDefault();

            if (user == null)
            {
                return new ErrorCode
                {
                    Succes = false,
                    Message = "Incorrect Id"
                };
            }

            _listUsers.Remove(user);
            return new ErrorCode
            {
                Succes = true,
                Message = $"User {UserID} removed."
            };
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _listUsers;
        }

        public async Task<dynamic> GetOne(Guid UserID)
        {
            var user = _listUsers.Where(x => x.Id == UserID).FirstOrDefault();

            if (user == null)
            {
                return new ErrorCode
                {
                    Succes = false,
                    Message = "Incorrect Id"
                };
            }

            return user;
        }

        public async Task<dynamic> Save(User User)
        {
            if (User.Id == Guid.Empty)
            {
                User.Id = Guid.NewGuid();

                _listUsers.Add(User);
            }
            else
            {
                var dbUser = _listUsers.Where(x => x.Id == User.Id).FirstOrDefault();

                if (dbUser == null)
                {
                    return new ErrorCode
                    {
                        Succes = false,
                        Message = $"User {User.Id} doesn't exists."
                    };
                }

                _listUsers.Remove(dbUser);
                _listUsers.Add(User);
            }

            return User;
        }
    }
}
