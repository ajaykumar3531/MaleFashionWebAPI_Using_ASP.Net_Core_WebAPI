using MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion_WebAPI.BAL.Shared.Auth
{
    public interface ITokenManager
    {
        Task<string> GenerateTokenAsync(CreateAccountRequest request, string userId);

    }
}
