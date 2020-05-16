using System;

namespace MyBlog.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string ImageURL { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public string BlogNote { get; set; }
        public string FullDescription { get; set; }

    }
}
