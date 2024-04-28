using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt
{
    public class CreateAccountRequest
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

    }
}
