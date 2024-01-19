using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClient.ViewModels.Users
{
    public class UserInfoWithToken
    {
        public string token { get; set; }
        public UserInfo obj { get; set; }
    }
}
