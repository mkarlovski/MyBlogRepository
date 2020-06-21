using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class ModifyUserOverview
    {
        public int Id { get; set; }
       
        public string Username { get; set; }

        public bool IsAdmin { get; set; }
    }
}
