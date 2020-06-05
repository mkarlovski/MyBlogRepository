using MyBlog.Data;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Helpers
{
    public static class ModelConverter
    {
        public static OverviewViewModel ConvertToOverviewModel(Blog blog)
        {

            return new OverviewViewModel
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                BlogNote = blog.BlogNote,
                ImageURL = blog.ImageURL,
                Section = blog.Section,
                DaysCreated = DateTime.Now.Subtract(blog.DateCreated.Value).Days
            };
        }
    }
}
