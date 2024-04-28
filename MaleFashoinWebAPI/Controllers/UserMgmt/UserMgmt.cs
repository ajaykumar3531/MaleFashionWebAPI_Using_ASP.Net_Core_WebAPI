using MaleFashion_WebAPI.BAL.UserMgmt.Contracts;
using MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt;
using MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMaleFashoin_WebAPI.Controllers.UserMgmt
{
    [Route("m1/UserMgmt")]
    [ApiController]
    public class UserMgmt : ControllerBase
    {
        private readonly IUserMgmtService _user;
        public UserMgmt(IUserMgmtService user) { 
            _user = user;
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountRequest request)
        {
            CreateAccountResponse response = new CreateAccountResponse();
            try
            {
                response = await _user.CreateAccount(request);
                if(response != null && response.StatusCode == StatusCodes.Status200OK)
                {
                    return Ok(response);
                }else if(response != null && !string.IsNullOrEmpty(response.StatusMessage))
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }

            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (response != null)
                    response = null;
            }
        }

        [Route("LoginUser")]
        [HttpPost]
        public async Task<IActionResult> LoginAccount(CreateAccountRequest request)
        {
            LoginAccountResponse response = new LoginAccountResponse();
            try
            {
                response = await _user.LoginAccount(request);
                if (response != null && response.StatusCode == StatusCodes.Status200OK)
                {
                    return Ok(response);
                }
                else if (response != null && !string.IsNullOrEmpty(response.StatusMessage))
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (response != null)
                    response = null;
            }
        }
    }
}
