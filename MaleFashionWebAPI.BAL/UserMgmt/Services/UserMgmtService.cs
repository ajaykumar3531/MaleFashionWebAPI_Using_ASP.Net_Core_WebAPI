using MaleFashion_WebAPI.BAL.Shared.Auth;
using MaleFashion_WebAPI.BAL.UserMgmt.Contracts;
using MaleFashoin_WebAPI.DAL.Generic_Repos;
using MaleFashoin_WebAPI.DAL.MaleFashionDB;
using MaleFashoin_WebAPI.Domain.Common;
using MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt;
using MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt.Response;
using MaleFashoin_WebAPI.Domain.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion_WebAPI.BAL.UserMgmt.Services
{
    public class UserMgmtService : IUserMgmtService
    {
        private readonly IRepository<MaleFashionDbContext, User> _user;
        private readonly ITokenManager _tokenManager;
        public UserMgmtService(IRepository<MaleFashionDbContext, User> user,ITokenManager tokenManager)
        {
            _user = user;
            _tokenManager = tokenManager;
        }

        public async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request)
        {
            CreateAccountResponse response = new CreateAccountResponse();
            User addUser = new User();
            if (request == null)
            {
                response.StatusMessage = Constants.MSG_REQ_NULL;
                response.StatusCode = StatusCodes.Status400BadRequest;
            }
            try
            {
                var userData = (await _user.GetAll(x => x.UserName == request.UserName)).FirstOrDefault();

                Byte[] UserID = new PFAID().UID;

                String PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                if (userData == null)
                {
                    addUser = new User();
                    addUser.UserName = request.UserName;
                    addUser.Password = PasswordHash;
                    addUser.Id = UserID;
                    addUser.PhoneNumber = request.PhoneNumber;
                    _user.Add(addUser);

                    if (await _user.SaveChangesAsync() > 0)
                    {
                        response = new CreateAccountResponse()
                        {
                            Id = new PFAID(addUser.Id).ToString(),
                            UserName = addUser.UserName,
                            PhoneNumber = addUser.PhoneNumber,
                            StatusCode = StatusCodes.Status200OK,
                            StatusMessage = Constants.MSG_USER_ADD
                        };
                    }
                }
                else
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.StatusMessage = Constants.MSG_USER_FAIL;
                }

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (response != null)
                    response = null;
                addUser = null;
            }
        }

        public async Task<LoginAccountResponse> LoginAccount(CreateAccountRequest request)
        {
            LoginAccountResponse response = new LoginAccountResponse();

            if (request == null)
            {
                response.StatusMessage = Constants.MSG_REQ_NULL;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }

            try
            {

                var userData = (await _user.GetAll(x => x.UserName == request.UserName)).FirstOrDefault();
                if (userData != null)
                {
                    bool IsPassword = BCrypt.Net.BCrypt.Verify(request.Password, userData.Password);
                    if (IsPassword)
                    {
                        string token = await _tokenManager.GenerateTokenAsync(request, new PFAID(userData.Id).ToString());
                        response = new LoginAccountResponse()
                        {
                            UserName = userData.UserName,
                            Id = new PFAID(userData.Id).ToString(),
                            PhoneNumber = userData.PhoneNumber,
                            Token = token,
                            StatusCode = StatusCodes.Status200OK,
                            StatusMessage = Constants.MSG_LOGIN_SUCC
                        };
                    }
                }
                else
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.StatusMessage = Constants.MSG_LOGIN_FAIL;
                }
                return response;
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
