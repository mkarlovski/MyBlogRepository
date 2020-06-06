using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Service.DtoModels
{
    public class SignUpResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
