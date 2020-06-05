using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogModifyModel
    {
        public int BlogID { get; set; }
        
        public string ImageURL { get; set; }
        
        public string Section { get; set; }
        
        public string Title { get; set; }
        
        public string BlogNote { get; set; }
        
        public string FullDescription { get; set; }
        public DateTime? DateCreated { get; set; }
        public int Clicked { get; set; }
    }
}
