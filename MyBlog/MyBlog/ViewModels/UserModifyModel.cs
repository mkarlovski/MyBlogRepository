using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class UserModifyModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
