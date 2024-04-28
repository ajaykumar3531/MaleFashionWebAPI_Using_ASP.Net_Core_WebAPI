using MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt;
using MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion_WebAPI.BAL.UserMgmt.Contracts
{
    public interface IUserMgmtService
    {
        Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request);

        Task<LoginAccountResponse> LoginAccount(CreateAccountRequest request);
    }
}
