using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Models;

namespace NetCoreWebApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly List<User>  _listUsers;

        public UserController() 
        {
            _listUsers = new List<User>
            {
                new User
                {
                    FirstName = "Jhon",
                    LastName = "Lemon",
                    Email = "JhonLemon@gmail.com",
                    DateOfBirth = new DateTime(1980, 3, 25)
                },
                new User
                {
                    FirstName = "Marcus",
                    LastName = "Casper",
                    Email = "MarcusCasper@gmail.com",
                    DateOfBirth = new DateTime(1989, 8, 12)
                }
            };
        }

        [HttpGet]
        [Route("list")]
        public dynamic listUser()
        {
            try
            {
                return _listUsers;
            }
            catch (Exception ex)
            {
                return new ErrorCode
                {
                    Succes = false,
                    Message = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("save")]
        public dynamic saveUser(User user)
        {
            try
            {
                var token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault();

                if (token.Value != "Token1234&")
                {
                    return new ErrorCode
                    {
                        Succes = false,
                        Message = "Unauthorized"
                    };
                }

                if (user.DateOfBirth > DateTime.Now.AddYears(-18))
                {
                    return new ErrorCode
                    {
                        Succes = false,
                        Message = "User must be older than 18 years old"
                    };
                }

                if (_listUsers.Any(x => x.Email == user.Email))
                {
                    return new ErrorCode
                    {
                        Succes = false,
                        Message = "Email already exists"
                    };
                }

                return new ErrorCode
                {
                    Succes = true,
                    Message = "User registered",
                    Result = user
                };
            }
            catch (Exception ex)
            {
                return new ErrorCode
                {
                    Succes = false,
                    Message = ex.Message
                };
            }
            
        }
    }
}
