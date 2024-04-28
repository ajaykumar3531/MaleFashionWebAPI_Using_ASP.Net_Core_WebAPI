using MaleFashoin_WebAPI.Domain.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt.Response
{
    public class CreateAccountResponse : StatusDTO
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
