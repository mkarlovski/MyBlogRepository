using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Helpers
{
    public static class SectionConverter
    {
        public static Blog ConvertToSection(Blog blog)
        {
        //    Gadgets,
        //HowTo,
        //OS,
        //Mobile,
        //Apps
            switch (blog.Section)
            {
                case "0":
                    blog.Section = "Gadgets";
                    break;
                case "1":
                    blog.Section = "HowTo";
                    break;
                case "2":
                    blog.Section = "OS";
                    break;
                case "3":
                    blog.Section = "Mobile";
                    break;
                case "4":
                    blog.Section = "Apps";
                    break;

            }
            return blog;
        }
    }
}
