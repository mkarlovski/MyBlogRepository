using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Data
{
    public class Blog
    {
        public int BlogID { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string BlogNote { get; set; }
        [Required]
        public string FullDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public int Clicked { get; set; }

    }
}
