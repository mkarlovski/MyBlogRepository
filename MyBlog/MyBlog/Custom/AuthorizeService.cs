using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBlog.Custom
{
    public class AuthorizeService
    {
        public static bool AuthorizeUser(ClaimsPrincipal user,int requestId)
        {
            return Convert.ToBoolean(user.FindFirst("IsAdmin").Value) || Convert.ToInt32(user.FindFirst("Id").Value) == requestId;
        }
    }
}
