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

        public static ModifyUserOverview ConvertToUserModifyOverviewModel(User x)
        {
            return new ModifyUserOverview
            {
                Id=x.Id,
                Username=x.Username,
                IsAdmin=x.IsAdmin
            };
        }

        public static BlogDetailsModel ConvertToDetailsModel(Blog blog)
        {
            return new BlogDetailsModel
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                BlogNote = blog.BlogNote,
                ImageURL = blog.ImageURL,
                Section = blog.Section,
                DaysCreated = DateTime.Now.Subtract(blog.DateCreated.Value).Days,
                FullDescription=blog.FullDescription
            };
        }

        public static UserModifyModel ConvertToUserModifyModel(User user)
        {
            return new UserModifyModel
            {
                Id=user.Id,
                Username=user.Username,
                IsAdmin=user.IsAdmin
            };
        }

        public static Blog ConvertFromCreateModel(BlogCreateModel blogCreate)
        {
            return new Blog
            {
                ImageURL=blogCreate.ImageURL,
                Section=blogCreate.Section,
                Title=blogCreate.Title,
                BlogNote=blogCreate.BlogNote,
                FullDescription=blogCreate.FullDescription
            };
            
        }

        public static ModifyOverviewModel ConvertToModifyOverview(Blog blog)
        {
            return new ModifyOverviewModel
            {
                BlogID = blog.BlogID,
                Title = blog.Title
            };
        }

        public static BlogModifyModel ConvertToBlogModify(Blog blog)
        {
            return new BlogModifyModel
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                BlogNote = blog.BlogNote,
                ImageURL = blog.ImageURL,
                Section = blog.Section,
                DateCreated=blog.DateCreated,
                FullDescription = blog.FullDescription,
                Clicked=blog.Clicked               
            };
        }

        public static Blog ConvertFromBlogModify(BlogModifyModel blog)
        {
            return new Blog
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                BlogNote = blog.BlogNote,
                ImageURL = blog.ImageURL,
                Section = blog.Section,
                DateCreated = blog.DateCreated,
                FullDescription = blog.FullDescription,
                Clicked = blog.Clicked
            };
        }
    }
}
