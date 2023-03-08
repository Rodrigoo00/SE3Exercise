using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Models;
using NetCoreWebApi.Services;

namespace NetCoreWebApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("list")]
        public dynamic listUser()
        {
            try
            {
                return _userService.GetAll();
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

        [HttpGet]
        [Route("one")]
        public dynamic listUser(Guid Id)
        {
            try
            {
                return _userService.GetUser(Id);
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

                return _userService.SaveUser(user);
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

        [HttpPatch]
        [Route("update")]
        public dynamic Update(User user)
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

                return _userService.SaveUser(user);
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

        [HttpDelete]
        [Route("delete")]
        public dynamic Delete(Guid Id)
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

                return _userService.DeleteUser(Id);
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
